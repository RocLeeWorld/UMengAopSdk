/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：ExpressionModel
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 16:14:54 TEC-ROCLEE Roc.Lee

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
using TEC.Public.Component.UMengAopSdk.FilterExpression;

namespace TEC.Public.Component.UMengAopSdk
{
    /// <summary>
    /// 筛选表达式
    /// </summary>
    [Serializable]
    public class ExpressionModel
    {
        [JsonIgnore]

        private IDictionary<string, ExpressionBase> value;

        public ExpressionModel()
        {                //this.expresssion = expresssion;
            //value = expresssion.ToObject();
            value = new Dictionary<string, ExpressionBase>();
        }

        public void AddExpress(ExpressionBase express)
        {
            var key = express.GetType().Name;
            if (value.ContainsKey(key))
            {
                throw new ArgumentException($"已存在的筛选字段:{key}", "express");
            }
            value.Add(key, express);
        }


        [JsonProperty(PropertyName = "and")]
        public IList<ExpressionBase> Value
        {
            get
            {
                return value.Select(m => m.Value).ToList();
            }
        }
    }
}
