/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：FilterModel
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 16:13:39 TEC-ROCLEE Roc.Lee

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
    /// <summary>
    /// 筛选条件
    /// </summary>
    [Serializable]
    public class FilterModel//: IJsonObject
    {
        /// <summary>
        /// json obj 如： {"and":[{"or":[{"app_version":">1.0"}]}]}
        /// </summary>
        [JsonProperty(PropertyName = "where", Required = Required.Always)]
        public ExpressionModel Expression { get; set; }

        /*  public JObject ToObject()
          {
              return JObject.FromObject(this);
          }*/
    }
}
