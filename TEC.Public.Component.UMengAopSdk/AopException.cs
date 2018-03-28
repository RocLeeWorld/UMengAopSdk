/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.UMengAopSdk
// 类名：AopException
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/6 11:17:14 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TEC.Public.Component.UMengAopSdk
{
    /// <summary>
    /// AOP客户端异常。
    /// </summary>
    public class AopException : Exception
    {
        private string errorCode;
        private string errorMsg;

        public AopException()
            : base()
        {
        }

        public AopException(string message)
            : base(message)
        {
        }

        protected AopException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AopException(string errorCode, string errorMsg)
            : base(errorCode + ":" + errorMsg)
        {
            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
        }

        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        public string ErrorMsg
        {
            get { return this.errorMsg; }
        }
    }
}
