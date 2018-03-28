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
    public class UploadResponse : AopResponse<UploadResponse.DataModel>
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
            /// 当"ret"为"SUCCESS"时
            /// </summary>
            [JsonProperty("file_id")]

            public string FileId
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
        }
    }
}
