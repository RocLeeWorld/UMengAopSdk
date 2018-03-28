/*----------------------------------------------------------------
// Copyright (C) 2016 通通优品版权所有。
// 命名空间: TEC.Public.Component.Push
// 类名：FileItem
// 功能描述：N/A
// 
// 创建标识：Roc.Lee(李鹏鹏) 2017/3/6 11:17:14 TEC-ROCLEE Roc.Lee

// 修改标识：
// 修改描述：
// 
//
//----------------------------------------------------------------*/
using System;
using System.IO;

namespace TEC.Public.Component.Push.Util
{
    /// <summary>
    /// 文件元数据。
    /// 可以使用以下几种构造方法：
    /// 本地路径：new FileItem("C:/temp.jpg");
    /// 本地文件：new FileItem(new FileInfo("C:/temp.jpg"));
    /// 字节流：new FileItem("abc.jpg", bytes);
    /// </summary>
    public class FileItem
    {
        private string fileName;
        private string mimeType;
        private byte[] content;
        private FileInfo fileInfo;

        /// <summary>
        /// 基于本地文件的构造器。
        /// </summary>
        /// <param name="fileInfo">本地文件</param>
        public FileItem(FileInfo fileInfo)
        {
            if (fileInfo == null || !fileInfo.Exists)
            {
                throw new ArgumentException("fileInfo is null or not exists!");
            }
            this.fileInfo = fileInfo;
        }

        /// <summary>
        /// 基于本地文件全路径的构造器。
        /// </summary>
        /// <param name="filePath">本地文件全路径</param>
        public FileItem(string filePath)
            : this(new FileInfo(filePath))
        { }

        /// <summary>
        /// 基于文件名和字节流的构造器。
        /// </summary>
        /// <param name="fileName">文件名称（服务端持久化字节流到磁盘时的文件名）</param>
        /// <param name="content">文件字节流</param>
        public FileItem(string fileName, byte[] content)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName");
            if (content == null || content.Length == 0) throw new ArgumentNullException("content");

            this.fileName = fileName;
            this.content = content;
        }

        /// <summary>
        /// 基于文件名、字节流和媒体类型的构造器。
        /// </summary>
        /// <param name="fileName">文件名（服务端持久化字节流到磁盘时的文件名）</param>
        /// <param name="content">文件字节流</param>
        /// <param name="mimeType">媒体类型</param>
        public FileItem(String fileName, byte[] content, String mimeType)
            : this(fileName, content)
        {
            if (string.IsNullOrEmpty(mimeType)) throw new ArgumentNullException("mimeType");
            this.mimeType = mimeType;
        }

        public string GetFileName()
        {
            if (this.fileName == null && this.fileInfo != null && this.fileInfo.Exists)
            {
                this.fileName = this.fileInfo.FullName;
            }
            return this.fileName;
        }

        public string GetMimeType()
        {
            if (this.mimeType == null)
            {
                this.mimeType = AopUtils.GetMimeType(GetContent());
            }
            return this.mimeType;
        }

        public byte[] GetContent()
        {
            if (this.content == null && this.fileInfo != null && this.fileInfo.Exists)
            {
                using (Stream fileStream = this.fileInfo.OpenRead())
                {
                    this.content = new byte[fileStream.Length];
                    fileStream.Read(content, 0, content.Length);
                }
            }

            return this.content;
        }
    }
}