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
using Newtonsoft.Json.Converters;
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
    public class AndroidPushRequest : IAopRequest<AndroidPushResponse, AndroidPushResponse.DataModel>
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
        /// true/false 可选 正式/测试模式。测试模式下，只会将消息发给测试设备。
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
        /// <summary>
        /// 可选，默认为false。当为true时，表示MIUI、EMUI、Flyme系统设备离线转为系统下发
        /// </summary>
        [JsonProperty(PropertyName = "mipush", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MIPush { get; set; }
        /// <summary>
        ///  可选，mipush值为true时生效，表示走系统通道时打开指定页面acitivity的完整包路径。
        /// </summary>
        [JsonProperty(PropertyName = "mi_activity", NullValueHandling = NullValueHandling.Ignore)]
        public string MIActivity { get; set; }
        #endregion

        [JsonIgnore]
        private const string APIPATH = "/api/send";
        public string GetApiPath()
        {
            return APIPATH;
        }
        public string ToJSON(string appkey, string timestamp)
        {
            JObject jobject = JObject.FromObject(this);
            jobject["appkey"] = appkey;
            jobject["timestamp"] = timestamp;
            //jobject["type"] = PushType.ToString().ToLower();
            //jobject["filter"] = Filter.ToObject();
            //jobject["payload"] = Payload.ToObject();
            //jobject["policy"] = Policy.ToObject();
            return JsonConvert.SerializeObject(jobject);
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

        #region PayloadModel
        //public enum ExpressionLogicEnmu
        //{
        //    AND, OR, NOT
        //}
        [Serializable]
        public class PayloadModel //: IJsonObject
        {
            /// <summary>
            /// 必填 消息类型
            /// </summary>
            [JsonProperty(PropertyName = "display_type", Required = Required.Always), JsonConverter(typeof(RequestStringEnumConverter))]
            public DisplayTypeEnum DisplayType { get; set; } = DisplayTypeEnum.Notification;
            /// <summary>
            /// 必填 消息体。
            /// display_type=message时,body的内容只需填写custom字段。
            /// display_type=notification时, body包含如下参数:
            /// </summary>
            [JsonProperty(PropertyName = "body", Required = Required.Always)]
            public BodyModel Body { get; set; }
            /// <summary>
            /// 可选 用户自定义key-value。只对"通知"
            ///                      (display_type=notification)生效。
            ///                     可以配合通知到达后,打开App,打开URL,打开Activity使用。
            /// </summary>
            [JsonProperty(PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
            public JObject Extra { get; set; }
            /*
            public JObject ToObject()
            {
                var jobject = JObject.FromObject(this);
                jobject["display_type"] = DisplayType.ToString().ToLower();
                jobject["body"] = Body.ToObject();
                return jobject;

                //return new { display_type = DisplayType.ToString().ToLower(), body = Body.ToObject(), extra = Extra };
            }*/

            [Serializable]
            /// <summary>
            /// 消息类型
            /// </summary>
            public enum DisplayTypeEnum
            {
                /// <summary>
                /// 通知
                /// </summary>
                [Description("notification")]
                Notification,
                /// <summary>
                /// 消息 body的内容只需填写custom字段。
                /// </summary>
                [Description("message")]
                Message
            }
            [Serializable]
            public class BodyModel //: IJsonObject
            {
                /// <summary>
                /// 必填 通知栏提示文字
                /// </summary>
                [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
                public string Ticker { get; set; } = "必填 通知栏提示文字";
                /// <summary>
                /// 必填 通知标题
                /// </summary>
                [JsonProperty(PropertyName = "title", Required = Required.Always)]
                public string Title { get; set; } = "必填 通知标题";
                /// <summary>
                /// 必填 通知文字描述 
                /// </summary>
                [JsonProperty(PropertyName = "text", Required = Required.Always)]
                public string Text { get; set; } = "必填 通知文字描述 ";
                #region 自定义通知图标
                /// <summary>
                /// 可选 状态栏图标ID, R.drawable.[smallIcon],
                /// 如果没有, 默认使用应用图标。
                ///                    图片要求为24*24dp的图标,或24*24px放在drawable-mdpi下。
                ///                    注意四周各留1个dp的空白像素
                /// </summary>
                [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
                public string Icon { get; set; }
                /// <summary>
                /// 可选 通知栏拉开后左侧图标ID, R.drawable.[largeIcon].
                /// 图片要求为64*64dp的图标,
                ///                     可设计一张64*64px放在drawable-mdpi下,
                ///                      注意图片四周留空，不至于显示太拥挤
                /// </summary>
                [JsonProperty(PropertyName = "largeIcon", NullValueHandling = NullValueHandling.Ignore)]
                public string LargeIcon { get; set; }
                /// <summary>
                /// 可选 通知栏大图标的URL链接。该字段的优先级大于largeIcon。
                ///   该字段要求以http或者https开头。
                /// </summary>
                [JsonProperty(PropertyName = "img", NullValueHandling = NullValueHandling.Ignore)]
                public string Img { get; set; }
                #endregion

                #region 自定义通知声音
                /// <summary>
                /// 可选 通知声音，R.raw.[sound]. 
                ///  如果该字段为空，采用SDK默认的声音, 即res/raw/下的
                ///   umeng_push_notification_default_sound声音文件
                ///   如果SDK默认声音文件不存在，
                ///   则使用系统默认的Notification提示音。
                /// </summary>
                [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
                public string Sound { get; set; }
                #endregion

                #region 自定义通知样式
                /// <summary>
                /// 可选 默认为0，用于标识该通知采用的样式。使用该参数时, 
                /// 开发者必须在SDK里面实现自定义通知栏样式。
                /// </summary>
                [JsonProperty(PropertyName = "builder_id", NullValueHandling = NullValueHandling.Ignore)]
                public string BuilderId { get; set; }
                #endregion

                #region 通知到达设备后的提醒方式
                /// <summary>
                /// 可选 收到通知是否震动,默认为"true".                注意，"true/false"为字符串
                /// </summary>
                [JsonProperty(PropertyName = "play_vibrate", NullValueHandling = NullValueHandling.Ignore)]
                public bool? PlayVibrate { get; set; }

                /// <summary>
                /// 可选 收到通知是否闪灯,默认为"true"
                /// </summary>
                [JsonProperty(PropertyName = "play_lights", NullValueHandling = NullValueHandling.Ignore)]
                public bool? PlayLights { get; set; }


                /// <summary>
                /// 可选 收到通知是否发出声音,默认为"true"
                /// </summary>
                [JsonProperty(PropertyName = "play_sound", NullValueHandling = NullValueHandling.Ignore)]
                public bool? PlaySound { get; set; }
                #endregion


                #region 点击"通知"的后续行为，默认为打开app。
                /// <summary>
                /// 必填 值可以为:
                ///                    "go_app": 打开应用
                ///                    "go_url": 跳转到URL
                ///                    "go_activity": 打开特定的activity
                ///                    "go_custom": 用户自定义内容。
                /// </summary>
                [JsonProperty(PropertyName = "after_open", Required = Required.Always), JsonConverter(typeof(RequestStringEnumConverter))]
                public AfterOpenEnum AfterOpen { get; set; } = AfterOpenEnum.Go_App;

                /// <summary>
                /// 可选 当"after_open"为"go_url"时，必填。
                ///通知栏点击后跳转的URL，要求以http或者https开头
                /// </summary>
                [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
                public string Url { get; set; }

                /// <summary>
                /// 可选 当"after_open"为"go_activity"时，必填。
                ///通知栏点击后打开的Activity
                /// </summary>
                [JsonProperty(PropertyName = "activity", NullValueHandling = NullValueHandling.Ignore)]
                public string Activity { get; set; }

                /// <summary>
                /// 可选 display_type=message, 或者
                ///   display_type=notification且
                ///                       "after_open"为"go_custom"时，
                ///    该字段必填。用户自定义内容, 可以为字符串或者JSON格式。
                /// </summary>
                [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
                public object Custom { get; set; }
                #endregion
                /*
                public JObject ToObject()
                {
                    return JObject.FromObject(this);
                }
                */
                /// <summary>
                /// 点击"通知"的后续行为
                /// </summary>
                [Serializable]

                public enum AfterOpenEnum
                {
                    /// <summary>
                    /// 打开应用
                    /// </summary>
                    Go_App,
                    /// <summary>
                    /// 跳转到URL
                    /// </summary>
                    Go_Url,
                    /// <summary>
                    /// 打开特定的activity
                    /// </summary>
                    Go_Activity,
                    /// <summary>
                    /// 用户自定义内容
                    /// </summary>
                    Go_Custom
                }

            }


        }
        #endregion

        #region PolicyModel
        /// <summary>
        /// 可选 发送策略
        /// </summary>
        [Serializable]
        public class PolicyModel// : IJsonObject
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
            [JsonProperty(PropertyName = "out_biz_no", NullValueHandling = NullValueHandling.Ignore)]
            public string OutBizNo { get; set; }

            /*
            public JObject ToObject()
            {
                var jobject = JObject.FromObject(this);
                jobject["start_time"] = StartTime?.ToString("yyyy-MM-dd HH:mm:ss");
                jobject["expire_time"] = ExpireTime?.ToString("yyyy-MM-dd HH:mm:ss");
                return jobject;
                //return new
                //{
                //    start_time = StartTime?.ToString("yyyy-MM-dd HH:mm:ss"),
                //    expire_time = ExpireTime?.ToString("yyyy-MM-dd HH:mm:ss"),
                //    max_send_num = MaxSendNum,
                //    out_biz_no = OutBizNo
                //};
            }*/
        }
        #endregion


    }
}
