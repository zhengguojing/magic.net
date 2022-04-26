using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("sys_user")]
    [Description("用户表")]
    public class SysUser : DBEntityTenant
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required, MaxLength(20)]
        public string Account { get; set; }

        /// <summary>
        /// 密码（默认MD5加密）
        /// </summary>
        [Required, MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(20)]
        public string NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 性别-男_1、女_2
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(20)]
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        [MaxLength(20)]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 管理员类型-超级管理员_1、非管理员_2
        /// </summary>
        public AdminType? AdminType { get; set; }

        /// <summary>
        /// 状态-正常_0、停用_1、删除_2
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.ENABLE;
    }
}
