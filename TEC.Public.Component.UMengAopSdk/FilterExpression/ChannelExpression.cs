﻿/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk.FilterExpression
// 类名：AppVersionExpression
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/13 14:54:49 TEC-ROCLEE Roc.Lee

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
    /// 筛选字段：渠道
    /// </summary>
    public class ChannelExpression : ExpressionBase
    {

        public ChannelExpression(OperationEnum opreation, params string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("value", "缺少参数");
            }
            switch (opreation)
            {
                case OperationEnum.Yes:
                    this["or"] = BuildYes(value);
                    break;
                case OperationEnum.No:
                    this["and"] = BuildNo(value);
                    break;
                default:
                    break;
            }
        }
        private const string KEY = "channel";
        private JToken BuildYes(string[] value)
        {
            var arr = new List<JProperty>();
            foreach (var item in value)
            {
                arr.Add(new JProperty(KEY, item));
            }
            return new JObject(arr);
        }
        private JToken BuildNo(string[] value)
        {
            var arr = new List<JProperty>();
            foreach (var item in value)
            {
                arr.Add(new JProperty("not", new JProperty(KEY, item)));
            }
            return new JObject(arr);
        }
        public enum OperationEnum
        {
            Yes,
            No,
        }
    }
}
