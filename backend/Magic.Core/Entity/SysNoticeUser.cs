using SqlSugar;
using System;
using System.ComponentModel;

namespace Magic.Core.Entity
{
    /// <summary>
    /// 通知公告用户表
    /// </summary>
    [SugarTable("sys_notice_user")]
    [Description("通知公告用户表")]
    public class SysNoticeUser 
    {
        /// <summary>
        /// 通知公告Id
        /// </summary>
        public long NoticeId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 阅读时间
        /// </summary>
        public DateTime ReadTime { get; set; }

        /// <summary>
        /// 状态（字典 0未读 1已读）
        /// </summary>
        public NoticeUserStatus ReadStatus { get; set; }
    }
}
