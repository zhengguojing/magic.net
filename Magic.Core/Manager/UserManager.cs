
using Furion;
using Furion.DependencyInjection;
using Furion.FriendlyException;
using Magic.Core.Entity;
using Microsoft.AspNetCore.Http;
using SqlSugar;
using System.Threading.Tasks;

namespace Magic.Core
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public static class UserManager
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public static long UserId => long.Parse(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);

        /// <summary>
        /// 账号
        /// </summary>
        public static string Account => App.User.FindFirst(ClaimConst.CLAINM_ACCOUNT)?.Value;

        /// <summary>
        /// 昵称
        /// </summary>
        public static string Name => App.User.FindFirst(ClaimConst.CLAINM_NAME)?.Value;

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public static bool IsSuperAdmin => App.User.FindFirst(ClaimConst.CLAINM_SUPERADMIN)?.Value == ((int)AdminType.SuperAdmin).ToString();

        /// <summary>
        /// 是否租户管理员
        /// </summary>
        public static bool IsTenantAdmin => App.User.FindFirst(ClaimConst.CLAINM_SUPERADMIN)?.Value == ((int)AdminType.Admin).ToString();


        //private readonly SqlSugarRepository<SysUser> _sysUserRep; // 用户表仓储   
        //private readonly SqlSugarRepository<SysEmp> _sysEmpRep;   // 员工表
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public long UserId
        //{
        //    get => long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
        //}

        //public string Account
        //{
        //    get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.CLAINM_ACCOUNT)?.Value;
        //}

        //public string Name
        //{
        //    get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.CLAINM_NAME)?.Value;
        //}

        //public bool SuperAdmin
        //{
        //    get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.CLAINM_SUPERADMIN)?.Value == ((int)AdminType.SuperAdmin).ToString();
        //}

        //public SysUser User
        //{
        //    get => _sysUserRep.FirstOrDefault(u => u.Id == UserId);
        //}

        //public UserManager(SqlSugarRepository<SysUser> sysUserRep,
        //                   SqlSugarRepository<SysEmp> sysEmpRep,
        //                   IHttpContextAccessor httpContextAccessor)
        //{
        //    _sysUserRep = sysUserRep;
        //    _sysEmpRep = sysEmpRep;
        //    _httpContextAccessor = httpContextAccessor;
        //}

    }
}