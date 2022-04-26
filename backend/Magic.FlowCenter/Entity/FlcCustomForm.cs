using SqlSugar;
using System;

namespace Magic.FlowCenter.Entity
{
    /// <summary>
    /// 自定义表单
    /// </summary>
	[SugarTable("flc_customform")]
    public class FlcCustomForm : FlowInstanceEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnName = "Name", ColumnDataType = "text")]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnName = "Sort", ColumnDescription = "", ColumnDataType = "int")]
        public int Sort { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnName = "Remark", ColumnDataType = "text")]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "创建时间", ColumnName = "CreatedTime", ColumnDataType = "text")]
        public virtual DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 创建者Id
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者Id", ColumnName = "CreatedUserId", ColumnDataType = "int")]
        public virtual long? CreatedUserId { get; set; }
        /// <summary>
        /// 创建者名称
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者名称", ColumnName = "CreatedUserName", ColumnDataType = "text")]
        public virtual string CreatedUserName { get; set; }
    }
}
