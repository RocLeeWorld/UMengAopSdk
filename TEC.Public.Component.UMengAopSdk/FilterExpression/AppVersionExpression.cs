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
    /// 筛选字段：应用版本
    /// </summary>
    public class AppVersionExpression : ExpressionBase
    {
        //       {          
        //          "or": [
        //              {
        //                  "app_version": ">1"
        //               }
        //          ]
        //       }

        //      {
        //          "or": [
        //              {
        //                  "app_version": "1"
        //              },
        //              {
        //                  "app_version": "5"
        //              }
        //          ]
        //      }

        //      {
        //           "and": [
        //               {
        //                   "not": {
        //                       "app_version": "1"
        //                   }
        //             },
        //               {
        //                   "not": {
        //                       "app_version": "5"
        //                   }
        //               }
        //           ]
        //      }   

        public AppVersionExpression(OperationEnum operation, params string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("values", "缺少参数");
            }
            switch (operation)
            {
                case OperationEnum.Yes:
                    this["or"] = BuildYes(value);
                    break;
                case OperationEnum.No:
                    this["and"] = BuildNo(value);
                    break;
                case OperationEnum.GreaterEqual:
                    this["or"] = BuildGreaterEqual(value);
                    break;
                case OperationEnum.LessEqual:
                    this["or"] = BuildLessEqual(value);
                    break;
                default:
                    break;
            }
        }
        private const string KEY = "app_version";
        private JToken BuildYes(string[] values)
        {
            var arr = new List<JProperty>();
            foreach (var item in values)
            {
                arr.Add(new JProperty(KEY, item));
            }
            return new JObject(arr);
        }
        private JToken BuildNo(string[] values)
        {
            var arr = new List<JProperty>();
            foreach (var item in values)
            {
                arr.Add(new JProperty("not", new JProperty(KEY, item)));
            }
            return new JObject(arr);
        }
        private JToken BuildGreaterEqual(string[] values)
        {
            var arr = new List<JProperty>();
            foreach (var item in values)
            {
                arr.Add(new JProperty(KEY, $">={item}"));
                //break;
            }
            return new JObject(arr);
        }
        private JToken BuildLessEqual(string[] values)
        {
            var arr = new List<JProperty>();
            foreach (var item in values)
            {
                arr.Add(new JProperty(KEY, $"<={item}"));
                //break;
            }
            return new JObject(arr);
        }
        public enum OperationEnum
        {
            Yes,
            No,
            GreaterEqual,
            LessEqual
        }
    }
}
