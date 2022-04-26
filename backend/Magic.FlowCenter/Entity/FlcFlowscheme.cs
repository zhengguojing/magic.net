using Magic.Core;
using Magic.Core.Entity;
using SqlSugar;
namespace Magic.FlowCenter.Entity
{
	/// <summary>
	/// 
	///</summary>
	[SugarTable("flc_flowscheme")]
    public class FlcFlowscheme : DEntityBase
    {
        /// <summary>
        ///  流程编号
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeCode", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeCode { get; set; }
        /// <summary>
        ///  流程名称
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeName", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeName { get; set; }
        /// <summary>
        ///  流程类型
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeType", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeType { get; set; }
        /// <summary>
        ///  流程版本
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeVersion", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeVersion { get; set; }
        /// <summary>
        ///  流程使用人
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeCanUser", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeCanUser { get; set; }
        /// <summary>
        ///  流程内容
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "SchemeContent", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string SchemeContent { get; set; }
        /// <summary>
        ///  表单Id
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "FrmId", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public long? FrmId { get; set; }
        /// <summary>
        ///  表单类型
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "FrmType", ColumnDescription = "", ColumnDataType = "int")]
        public FormType? FrmType { get; set; }
        /// <summary>
        ///  权限类型
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "AuthorizeType", ColumnDescription = "", ColumnDataType = "int")]
        public int? AuthorizeType { get; set; }
        /// <summary>
        ///  组织Id
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "OrgId", ColumnDescription = "", ColumnDataType = "int", IsNullable = true)]
        public long? OrgId { get; set; }
        /// <summary>
        ///  
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "Active", ColumnDescription = "", ColumnDataType = "text")]
        public string Active { get; set; }
        /// <summary>
        ///  状态
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "Status", ColumnDescription = "", ColumnDataType = "int")]
        public CommonStatus? Status { get; set; }
        /// <summary>
        ///  排序
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "Sort", ColumnDescription = "", ColumnDataType = "int")]
        public int? Sort { get; set; }
        /// <summary>
        ///  备注
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "Remark", ColumnDescription = "", ColumnDataType = "text", IsNullable = true)]
        public string Remark { get; set; }
    }
}
