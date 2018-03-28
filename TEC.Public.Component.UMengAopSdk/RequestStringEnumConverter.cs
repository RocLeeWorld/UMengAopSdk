/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：DefaultStringEnumConverter
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/11 14:08:13 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk
{
    public class RequestStringEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            Type t = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)
                ? Nullable.GetUnderlyingType(objectType)
                : objectType;

            return t.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("没有对枚举类型的读取支持");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(value.ToString().ToLower());
        }
    }

}
