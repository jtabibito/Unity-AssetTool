using System;
using UnityEditor;

namespace AssetTool
{
    public class AssetToolWatcher : AssetPostprocessor
    {
        public static event Action<string[]> onImportedAssets;
        public static event Action<string[]> onDeletedAssets;
        public static event Action<string[], string[]> onMovedAssets;

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (importedAssets.Length > 0 && onImportedAssets != null)
            {
                onImportedAssets(importedAssets);
            }

            if (deletedAssets.Length > 0 && onDeletedAssets != null)
            {
                onDeletedAssets(deletedAssets);
            }

            if (movedAssets.Length > 0 && onMovedAssets != null)
            {
                onMovedAssets(movedFromAssetPaths, movedAssets);
            }
        }
    }
}