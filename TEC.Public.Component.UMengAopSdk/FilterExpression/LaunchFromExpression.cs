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
    /// 筛选字段：一段时间内活跃/一段时间内不活跃
    /// </summary>
    public class LaunchFromExpression : ExpressionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="date">小于发送日期的日期点 年-月-日</param>
        public LaunchFromExpression(OperationEnum operation, DateTime date)
        {
            switch (operation)
            {
                case OperationEnum.Yes:
                    this[KEY] = new JValue(date.ToString("yyyy-MM-dd"));
                    break;
                case OperationEnum.No:
                    this[KEY_NOT] = new JValue(date.ToString("yyyy-MM-dd"));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="days">活跃天数</param>
        public LaunchFromExpression(OperationEnum operation, int days)
        {

            switch (operation)
            {
                case OperationEnum.Yes:
                    this[KEY] = new JValue(DateTime.Now.AddDays(-Math.Abs(days)).ToString("yyyy-MM-dd"));
                    break;
                case OperationEnum.No:
                    this[KEY_NOT] = new JValue(DateTime.Now.AddDays(-Math.Abs(days)).ToString("yyyy-MM-dd"));
                    break;
                default:
                    break;
            }
        }
        private const string KEY = "launch_from";
        private const string KEY_NOT = "not_launch_from";

        public enum OperationEnum
        {
            /// <summary>
            /// 活跃
            /// </summary>
            Yes,
            /// <summary>
            /// 不活跃
            /// </summary>
            No,

        }
    }
}
