using SqlSugar;
using System.ComponentModel;

namespace Magic.Core.Entity
{
    /// <summary>
    /// 角色数据范围表
    /// </summary>
    [SugarTable("sys_role_data_scope")]
    [Description("角色数据范围表")]
    public class SysRoleDataScope
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public long SysRoleId { get; set; }


        /// <summary>
        /// 机构Id
        /// </summary>
        public long SysOrgId { get; set; }


    }
}
