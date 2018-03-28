/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Response
// 类名：IOSPushResponse
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 14:35:45 TEC-ROCLEE Roc.Lee

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
    public class AndroidPushResponse : AopResponse<AndroidPushResponse.DataModel>
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
            /// 当type为unicast、listcast或者customizedcast且alias不为空时:
            /// </summary>
            [JsonProperty("msg_id")]

            public string MsgId
            {
                get; set;
            }
            /// <summary>
            /// 当type为于broadcast、groupcast、filecast、customizedcast
            /// 且file_id不为空的情况(任务)
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
            /// 如果开发者填写了thirdparty_id, 接口也会返回该值。
            /// </summary>
            [JsonProperty("thirdparty_id")]

            public string ThirdpartyId
            {
                get; set;
            }
        }
    }
}
