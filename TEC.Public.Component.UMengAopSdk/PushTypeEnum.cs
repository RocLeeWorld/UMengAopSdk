/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：PushTypeEnum
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/2 16:46:17 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk
{
    public enum PushTypeEnum
    {
        /// <summary>
        /// 单播
        /// </summary>
        [Description("unicast")]
        UniCast,
        /// <summary>
        /// 列播(要求不超过500个device_token)
        /// </summary>
        [Description("listcast")]
        ListCast,
        /// <summary>
        /// 文件播(多个device_token可通过文件形式批量发送）
        /// </summary>
        [Description("filecast")]
        FileCast,
        /// <summary>
        /// 广播
        /// </summary>
        [Description("broadcast")]
        BroadCast,
        /// <summary>
        /// 组播(按照filter条件筛选特定用户群, 具体请参照filter参数)
        /// </summary>
        [Description("groupcast")]
        GroupCast,
        /// <summary>
        /// (通过开发者自有的alias进行推送),         
        /// 包括以下两种case:                                     
        /// - alias: 对单个或者多个alias进行推送                                     
        /// - file_id: 将alias存放到文件后，根据file_id来推送
        /// </summary>
        [Description("customizedcast")]
        CustomizedCast
    }
}
