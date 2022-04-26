using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Magic.Core.Entity
{
    /// <summary>
    /// 参数配置表
    /// </summary>
    [SugarTable("sys_config")]
    [Description("参数配置表")]
    public class SysConfig : DEntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required, MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        [MaxLength(50)]
        public string Value { get; set; }

        /// <summary>
        /// 是否是系统参数（Y-是，N-否）
        /// </summary>
        [MaxLength(5)]
        public string SysFlag { get; set; }

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
        /// 常量所属分类的编码，来自于“常量的分类”字典
        /// </summary>
        [MaxLength(50)]
        public string GroupCode { get; set; }

    }
}
