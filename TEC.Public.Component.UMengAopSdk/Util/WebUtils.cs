/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：WebUtils
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/6 11:17:14 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using TEC.Public.Component.UMengAopSdk.Util;

namespace TEC.Public.Component.UMengAopSdk.Util
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        //private int _timeout = 100000;

        ///// <summary>
        ///// 请求与响应的超时时间
        ///// </summary>
        //public int Timeout
        //{
        //    get { return this._timeout; }
        //    set { this._timeout = value; }
        //}

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="charset">编码字符集</param>
        /// <returns>HTTP响应</returns>
        public static WebResponseResult<T> DoPost<T>(string url, string json, int timeout=5000)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(json);
            // Console.Write(Encoding.UTF8.GetString(dataArray));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            request.ReadWriteTimeout = timeout;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = dataArray.Length;
            //request.CookieContainer = cookie;

            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String res = reader.ReadToEnd();
                reader.Close();
                //Console.Write("\nResponse Content:\n" + res + "\n");
                return new WebResponseResult<T>((int)response.StatusCode, res);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine(e);
                    if (response == null)
                    {
                        return new WebResponseResult<T>(-1, e.ToString());
                    }
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        // Console.WriteLine(text);
                        return new WebResponseResult<T>((int)httpResponse.StatusCode, text, e);
                    }
                }
            }

        }

    }
}
