using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace AssetTool
{
    /// <summary>
    /// 查找引用
    /// </summary>
    public class AssetReferenceSearchingWindow : AssetBaseWindow
    {
        private bool m_FilterEmpty;

        private List<Object> result = new List<Object>();
        private string label;

        private void Awake()
        {
            titleContent = AssetToolStyle.Get().searchReferenceTitle;
            minSize = new Vector2(727f, 331f);
        }

        protected override void InitTree(MultiColumnHeader multiColumnHeader)
        {
            m_FilterEmpty = false;
            m_AssetTreeModel = new AssetReferenceSearchingModel();
            m_AssetTreeView = new AssetReferenceSearchingView(m_TreeViewState, multiColumnHeader, m_AssetTreeModel);
        }

        protected override void DrawGUI(GUIContent waiting, GUIContent nothing, bool expandCollapseComplex)
        {
            base.DrawGUI(AssetToolStyle.Get().searchReferenceWaiting, AssetToolStyle.Get().searchReferenceNothing, true);
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
                    headerContent = AssetToolStyle.Get().searchReferenceHeaderContent2,
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    width = 350,
                    minWidth = 100,
                    autoResize = false,
                    allowToggleVisibility = true
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = AssetToolStyle.Get().dependenciesHeaderContent2,
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    width = 350,
                    minWidth = 100,
                    autoResize = false,
                    allowToggleVisibility = true
                }
            };

            return new MultiColumnHeaderState(columns);
        }

        protected override void DrawToolbarMore()
        {
            EditorGUI.BeginChangeCheck();
            m_FilterEmpty = GUILayout.Toggle(m_FilterEmpty, AssetToolStyle.Get().dependenciesFilter, EditorStyles.toolbarButton,
                GUILayout.Width(70f));
            if (EditorGUI.EndChangeCheck() && m_AssetTreeView != null)
            {
                // (m_AssetTreeView as AssetReferenceSearchingView).SetFilterEmpty(m_FilterEmpty);
            }
        }
        
    }
}
