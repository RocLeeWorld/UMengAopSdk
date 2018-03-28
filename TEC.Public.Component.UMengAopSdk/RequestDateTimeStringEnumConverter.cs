/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：RequestDateTimeStringEnumConverter
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/11 14:38:40 TEC-ROCLEE Roc.Lee

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
    public class RequestDateTimeStringEnumConverter : JsonConverter
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        private string _dateTimeFormat;



        /// <summary>
        /// Gets or sets the date time format used when converting a date to and from JSON.
        /// </summary>
        /// <value>The date time format used when converting a date to and from JSON.</value>
        public string DateTimeFormat
        {
            get { return _dateTimeFormat ?? string.Empty; }
            set { _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value; }
        }
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
            {
                return true;
            }
#if HAVE_DATE_TIME_OFFSET
            if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
            {
                return true;
            }
#endif

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new JsonSerializationException("未支持DateTime类型");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string text;

            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;


                text = dateTime.ToString(_dateTimeFormat ?? DefaultDateTimeFormat);
            }
#if HAVE_DATE_TIME_OFFSET
            else if (value is DateTimeOffset)
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                    || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                {
                    dateTimeOffset = dateTimeOffset.ToUniversalTime();
                }

                text = dateTimeOffset.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);
            }
#endif
            else
            {
                throw new JsonSerializationException("不是DateTime类型");
            }

            writer.WriteValue(text);
        }
    }
}
