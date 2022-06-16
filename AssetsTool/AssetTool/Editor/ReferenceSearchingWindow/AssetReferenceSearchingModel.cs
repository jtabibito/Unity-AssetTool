using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AssetTool
{
    public class AssetReferenceSearchingModel : AssetTreeModel
    {
        public override void SetObject(Object _object)
        {
            base.SetObject(_object);

            string guid = AssetDatabase.AssetPathToGUID(data.fileRelativePath);
            string[] search_data = AssetDatabase.FindAssets("t:prefab t:script", new[] { "Assets" });

            for (int i = 0; i < search_data.Length; ++i)
            {
                string path = AssetDatabase.GUIDToAssetPath(search_data[i]);

                EditorUtility.DisplayProgressBar("查找引用", path, (float)i / (float)search_data.Length);

                string content = System.IO.File.ReadAllText(path);
                if (content.Contains(guid))
                {
                    var mem_obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
                    var asset_info = new AssetInfo(mem_obj.GetHashCode(), AssetDatabase.GetAssetPath(mem_obj), mem_obj.name);
                    asset_info.bindObj = mem_obj;
                    data.AddChild(asset_info);
                }
            }
            EditorUtility.ClearProgressBar();
        }
    }
}
