using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 访问日志表
    /// </summary>
    [SugarTable("sys_log_vis")]
    [Description("访问日志表")]
    public class SysLogVis : AutoIncrementEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 是否执行成功（Y-是，N-否）
        /// </summary>
        public YesOrNot Success { get; set; }

        /// <summary>
        /// 具体消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [MaxLength(20)]
        public string Ip { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(100)]
        public string Location { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [MaxLength(100)]
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [MaxLength(100)]
        public string Os { get; set; }

        /// <summary>
        /// 访问类型
        /// </summary>
        public LoginType VisType { get; set; }

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime VisTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
        [MaxLength(20)]
        public string Account { get; set; }
    }
}