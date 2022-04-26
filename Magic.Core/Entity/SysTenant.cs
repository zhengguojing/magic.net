using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 租户表
    /// </summary>
    [SugarTable("sys_tenant")]
    [Description("租户表")]
    public class SysTenant : DEntityBase
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        [Required, MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        [Required, MaxLength(20)]
        public string AdminName { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        [MaxLength(100)]
        public string Host { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(20)]
        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        [MaxLength(200)]
        public string Connection { get; set; }

        /// <summary>
        /// 架构
        /// </summary>
        [MaxLength(50)]
        public string Schema { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public string Remark { get; set; }

        /// <summary>
        /// 租户类型
        /// </summary>
        public TenantTypeEnum TenantType { get; set; }
    }
}
