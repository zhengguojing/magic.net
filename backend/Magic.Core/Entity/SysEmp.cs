using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 员工表
    /// </summary>
    [SugarTable("sys_emp")]
    [Description("员工表")]
    public class SysEmp : PrimaryKeyEntity
    {
        /// <summary>
        /// 工号
        /// </summary>
        [MaxLength(30)]
        public string JobNum { get; set; }

        /// <summary>
        /// 机构Id
        /// </summary>
        public long OrgId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [MaxLength(50)]
        public string OrgName { get; set; }

    }
}
