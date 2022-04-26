using Magic.Core.Entity;
using SqlSugar;

namespace Magic.FlowCenter.Entity
{
	/// <summary>
	/// 自定义表单实体
	/// </summary>
	public class FlowInstanceEntity : PrimaryKeyEntity
	{
		/// <summary>
		/// 申请流程Id
		/// </summary>
		[SugarColumn(IsNullable = true, ColumnName = "FlowInstanceId", ColumnDataType = "int")]
		public long FlowInstanceId { get; set; }
	}
}
