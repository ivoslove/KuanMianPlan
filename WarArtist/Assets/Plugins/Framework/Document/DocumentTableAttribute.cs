
using System;

namespace App.Document
{
    /// <summary>
    /// 文档表标签,标识该文档需要生产.Asset文件
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public sealed class DocumentTableAttribute : System.Attribute
    {
        public string DocumentName { get; set; }

        public DocumentTableAttribute(string documentName)
        {
            DocumentName = documentName;
        }
    }
}

