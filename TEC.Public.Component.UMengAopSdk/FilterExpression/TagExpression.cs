/*----------------------------------------------------------------
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
    /// 筛选字段：用户标签
    /// </summary>
    public class TagExpression : ExpressionBase
    {
               
        public TagExpression(OperationEnum operation, LogicEnum logic, params string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("value", "缺少参数");
            }
            switch (operation)
            {
                case OperationEnum.Yes:
                    switch (logic)
                    {
                        case LogicEnum.Or:
                            this["or"] = BuildYes(value);
                            break;
                        case LogicEnum.And:
                            this["and"] = BuildYes(value);
                            break;
                        default:
                            break;
                    }
                    break;
                case OperationEnum.No:
                    switch (logic)
                    {
                        case LogicEnum.Or:
                            this["and"] = BuildNo(value);
                            break;
                        case LogicEnum.And:
                            this["or"] = BuildNo(value);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        private const string KEY = "tag";
        private JToken BuildYes(string[] ver)
        {
            var arr = new List<JProperty>();
            foreach (var item in ver)
            {
                arr.Add(new JProperty(KEY, item));
            }
            return new JObject(arr);
        }
        private JToken BuildNo(string[] ver)
        {
            var arr = new List<JProperty>();
            foreach (var item in ver)
            {
                arr.Add(new JProperty("not", new JProperty(KEY, item)));
            }
            return new JObject(arr);
        }

        public enum LogicEnum
        {
            Or,
            And
        }
        public enum OperationEnum
        {
            Yes,
            No,

        }
    }
}
