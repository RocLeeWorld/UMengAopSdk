/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：DefaultAopClient
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/6 11:09:50 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TEC.Public.Component.UMengAopSdk.Request;
using TEC.Public.Component.UMengAopSdk.Util;
using System.Web.Security;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TEC.Public.Component.UMengAopSdk
{
    /// <summary>
    /// AOP客户端。
    /// </summary>
    public class DefaultAopClient : IAopClient
    {
        private string serverUrl;
        private string appkey;
        private WebUtils webUtils;
        private string app_master_secret;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="appkey"></param>
        /// <param name="app_master_secret"></param>
        public DefaultAopClient(string serverUrl, string appkey, string app_master_secret)
        {
            this.appkey = appkey;
            this.serverUrl = serverUrl;
            this.webUtils = new WebUtils();
            this.app_master_secret = app_master_secret;

        }
        public WebResponseResult<T> Execute<T, M>(IAopRequest<T, M> request) where T : AopResponse<M>
        {
            ////var timestamp = GetTimeStamp().ToString();
            //string url = this.serverUrl.TrimEnd('/') + request.GetApiPath();
            //string postBody = BuildPostBody(JObject.FromObject(request));
            //var response = WebUtils.DoPost<T>(BuildUrl(url, postBody), postBody);
            //return response;
            return Execute<T, M>(JObject.FromObject(request), request.GetApiPath());
        }
        public WebResponseResult<T> Execute<T, M>(JObject requestJson, string apipath) where T : AopResponse<M>
        {
            string url = this.serverUrl.TrimEnd('/') + apipath;
            string postBody = BuildPostBody(requestJson);
            var response = WebUtils.DoPost<T>(BuildUrl(url, postBody), postBody);
            return response;
        }
        private string BuildPostBody(JObject jobject)
        {
            jobject["appkey"] = this.appkey;
            jobject["timestamp"] = GetTimeStamp().ToString();
            return JsonConvert.SerializeObject(jobject);
        }
        private string BuildUrl(string url, string postBody)
        {
            string timestamp = DateTime.Now.Ticks.ToString();
            string sign = GenerateMD5("POST" + url + postBody + app_master_secret);
            return url + "?sign=" + sign;
        }
        private uint GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToUInt32(ts.TotalSeconds);
        }
        /// <summary>
        /// 生成MD5加密摘要
        /// </summary>
        /// <param name="strOriginal">字符串数据源</param>
        /// <returns>MD5加密后</returns>
        private string GenerateMD5(string strOriginal)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] btemp = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(strOriginal));
            ////把加密后的字节转换成精度2的十六进制数据
            //StringBuilder ret = new StringBuilder();
            //foreach (byte b in btemp)
            //{
            //    ret.AppendFormat("{0:X2}", b);
            //}
            //return ret.ToString();
            return BitConverter.ToString(btemp).Replace("-", "").ToLower();
        }
    }
}
