/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Request
// 类名：IAopRequest
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 14:24:59 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk.Request
{
    /// <summary>
    /// AOP请求接口。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAopRequest<T, M>
    {
        //string ToJSON(string appkey, string timestamp);
        string ToJSON();
        string GetApiPath();
    }
}
