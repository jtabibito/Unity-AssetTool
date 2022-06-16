using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetTool
{
	//[CreateAssetMenu (fileName = "AssetToolSetting", menuName = "AssetTool Setting", order = 1)]
    public class AssetToolSetting : ScriptableObject
    {
	    [Serializable]
        public class AssetReferenceInfo
        {
            public string title;
            public string referenceFolder;
            public string assetFolder;
            public string assetCommonFolder;
        }

        [SerializeField]
        private List<AssetReferenceInfo> m_AssetReferenceInfos = new List<AssetReferenceInfo>();

        public List<AssetReferenceInfo> assetReferenceInfos
        {
            get { return m_AssetReferenceInfos; }
        }
    }
}