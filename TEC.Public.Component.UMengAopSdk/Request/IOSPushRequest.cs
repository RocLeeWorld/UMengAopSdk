/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：Request
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/3 9:34:28 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TEC.Public.Component.UMengAopSdk.Response;

namespace TEC.Public.Component.UMengAopSdk.Request
{
    [Serializable]
    public class IOSPushRequest : IAopRequest<IOSPushResponse, IOSPushResponse.DataModel>
    {
        #region 属性
        /// <summary>
        /// 必填 消息发送类型
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always), JsonConverter(typeof(RequestStringEnumConverter))]
        public PushTypeEnum PushType { get; set; }

        /// <summary>
        /// 可选 设备唯一表示        
        /// 当type=unicast时,必填, 表示指定的单个设备        
        /// 当type = listcast时, 必填, 要求不超过500个,
        /// 多个device_token以英文逗号间隔
        /// </summary>
        [JsonProperty(PropertyName = "device_tokens", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceTokens { get; set; }

        /// <summary>
        /// 可选 当type=customizedcast时，必填，alias的类型, 
        /// alias_type可由开发者自定义,开发者在SDK中
        /// </summary>
        [JsonProperty(PropertyName = "alias_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AliasType { get; set; }

        /// <summary>
        /// 可选 当type=customizedcast时, 开发者填写自己的alias。
        /// 要求不超过50个alias,多个alias以英文逗号间隔。
        /// </summary>
        [JsonProperty(PropertyName = "alias", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "file_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        /// <summary>
        /// 可选 终端用户筛选条件,如用户标签、地域、应用版本以及渠道等,
        ///        具体请参考附录G。
        /// </summary>
        [JsonProperty(PropertyName = "filter", NullValueHandling = NullValueHandling.Ignore)]
        public FilterModel Filter { get; set; }

        /// <summary>
        /// 必填 消息内容(Android最大为1840B), 包含参数说明如下(JSON格式):
        /// </summary>
        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public PayloadModel Payload { get; set; }

        /// <summary>
        /// 可选 发送策略
        /// </summary>
        [JsonProperty(PropertyName = "policy", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyModel Policy { get; set; }

        /// <summary>
        /// 可选 true/false 可选 正式/测试模式。测试模式下，只会将消息发给测试设备。
        /// 测试设备需要到web上添加。
        /// </summary>
        [JsonProperty(PropertyName = "production_mode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProductionMode { get; set; }

        /// <summary>
        /// 可选 发送消息描述，建议填写。
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// 可选 开发者自定义消息标识ID, 开发者可以为同一批发送的多条消息提供同一个thirdparty_id, 便于友盟后台后期合并统计数据。  
        /// </summary>
        [JsonProperty(PropertyName = "thirdparty_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ThirdpartyId { get; set; }
        #endregion

        public string ToJSON(string appkey, string timestamp)
        {
            JObject jobject = JObject.FromObject(this);
            jobject["appkey"] = appkey;
            jobject["timestamp"] = timestamp;
            return JsonConvert.SerializeObject(jobject);
            //JObject jobject = JObject.FromObject(this);
            //jobject["appkey"] = appkey;
            //jobject["timestamp"] = timestamp;
            //jobject["type"] = PushType.ToString().ToLower();
            //jobject["device_tokens"] = string.Join(",", DeviceTokens);
            //jobject["alias"] = string.Join(",", Alias);
            //jobject["filter"] = Filter.ToObject();
            //jobject["payload"] = Payload.ToObject();
            //jobject["policy"] = Policy.ToObject();
            //return jobject.ToString();

            //return JsonConvert.SerializeObject(new
            //{
            //    appkey = appkey,
            //    timestamp = timestamp,
            //    type = PushType.ToString().ToLower(),
            //    device_tokens = string.Join(",", DeviceTokens),
            //    alias_type = AliasType,
            //    alias = string.Join(",", Alias),
            //    file_id = FileId,
            //    filter = Filter.ToObject(),
            //    payload = Payload.ToObject(),
            //    policy = Policy.ToObject(),
            //    production_mode = ProductionMode,
            //    description = Description,
            //    thirdparty_id = ThirdpartyId
            //});
        }
        public string ToJSON()
        {
            JObject jobject = JObject.FromObject(this);
            return JsonConvert.SerializeObject(jobject);
        }
        private const string APIPATH = "/api/send";
        public string GetApiPath()
        {
            return APIPATH;
        }

        #region PayloadModel
        //public enum ExpressionLogicEnmu
        //{
        //    AND, OR, NOT
        //}
        [Serializable]
        public class PayloadModel : JObject
        {
            //private JObject diyobj = new JObject();

            //public string this[string key]
            //{
            //    get { return diyobj.GetValue(key)?.ToString(); }
            //    set { diyobj[key] = value; }
            //}
            /// <summary>
            ///必填 严格按照APNs定义来填写
            /// </summary>
            [JsonProperty(PropertyName = "aps")]
            public ApsModel Aps
            {
                get
                {
                    return this["aps"].ToObject<ApsModel>();
                }
                set
                {
                    this["aps"] = JObject.FromObject(value);
                }
            }
            /*
                        public JObject ToObject()
                        {
                            return diyobj.HasValues ? diyobj : null;
                        }
                        */


            [Serializable]
            public class ApsModel //: IJsonObject
            {
                /// <summary>
                /// 必填 
                /// </summary>
                [JsonProperty(PropertyName = "alert", Required = Required.Always)]
                public object Alter { get; set; } = "提示信息";
                /// <summary>
                /// 可选
                /// </summary>
                [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
                public string Badge { get; set; }
                /// <summary>
                /// 可选
                /// </summary>
                [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
                public string Sound { get; set; }
                /// <summary>
                /// 可选
                /// </summary>
                [JsonProperty(PropertyName = "content-available", NullValueHandling = NullValueHandling.Ignore)]
                public string ContentAvailable { get; set; }
                /// <summary>
                /// 可选, 注意: ios8才支持该字段。
                /// </summary>
                [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
                public object Category { get; set; }
                /*
                                public JObject ToObject()
                                {
                                    return JObject.FromObject(this);
                                }
                                */


            }


        }
        #endregion

        #region PolicyModel
        /// <summary>
        /// 可选 发送策略
        /// </summary>
        [Serializable]
        public class PolicyModel //: IJsonObject
        {
            /// <summary>
            /// 可选 定时发送时间，若不填写表示立即发送。
            /// 定时发送时间不能小于当前时间
            /// 格式: "yyyy-MM-dd HH:mm:ss"。 
            /// 注意, start_time只对任务生效。
            /// </summary>
            [JsonProperty(PropertyName = "start_time", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(RequestDateTimeStringEnumConverter))]
            public DateTime? StartTime { get; set; }

            /// <summary>
            /// 可选 消息过期时间,其值不可小于发送时间或者
            ///                                   start_time(如果填写了的话), 
            ///            如果不填写此参数，默认为3天后过期。格式同start_time
            /// </summary>
            [JsonProperty(PropertyName = "expire_time", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(RequestDateTimeStringEnumConverter))]
            public DateTime? ExpireTime { get; set; }
            /// <summary>
            /// 可选 发送限速，每秒发送的最大条数。
            ///            开发者发送的消息如果有请求自己服务器的资源，可以考虑此参数。
            /// </summary>
            [JsonProperty(PropertyName = "max_send_num", NullValueHandling = NullValueHandling.Ignore)]
            public string MaxSendNum { get; set; }
            /// <summary>
            /// 可选 开发者对消息的唯一标识，服务器会根据这个标识避免重复发送。
            ///            有些情况下（例如网络异常）开发者可能会重复调用API导致
            ///            消息多次下发到客户端。如果需要处理这种情况，可以考虑此参数。
            ///            注意, out_biz_no只对任务生效。
            /// </summary>
            [JsonProperty(PropertyName = "apns-collapse-id", NullValueHandling = NullValueHandling.Ignore)]
            public string ApnsCollapseId { get; set; }
            /*
                        public JObject ToObject()
                        {
                            var obj = new JObject();
                            obj["start_time"] = StartTime?.ToString("yyyy-MM-dd HH:mm:ss");
                            obj["expire_time"] = ExpireTime?.ToString("yyyy-MM-dd HH:mm:ss");
                            obj["max_send_num"] = MaxSendNum;
                            obj["apns-collapse-id"] = ApnsCollapseId;
                            return obj;
                            //return obj.ToObject<object>();
                        }*/
        }
        #endregion


    }
}
