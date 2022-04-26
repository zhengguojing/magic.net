


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using SqlSugar;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 员工附属机构职位表
    /// </summary>
    [SugarTable("sys_emp_ext_org_pos")]
    [Description("员工附属机构职位表")]
    public class SysEmpExtOrgPos
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        public long SysEmpId { get; set; }


        /// <summary>
        /// 机构Id
        /// </summary>
        public long SysOrgId { get; set; }


        /// <summary>
        /// 职位Id
        /// </summary>
        public long SysPosId { get; set; }
    }
}
