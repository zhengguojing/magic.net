﻿using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 字典值表
    /// </summary>
    [SugarTable("sys_dict_data")]
    [Description("字典值表")]
    public class SysDictData : DEntityBase
    {
        /// <summary>
        /// 字典类型Id
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [MaxLength(100)]
        public string Value { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public string Remark { get; set; }

        /// <summary>
        /// 状态（字典 0正常 1停用 2删除）
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.ENABLE;

    }
}
