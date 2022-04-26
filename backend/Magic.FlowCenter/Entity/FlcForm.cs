using Magic.Core;
using Magic.Core.Entity;
using SqlSugar;
namespace Magic.FlowCenter.Entity
{
	/// <summary>
	/// 表单
	///</summary>
	[SugarTable("flc_form")]
    public class FlcForm: DEntityBase
    {
        /// <summary>
        ///  表单名称
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="Name",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string Name { get; set; }
        /// <summary>
        ///  表单类型
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "FrmType", ColumnDescription = "", ColumnDataType = "int", IsNullable = true)]
        public FormType? FrmType { get; set; }
        /// <summary>
        ///  自定义表单
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="WebId",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string WebId { get; set; }
        /// <summary>
        ///  字段数
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="Fields",ColumnDescription="",ColumnDataType = "int", IsNullable = true)]
         public int? Fields { get; set; }
        /// <summary>
        ///  字段
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="ContentData",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string ContentData { get; set; }
        /// <summary>
        ///  字段格式化
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="ContentParse",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string ContentParse { get; set; }
        /// <summary>
        ///  表单内容
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="Content",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string Content { get; set; }
        /// <summary>
        ///  数据库备用
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="DbName",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string DbName { get; set; }
        /// <summary>
        ///  组织id
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="OrgId",ColumnDescription="",ColumnDataType = "int", IsNullable = true)]
         public long? OrgId { get; set; }
        /// <summary>
        ///  
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="Active",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string Active { get; set; }
        /// <summary>
        ///  状态
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName="Status",ColumnDescription="",ColumnDataType = "int")]
        public CommonStatus? Status { get; set; }
        /// <summary>
        ///  排序
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName="Sort",ColumnDescription="",ColumnDataType = "int")]
         public int? Sort { get; set; }
        /// <summary>
        ///  备注
        /// 默认值: 
        ///</summary>
         [SugarColumn(ColumnName="Remark",ColumnDescription="",ColumnDataType = "text", IsNullable = true)]
         public string Remark { get; set; }
    }
}
