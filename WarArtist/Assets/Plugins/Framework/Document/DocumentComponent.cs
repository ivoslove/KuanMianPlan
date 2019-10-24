using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Component;
using App.Document.Attribute;
using UnityEngine;

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
            if (documentTableAttribute!=null)
            {
                return $"DocumentAssets/{documentTableAttribute.DocumentName}";
            }
        }

        return "";
    }

    #endregion


}
