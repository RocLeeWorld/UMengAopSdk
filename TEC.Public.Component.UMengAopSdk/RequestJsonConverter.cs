/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：DefaultJsonConverter
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/11 11:38:30 TEC-ROCLEE Roc.Lee

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
    public class RequestJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType is IJsonObject;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException($"{objectType.Name}不支持JSON转换.");
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is IJsonObject)
            {
                ((IJsonObject)value).ToObject().WriteTo(writer);
            }
            else
            {
                JObject.FromObject(value).WriteTo(writer);
            }
        }
    }
}
