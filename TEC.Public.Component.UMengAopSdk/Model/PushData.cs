/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.Model
// 类名：PushData
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/2 17:36:54 TEC-ROCLEE Roc.Lee

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

namespace TEC.Public.Component.UMengAopSdk.Model
{
    public class PushData
    {
        [JsonProperty(PropertyName = "type")]
        public string PushType { get; set; }

        /// <summary>
        /// 可选 设备唯一表示        
        /// 当type=unicast时,必填, 表示指定的单个设备        
        /// 当type = listcast时, 必填, 要求不超过500个,
        /// 多个device_token以英文逗号间隔
        /// </summary>
        [JsonProperty(PropertyName = "device_tokens")]
        public string DeviceTokens { get; set; }

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
        public string Alias { get; set; }

        /// <summary>
        /// 可选 当type=filecast时，file内容为多条device_token, 
        ///         device_token以回车符分隔
        ///         当type = customizedcast时，file内容为多条alias，
        ///        alias以回车符分隔，注意同一个文件内的alias所对应
        ///         的alias_type必须和接口参数alias_type一致。
        ///                                  注意，使用文件播前需要先调用文件上传接口获取file_id, 
        ///         具体请参照"2.4文件上传接口"
        /// </summary>
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// 可选 终端用户筛选条件,如用户标签、地域、应用版本以及渠道等,
        ///        具体请参考附录G。
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public object Filter { get; set; }
        /// <summary>
        /// 必填 消息内容(Android最大为1840B), 包含参数说明如下(JSON格式):
        /// </summary>
        [JsonProperty(PropertyName = "payload")]
        public object Payload { get; set; }
        /// <summary>
        /// 可选 发送策略
        /// </summary>
        [JsonProperty(PropertyName = "policy")]
        public object Policy { get; set; }
        /// <summary>
        /// true/false 可选 正式/测试模式。测试模式下，只会将消息发给测试设备。
        /// 测试设备需要到web上添加。
        /// </summary>
        [JsonProperty(PropertyName = "production_mode")]
        public string ProductionMode { get; set; }
        /// <summary>
        /// 可选 发送消息描述，建议填写。
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 可选 开发者自定义消息标识ID, 开发者可以为同一批发送的多条消息提供同一个thirdparty_id, 便于友盟后台后期合并统计数据。  
        /// </summary>
        [JsonProperty(PropertyName = "thirdparty_id")]
        public string ThirdpartyId { get; set; }
    }
}
