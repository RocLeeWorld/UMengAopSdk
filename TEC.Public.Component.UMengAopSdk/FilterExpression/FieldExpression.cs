/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：FieldExpression
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 16:31:10 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk
{
    public class FieldExpression : IExpression
    {
        private ExpressionFieldEnmu field;
        private string value;
        public FieldExpression(ExpressionFieldEnmu field, string value)
        {
            this.field = field;
            this.value = value;
        }

        public JObject ToObject()
        {
            var jobject = new JObject();
            jobject["field"] = field.ToString().ToLower();
            jobject["value"] = value;
            return jobject;
            //return new { field = field.ToString().ToLower(), value };
        }

    }
}
