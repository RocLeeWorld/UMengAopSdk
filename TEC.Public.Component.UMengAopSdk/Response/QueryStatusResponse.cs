/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Response
// 类名：QueryStatusResponse
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/10 14:16:05 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk.Response
{
    public class QueryStatusResponse : AopResponse<QueryStatusResponse.DataModel>
    {
        public override bool IsError
        {
            get
            {
                return base.IsError || (Data.ErrorCode != null && Data.ErrorCode != "OK" && Data.ErrorCode != "CREATED" && Data.ErrorCode != "ACCEPTED");
            }
        }
        [Serializable]

        public class DataModel
        {
            /// <summary>
            /// 当"ret"为"SUCCESS"时,包含如下参数:
            /// </summary>
            [JsonProperty("task_id")]

            public string TaskId
            {
                get; set;
            }
            /// <summary>
            /// 当"ret"为"FAIL"时,包含如下参数:
            /// 错误码详见附录I。
            /// </summary>
            [JsonProperty("error_code")]

            public string ErrorCode
            {
                get; set;
            }
            /// <summary>
            /// 消息状态: 0-排队中, 1-发送中，2-发送完成，3-发送失败，4-消息被撤销，
            /// 5-消息过期, 6-筛选结果为空，7-定时任务尚未开始处理
            /// </summary>
            [JsonProperty("status")]

            public string Status
            {
                get; set;
            }

            /// <summary>
            /// 消息总数
            /// </summary>
            [JsonProperty("total_count")]

            public string TotalCount
            {
                get; set;
            }

            /// <summary>
            /// 消息受理数
            /// </summary>
            [JsonProperty("accept_count")]

            public string AcceptCount
            {
                get; set;
            }

            /// <summary>
            /// 消息实际发送数
            /// </summary>
            [JsonProperty("sent_count")]

            public string SentCount
            {
                get; set;
            }

            /// <summary>
            /// 打开数
            /// </summary>
            [JsonProperty("open_count")]

            public string OpenCount
            {
                get; set;
            }

            /// <summary>
            /// 忽略数
            /// </summary>
            [JsonProperty("dismiss_count")]

            public string DismissCount
            {
                get; set;
            }
        }
    }
}
