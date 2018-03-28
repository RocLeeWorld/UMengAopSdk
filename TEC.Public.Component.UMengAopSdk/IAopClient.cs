/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 接口名：IAopClient
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/6 11:07:27 TEC-ROCLEE Roc.Lee

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
using TEC.Public.Component.UMengAopSdk.Request;
using TEC.Public.Component.UMengAopSdk.Util;

namespace TEC.Public.Component.UMengAopSdk
{
    /// <summary>
    /// AOP客户端。
    /// </summary>
    public interface IAopClient
    {
        /// <summary>
        /// 执行AOP公开API请求。
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的AOP API请求</param>
        /// <returns>领域对象</returns>
        WebResponseResult<T> Execute<T, M>(IAopRequest<T, M> request) where T : AopResponse<M>;
        WebResponseResult<T> Execute<T, M>(JObject requestJson,string apipath) where T : AopResponse<M>;
    }
}
