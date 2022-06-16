﻿using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace AssetTool
{
    public class AssetReferenceWindow : AssetBaseWindow
    {
        private void Awake()
        {
            titleContent = AssetToolStyle.Get().referenceTitle;
            minSize = new Vector2(727f, 331f);
        }

        protected override void InitTree(MultiColumnHeader multiColumnHeader)
        {
            m_AssetTreeModel = new AssetReferenceTreeModel();
            m_AssetTreeView = new AssetReferenceTreeView(m_TreeViewState, multiColumnHeader, m_AssetTreeModel);
        }

        protected override void DrawGUI(GUIContent waiting, GUIContent nothing, bool expandCollapseComplex)
        {
            base.DrawGUI(AssetToolStyle.Get().referenceWaiting, AssetToolStyle.Get().referenceNothing, true);
        }

        protected override MultiColumnHeaderState CreateMultiColumnHeader()
        {
            var columns = new[]
            {
                new MultiColumnHeaderState.Column
                {
                    headerContent = AssetToolStyle.Get().nameHeaderContent,
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    sortingArrowAlignment = TextAlignment.Right,
                    width = 280,
                    minWidth = 150,
                    autoResize = false,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = AssetToolStyle.Get().referenceHeaderContent2,
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    width = 300,
                    minWidth = 100,
                    autoResize = false,
                    allowToggleVisibility = true
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = AssetToolStyle.Get().referenceHeaderContent3,
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    width = 100,
                    minWidth = 100,
                    autoResize = false,
                    allowToggleVisibility = true
                }
            };

            return new MultiColumnHeaderState(columns);
        }
    }
}