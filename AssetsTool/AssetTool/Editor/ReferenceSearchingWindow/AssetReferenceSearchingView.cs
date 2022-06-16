using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

namespace AssetTool
{
    public class AssetReferenceSearchingView : AssetTreeView
    {
        private AssetReferenceSearchingModel model;

        public AssetReferenceSearchingView(TreeViewState state, MultiColumnHeader multiColumnHeader, AssetTreeModel model) : base(state, multiColumnHeader, model)
        {
            this.model = model as AssetReferenceSearchingModel;
        }

        protected override void CellGUI(Rect cellRect, AssetTreeViewItem<AssetTreeModel.AssetInfo> item, int column, ref RowGUIArgs args)
        {
            var info = item.data;
            switch (column)
            {
                case 0:
                    DefaultGUI.FoldoutLabel(cellRect, info.displayName, args.selected, args.focused);
                    break;
                case 1:
                    DrawItemWithIcon(cellRect, item, ref args, info.displayName, info.fileRelativePath, info.deleted, info.added, false, true);
                    break;
                case 2:
                    DefaultGUI.FoldoutLabel(cellRect, info.fileRelativePath, args.selected, args.focused);
                    break;
            }
        }

        private void OnReferenceSearchingItem(AssetTreeModel.AssetInfo info)
        {
            if (info.isFolder)
            {
                return;
            }
        }
    }
}
