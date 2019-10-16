using System;
using System.Collections.Generic;
using App.Document.Attribute;
using UnityEngine;

namespace App.Component
{

    /// <summary>
    /// 多语言属性
    /// </summary>
    [DocumentTable("Language")]
    //public class LanguageComponent : DocumentComponent<LanguageComponent.LanguageData>
    //{

    //    [Serializable]
    //    public class LanguageData
    //    {
    //        /// <summary>
    //        /// 唯一标识符
    //        /// </summary>
    //        public string Id { get; set; }

    //        /// <summary>
    //        /// 中文
    //        /// </summary>
    //        public string Chinese { get; set; }

    //        /// <summary>
    //        /// 英文
    //        /// </summary>
    //        public string English { get; set; }
    //    }

    //    //[Serializable]
    //    //[DocumentTable("Language")]
    //    //public class LanguageData :ScriptableObject
    //    //{
    //    //    /// <summary>
    //    //    /// 唯一标识符
    //    //    /// </summary>
    //    //    public string Id { get; set; }

    //    //    /// <summary>
    //    //    /// 中文
    //    //    /// </summary>
    //    //    public string Chinese { get; set; }

    //    //    /// <summary>
    //    //    /// 英文
    //    //    /// </summary>
    //    //    public string English { get; set; }
    //    //}

    //    //private List<LanguageData> _languages;

    //}

    public class LanguageComponent : BaseComponent
    {
        public LanguageProxy Proxy { get; set; }

        public LanguageComponent()
        {
            Proxy  = ScriptableObject.CreateInstance<LanguageProxy>();
            Debug.Log(Proxy);
        }

        [Serializable]
        public struct LanguageTable
        {
            /// <summary>
            /// 唯一标识符
            /// </summary>
            public string Id;

            /// <summary>
            /// 中文
            /// </summary>
            public string Chinese;

            /// <summary>
            /// 英文
            /// </summary>
            public string English;
        }

        public class LanguageProxy : DocumentComponent.Document<LanguageTable>
        {
            
        }
    }
}
