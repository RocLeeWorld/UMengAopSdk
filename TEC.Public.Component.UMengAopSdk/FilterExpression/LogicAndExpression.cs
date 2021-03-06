﻿/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：LogicAndExpression
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 16:29:36 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk
{
    [Serializable]
    public class LogicAndExpression : IExpression
    {
        [JsonIgnore]

        private IList<IExpression> express;
        public LogicAndExpression(IList<IExpression> express)
        {

            this.express = express;

        }
        [JsonProperty(PropertyName = "and", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IExpression> Express { get { return this.express; } }
        /*
                public JObject ToObject()
                {
                    var jobject = new JObject();
                    jobject["and"] = new JArray(express);
                    return jobject;

                    //return new { and = express };
                }*/
    }
}
