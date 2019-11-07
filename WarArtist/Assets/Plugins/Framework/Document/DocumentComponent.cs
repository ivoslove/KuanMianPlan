using System;
using System.Collections.Generic;
using System.Reflection;
using App.Document;
using UnityEngine;

namespace App.Component
{
    public class DocumentComponent : BaseComponent
    {
        #region class

        public class Document<T> : ScriptableObject where T : struct
        {
            [SerializeField]
            public List<T> DocumentItems = new List<T>();
        }

        #endregion

        #region public funcs

        public string GetAssetPath(Type type)
        {
            var members = type.GetMembers();

            foreach (var member in members)
            {
                var documentTableAttribute = member.GetCustomAttribute<DocumentTableAttribute>();
                if (documentTableAttribute != null)
                {
                    return $"DocumentAssets/{documentTableAttribute.DocumentName}";
                }
            }

            return "";
        }

        #endregion

    }

}

