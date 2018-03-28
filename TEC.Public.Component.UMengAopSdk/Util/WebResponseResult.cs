/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Util
// 类名：WebResponseResult
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/7 9:22:51 TEC-ROCLEE Roc.Lee

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

namespace TEC.Public.Component.UMengAopSdk.Util
{
    public class WebResponseResult<T>
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string ResponseText { get; private set; }
        public Exception Ex { get; private set; }
        public T Data { get; private set; }
        public WebResponseResult(int statusCode, string responseText, Exception e = null)
        {
            if (statusCode == 200)
            {
                Success = true;
                Data = strToObj(responseText);
            }

            else if (statusCode == 400)
            {
                Success = false;
                Data = strToObj(responseText);
            }
            else
            {
                Success = false;
                Data = default(T);
            }
            ResponseText = responseText;
            StatusCode = statusCode;
            Ex = e;
        }
        public override string ToString()
        {
            //重写需要的输出。
            return "[success:" + Success + ",statusCode:" + StatusCode + ",responseText:" + ResponseText + ",data:" + Data + "]";
        }
        private static T strToObj(string str)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<T>(str);

                return json;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
