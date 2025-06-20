using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public void Shop()
    {

    }
    public void Inventory()
    {
        UIManager.Instance.ShowPopup<Inventory>();
    }
    public void Notification()
    {
        UIManager.Instance.ShowPopup<Toast>((result) =>
        {
            result.ShowNoti("This is a notification!");
        });
    }
    public void Confirm()
    {
        UIManager.Instance.ShowPopup<PopupConfirm>();
    }

    public void Setting()
    {
        UIManager.Instance.ShowPopup<PopupSetting>();
    }
}
