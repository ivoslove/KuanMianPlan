using System;
using System.CodeDom;
using System.Collections.Generic;
using App.Component;
using UnityEngine;

public class DocumentComponent : BaseComponent
{

    public class Document<T> : ScriptableObject where T : struct
    {
        [SerializeField]
        public List<T> DocumentItems = new List<T>();
    }

}
