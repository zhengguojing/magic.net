using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// Oauth登录用户表
    /// </summary>
    [SugarTable("sys_oauth_user")]
    [Description("Oauth登录用户表")]
    public class SysOauthUser : DEntityBase
    {
        /// <summary>
        /// 第三方平台的用户唯一Id
        /// </summary>
        [MaxLength(50)]
        public string Uuid { get; set; }

        /// <summary>
        /// 用户授权的token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(20)]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [MaxLength(5)]
        public string Gender { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(20)]
        public string Email { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [MaxLength(50)]
        public string Location { get; set; }

        /// <summary>
        /// 用户网址
        /// </summary>
        public string Blog { get; set; }

        /// <summary>
        /// 所在公司
        /// </summary>
        [MaxLength(50)]
        public string Company { get; set; }

        /// <summary>
        /// 用户来源
        /// </summary>
        [MaxLength(20)]
        public string Source { get; set; }

        /// <summary>
        /// 用户备注（各平台中的用户个人介绍）
        /// </summary>
        [MaxLength(100)]
        public string Remark { get; set; }
    }
}