/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：AopResponse
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 11:08:20 TEC-ROCLEE Roc.Lee

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

namespace TEC.Public.Component.UMengAopSdk
{
    [Serializable]
    public abstract class AopResponse<M>
    {

        /// <summary>
        /// 返回结果，"SUCCESS"或者"FAIL"
        /// </summary>
        [JsonProperty("ret")]

        public string Ret
        {
            get; set;
        }
        /// <summary>
        /// 当"ret"为"SUCCESS"时,包含如下参数:
        /// </summary>
        [JsonProperty("data")]

        public M Data
        {
            get; set;
        }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body
        {
            get; set;
        }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        public virtual bool IsError
        {
            get
            {
                return Ret != "SUCCESS" || Data == null /*|| (Data.ErrorCode != "OK" && Data.ErrorCode != "CREATED" && Data.ErrorCode != "ACCEPTED")*/;
            }
        }

    }
}
