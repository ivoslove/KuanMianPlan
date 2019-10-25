using System;
using System.Collections.Generic;
using App.Dispatch;
using App.Document.Attribute;
using UnityEngine;

namespace App.Component
{
    /// <summary>
    /// 多语言组件
    /// </summary>
    public class LanguageComponent : BaseComponent
    {
        public LanguageProxy Proxy { get; set; }

        public LanguageComponent()
        {
            var documentComponent = new DocumentComponent();
            var assetPath = documentComponent.GetAssetPath(GetType());
            if (!string.IsNullOrEmpty(assetPath))
            {
                Proxy = Resources.Load<LanguageProxy>(assetPath);
            }
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

        /// <summary>
        /// 多语言属性
        /// </summary>
        [DocumentTable("Language")]
        public class LanguageProxy : DocumentComponent.Document<LanguageTable>
        {
            
        }
    }
}
