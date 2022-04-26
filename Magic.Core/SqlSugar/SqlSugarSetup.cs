using Furion;
using Magic.Core.Entity;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace Magic.Core
{
	public static class SqlSugarSetup
	{
        public static void SqlSugarConfigure(this IServiceCollection services)
        {
            #region 配置sqlsuagr
            List<ConnectionConfig> connectConfigList = new List<ConnectionConfig>();
            //数据库序号从0开始,默认数据库为0
            var config = App.GetOptions<ConnectionStringsOptions>();
            //默认数据库
            connectConfigList.Add(new ConnectionConfig
            {
                ConnectionString = config.DefaultDbString,
                DbType = (DbType)Convert.ToInt32(Enum.Parse(typeof(DbType), config.DefaultDbType)),
                IsAutoCloseConnection = true,
                ConfigId = config.DefaultDbNumber,
                InitKeyType = InitKeyType.Attribute,
                MoreSettings = new ConnMoreSettings()
                {
                    IsAutoRemoveDataCache = true//自动清理缓存
                }
            });
            if (config.DbConfigs == null)
                config.DbConfigs = new List<DbConfig>();
            //业务数据库集合
            foreach (var item in config.DbConfigs)
            {
                //防止数据库重复，导致的事务异常
                if (connectConfigList.Any(a => a.ConfigId == (dynamic)item.DbNumber || a.ConnectionString == item.DbString))
				{
                    continue;
				}
                connectConfigList.Add(new ConnectionConfig
                {
                    ConnectionString = item.DbString,
                    DbType = (DbType)Convert.ToInt32(Enum.Parse(typeof(DbType), item.DbType)),
                    IsAutoCloseConnection = true,
                    ConfigId = item.DbNumber,
                    InitKeyType = InitKeyType.Attribute,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true//自动清理缓存
                    }
                });
            }
            List<Type> types = App.EffectiveTypes.Where(a => !a.IsAbstract && a.IsClass && a.GetCustomAttributes(typeof(SugarTable), true)?.FirstOrDefault() != null).ToList();
            //sugar action
            Action<ISqlSugarClient> configure = db =>
            {
                connectConfigList.ForEach(config => {
                    string temp = config.ConfigId;
                    var _db = db.AsTenant().GetConnection(temp);
                    _db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
                     {
                         DataInfoCacheService = new SqlSugarCache()//配置我们创建的缓存类
                     };
                    //执行超时时间
                    _db.Ado.CommandTimeOut = 30;
                    _db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        if (sql.StartsWith("SELECT"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (sql.StartsWith("UPDATE") || sql.StartsWith("INSERT"))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (sql.StartsWith("DELETE"))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        //App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + _db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                        Console.WriteLine(sql + "\r\n\r\n" + SqlProfiler.ParameterFormat(sql, pars));
                        App.PrintToMiniProfiler("SqlSugar", "Info", SqlProfiler.ParameterFormat(sql, pars));
                    };
                    //全局过滤器
                    var superAdminViewAllData = Convert.ToBoolean(App.GetOptions<SystemSettingsOptions>().SuperAdminViewAllData);
                    foreach (var entityType in types)
                    {
                        // 配置多租户全局过滤器
                        if (!entityType.GetProperty(ClaimConst.TENANT_ID).IsEmpty())
                        { //判断实体类中包含TenantId属性
                          //构建动态Lambda
                            var lambda = DynamicExpressionParser.ParseLambda
                            (new[] { Expression.Parameter(entityType, "it") },
                             typeof(bool), $"{nameof(DBEntityTenant.TenantId)} ==  @0 or (@1 and @2)",
                              GetTenantId(), IsSuperAdmin(), superAdminViewAllData);
                            _db.QueryFilter.Add(new TableFilterItem<object>(entityType, lambda)); //将Lambda传入过滤器
                        }
                        // 配置加删除全局过滤器
                        if (!entityType.GetProperty(CommonConst.DELETE_FIELD).IsEmpty())
                        { //判断实体类中包含IsDeleted属性
                          //构建动态Lambda
                            var lambda = DynamicExpressionParser.ParseLambda
                            (new[] { Expression.Parameter(entityType, "it") },
                             typeof(bool), $"{nameof(DEntityBase.IsDeleted)} ==  @0",
                              false);
                            _db.QueryFilter.Add(new TableFilterItem<object>(entityType, lambda)
                            {
                                IsJoinQuery = true
                            }); //将Lambda传入过滤器
                        }
                    }
                });
            };
            services.AddSqlSugar(connectConfigList, configure);
            #endregion
        }
        /// <summary>
        /// 获取当前租户id
        /// </summary>
        /// <returns></returns>
        private static object GetTenantId()
        {
            if (App.User == null) return null;
            return App.User.FindFirst(ClaimConst.TENANT_ID)?.Value;
        }

        /// <summary>
        /// 判断是不是超级管理员
        /// </summary>
        /// <returns></returns>
        private static bool IsSuperAdmin()
        {
            if (App.User == null) return false;
            return App.User.FindFirst(ClaimConst.CLAINM_SUPERADMIN)?.Value == AdminType.SuperAdmin.GetHashCode().ToString();
        }
        /// <summary>
        /// 添加 SqlSugar 拓展
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="buildAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, ConnectionConfig config, Action<ISqlSugarClient> buildAction = default)
        {
            var list = new List<ConnectionConfig>();
            list.Add(config);
            return services.AddSqlSugar(list, buildAction);
        }

        /// <summary>
        /// 添加 SqlSugar 拓展
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configs"></param>
        /// <param name="buildAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, List<ConnectionConfig> configs, Action<ISqlSugarClient> buildAction = default)
        {
            // 注册 SqlSugar 客户端
            services.AddScoped<ISqlSugarClient>(u =>
            {
                var db = new SqlSugarClient(configs);
                buildAction?.Invoke(db);
                return db;
            });

            // 注册 SqlSugar 仓储
            services.AddScoped(typeof(SqlSugarRepository<>));
            services.AddScoped(typeof(SqlSugarRepository));

            return services;
        }
    }
}
