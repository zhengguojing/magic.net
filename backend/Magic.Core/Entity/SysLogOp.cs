using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Magic.Core.Entity
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    [SugarTable("sys_log_op")]
    [Description("操作日志表")]
    public class SysLogOp : AutoIncrementEntity
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
        [MaxLength(500)]
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
        /// 请求地址
        /// </summary>
        [MaxLength(100)]
        public string Url { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        [MaxLength(100)]
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        [MaxLength(100)]
        public string MethodName { get; set; }

        /// <summary>
        /// 请求方式（GET POST PUT DELETE)
        /// </summary>
        [MaxLength(10)]
        public string ReqMethod { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Param { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 耗时（毫秒）
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [MaxLength(20)]
        public string Account { get; set; }
    }
}
