using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    [SugarTable("sys_role")]
    [Description("角色表")]
    public class SysRole : DBEntityTenant
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required, MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required, MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 数据范围类型（字典 1全部数据 2本部门及以下数据 3本部门数据 4仅本人数据 5自定义数据）
        /// </summary>
        public DataScopeType DataScopeType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public string Remark { get; set; }

        /// <summary>
        /// 状态（字典 0正常 1停用 2删除）
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.ENABLE;

        /// <summary>
        /// 管理员类型-超级管理员_1、非管理员_2
        /// </summary>
        public RoleType? RoleType { get; set; }

    }
}
