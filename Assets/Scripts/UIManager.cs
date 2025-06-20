using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;


public class UIManager : Singleton<UIManager>
{
    [SerializeField] Dictionary<string, Popup> mPopups;
    [SerializeField] private AssetLabelReference popupPrefabLabel;
    [SerializeField] private UIPopupData popupCatalogue;
    [SerializeField] private RectTransform popupRectTransform;
    [SerializeField] List<Popup> popups;
    [SerializeField] List<Popup> popupOpeneds;
    public bool preLoad = false;
    // Start is called before the first frame update
    void Start()
    {
        // if (preLoad)
        LoadUIPrefab();
    }
    public void LoadUIPrefab()
    {
        popupCatalogue.Clear();
        Addressables.LoadResourceLocationsAsync(popupPrefabLabel.labelString, null).Completed +=
            OnLoadDataLocationSuccess;
    }

/*    private void OnLoadDataLocationSuccess(AsyncOperationHandle<IList<IResourceLocation>> handle)
    {
        throw new NotImplementedException();
    }*/

    private void OnLoadDataLocationSuccess(AsyncOperationHandle<IList<IResourceLocation>> handle)
    {
        if (handle.IsDone)
        {
            StartCoroutine(FillData(handle.Result));
        }
    }
    IEnumerator FillData(IList<IResourceLocation> resourceLocations)
    {
        Debug.Log(resourceLocations.Count);
        foreach (var item in resourceLocations)
        {
            var tmp = Addressables.LoadAssetAsync<GameObject>(item);
            yield return tmp;
            Debug.Log(item.ToString());
            popupCatalogue.Add(tmp.Result.GetComponent<Popup>(), item);
            popups.Add(tmp.Result.GetComponent<Popup>());
        }
    }
    public void ShowPopup<T>(Action<T> callback = null) where T : Popup
    {
        var popup = popupOpeneds.Find(x => x as T);
        if (popup)
        {

            popup.Open();

            callback?.Invoke(popup as T);
        }
        else
        {
            StartCoroutine(DelayShow(callback));
        }
    }
    private IEnumerator DelayShow<T>(Action<T> callback) where T : Popup
    {
        var popup = popupOpeneds.Find(x => x as T);
        if (popup)
        {
            var popup1 = Instantiate(popup, popupRectTransform);

            popupOpeneds.Add(popup1);
            popup.Open();
            callback?.Invoke(popup1 as T);
        }
        else
        {
            var popup1 = popups.Find(x => x as T);
            {
                if (popup1)
                {
                    var newPopup = Instantiate(popup1, popupRectTransform);
                    popupOpeneds.Add(newPopup);
                    newPopup.Open();
                    callback?.Invoke(newPopup as T);
                }
                else
                {
                    var tmp = Addressables.LoadAssetAsync<GameObject>(popupCatalogue.GetItem(typeof(T).Name).path);

                    yield return tmp;
                    tmp.Result.transform.SetAsLastSibling();
                    popups.Add(tmp.Result.GetComponent<Popup>());

                    var newPopup = Instantiate(popups.LastOrDefault(), popupRectTransform);
                    popupOpeneds.Add(newPopup);
                    newPopup.Open();
                    callback?.Invoke(newPopup as T);
                }
            }

        }

    }


}
