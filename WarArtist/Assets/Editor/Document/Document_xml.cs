using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using App.Document;
using UnityEditor;
using UnityEngine;

namespace App.Editor.Document
{
    public class Document_xml : AssetPostprocessor
    {
        private static readonly string _loadAssembly = @"Assembly-CSharp"; //加载程序集

        private static readonly string
            _assetFileFoldelPath = @"Assets/Sources/Resources/DocumentAssets/"; //.Asset文件存放文件夹

        /// <summary>
        /// 在一些资源被导入后调用(当资源进度条到达末端)
        /// </summary>
        /// <param name="importedAssets">导入文件集</param>
        /// <param name="deletedAssets">删除文件集</param>
        /// <param name="movedAssets">移动文件集</param>
        /// <param name="movedFromPath"></param>
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets,
            string[] movedAssets, string[] movedFromPath)
        {
            GenerateAssets(importedAssets);
        }

        private static void GenerateAssets(string[] assets)
        {
            if (assets == null || assets.Length ==0)
            {
                return;
            }

            //这个方法还能优化...  现在只是艰难的完成了它的任务...
            var tuples = Assembly.Load(_loadAssembly).GetTypes().ToList()
                .FindAll(t => t.GetCustomAttribute<DocumentTableAttribute>() != null).Select(p =>
                    new Tuple<string, Type>(p.GetCustomAttribute<DocumentTableAttribute>().DocumentName, p)).ToList();

            foreach (var p in assets.ToList())
            {
                var documentName = GetDocumentName(p);
                var tuple = tuples.FirstOrDefault(t => t.Item1.Equals(documentName));
                if (tuple?.Item2.GetCustomAttribute<DocumentTableAttribute>() == null)
                {
                    continue;
                }
                var file = File.ReadAllText(p);
                XmlSpreadSheetReader.ReadSheet(file);
                var sheet = XmlSpreadSheetReader.Output;

                if (!sheet.ContainsKey("Id"))
                {
                    continue;
                }
                var idCount = sheet["Id"].Length;
               
                var proxy = ScriptableObject.CreateInstance(tuple.Item2);
                AssetDatabase.CreateAsset(proxy as UnityEngine.Object, _assetFileFoldelPath + tuple.Item1 + ".asset");
                var documentItems = proxy.GetType().GetField("DocumentItems");
                var list = Activator.CreateInstance(documentItems.FieldType);
                var add = list.GetType().GetMethod("Add");
                var argument = documentItems.FieldType.GetGenericArguments()[0];
                for (int i = 1; i < idCount; i++)
                {
                    var item = Activator.CreateInstance(argument);
                    var properties = item.GetType().GetFields();
                    foreach (var t in properties)
                    {
                        var name = t.Name;
                        var itemType = t.FieldType;
                        var sheetItem = sheet[name];
                        if (sheetItem == null)
                        {
                            continue;
                        }

                        var c = TypeDescriptor.GetConverter(itemType);
                        var value = c.ConvertFromString(sheetItem[i].ToString());

                        t.SetValue(item, value);
                    }

                    add?.Invoke(list, new[] { item });
                }
                documentItems.SetValue(proxy, list);
            }
        }

        private static string GetDocumentName(string assetPath)
        {
            var document = assetPath.Split('/').Last();
            return document.Replace(".xml", string.Empty);
        }
    }
}