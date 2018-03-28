/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：PushParam
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/2 16:45:22 TEC-ROCLEE Roc.Lee

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
    public class PushParam
    {
        /// <summary>
        /// 必填 消息发送类型
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public PushTypeEnum PushType { get; set; }

        /// <summary>
        /// 可选 设备唯一表示        
        /// 当type=unicast时,必填, 表示指定的单个设备        
        /// 当type = listcast时, 必填, 要求不超过500个,
        /// 多个device_token以英文逗号间隔
        /// </summary>
        [JsonProperty(PropertyName = "device_tokens")]
        public HashSet<string> DeviceTokens { get; set; }

        /// <summary>
        /// 可选 当type=customizedcast时，必填，alias的类型, 
        /// alias_type可由开发者自定义,开发者在SDK中
        /// </summary>
        [JsonProperty(PropertyName = "alias_type")]
        public string AliasType { get; set; }

        /// <summary>
        /// 选 当type=customizedcast时, 开发者填写自己的alias。
        /// 要求不超过50个alias,多个alias以英文逗号间隔。
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public HashSet<string> Alias { get; set; }
    }
}
