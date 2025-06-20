
using UnityEngine;

public class PopupSetting : Popup
{
    #region Variables
    [SerializeField] ToggleSwitch SoundBtn;
    [SerializeField] ToggleSwitch MusicBtn;

    #endregion

    private void Start()
    {
        SoundBtn.OnToggle += SaveData;
        MusicBtn.OnToggle += SaveData;
        SetData();
        
    }
    public override void Open()
    {
        //  base.Open();
        SetData();
    }

    public void SetData()
    {
        SoundBtn.SetupSliderComponent(0);
        Debug.Log("user setting " + UserDataManager.Instance.UserData.settings[1].value);
        
    }

    public void SaveData(SettingType settingType, bool value)
    {
       UserDataManager.Instance.SetUserSetting(settingType, value);
    }
}
