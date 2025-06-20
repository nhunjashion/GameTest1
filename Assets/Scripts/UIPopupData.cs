using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

[CreateAssetMenu(fileName = "UIPopupData", menuName = "UIPopupData", order = 0)]
public class UIPopupData : ScriptableObject
{
    [SerializeField] List<PopupAsset> popupAssets;

    public void Add(Popup item, IResourceLocation location)
    {
        popupAssets.Add(new PopupAsset(item, location));
        //PopupCatalogueItem abc
    }
    public PopupAsset GetItem(string name)
    {
        foreach (var item in popupAssets)
        {
            if (item.key.Equals(name))
                return item;
        }
        return null;
    }
    public void Clear()
    {
        popupAssets.Clear();
    }

}
[Serializable]
public class PopupAsset
{
    public string key;
    public AssetReference path;

    public PopupAsset(Popup item, IResourceLocation location)
    {
#if UNITY_EDITOR
        Debug.Log(item.GetType().Name);
        this.key = item.GetType().Name;


        var guid = AssetDatabase.GUIDFromAssetPath(location.InternalId);
        this.path = new AssetReference(guid.ToString());
#endif
    }
    public PopupAsset(int id, IResourceLocation location)
    {
#if UNITY_EDITOR
        this.key = id.ToString();
        var guid = AssetDatabase.GUIDFromAssetPath(location.InternalId);
        this.path = new AssetReference(guid.ToString());
#endif
    }
}