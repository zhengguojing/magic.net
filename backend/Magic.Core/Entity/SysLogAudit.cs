
using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 系统操作/审计日志表
    /// </summary>
    [SugarTable("sys_log_audit")]
    [Description("系统操作/审计日志表")]
    public class SysLogAudit : AutoIncrementEntity
    {
        /// <summary>
        /// 表名
        /// </summary>
        [MaxLength(50)]
        public string TableName { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [MaxLength(50)]
        public string ColumnName { get; set; }

        /// <summary>
        /// 新值
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// 旧值
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 操作人Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        [MaxLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 操作方式：新增、更新、删除
        /// </summary>
        public DataOpType Operate { get; set; }
    }
}