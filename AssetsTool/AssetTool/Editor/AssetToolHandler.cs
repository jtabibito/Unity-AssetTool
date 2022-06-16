using System;
using System.Collections.Generic;
using UnityEditor;

namespace AssetTool
{
    public class AssetToolHandler
    {
        public static Action<GenericMenu> onDependenciesContextDraw;

        public static Action<string> onDependenciesFindItem;

        public static Action<string, List<AssetTreeModel.AssetInfo>, AssetTreeModel> onDependenciesLoadDataMore;
    }
}