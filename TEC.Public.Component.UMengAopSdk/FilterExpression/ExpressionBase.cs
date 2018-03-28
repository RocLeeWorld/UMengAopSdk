/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：ExpressionBase
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/13 16:00:53 TEC-ROCLEE Roc.Lee

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

namespace TEC.Public.Component.UMengAopSdk.FilterExpression
{
    /// <summary>
    /// "app_version"(应用版本) 
    /// "channel"(渠道) 
    /// "device_model"(设备型号) 
    /// "province"(省) 
    /// "tag"(用户标签) 
    /// "country"(国家) //"country"和"province"的类型定义请参照 附录J 
    /// "language"(语言) 
    /// "launch_from"(一段时间内活跃) 
    /// "not_launch_from"(一段时间内不活跃) 
    /// </summary>
    public abstract class ExpressionBase : JObject
    {

    }
}
