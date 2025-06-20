using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class UserDataManager : Singleton<UserDataManager>
{
    const string USER_DATA = "USER_DATA";
    [SerializeField] private UserData userData;
    public Action OnCharacterChange;
    public Action OnExpChange;
    public Action OnDataLoaded;
    public Action OnNpcRewardReceivedChange;
    public Action OnPvEStageChapterChange;

    public UserData UserData
    {
        get
        {
            return userData;
        }
        private set
        {
            userData = value;
        }
    }
    void Awake()
    {
       // GameConfigManager.Instance.OnConfigLoaded += OnConfigLoaded;
    }
    void Start()
    {
    }
    public void SetIdCharacterStart(int id)
    {
        OnDataLoaded?.Invoke();
    }

    public void SetUserSetting(SettingType type, bool value)
    {
        foreach (var item in userData.settings)
        {
            if(item.settingType == type) item.value = value;
        }
    }
    
    void OnConfigLoaded()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString(USER_DATA, "")))
        {
            UserData = JsonConvert.DeserializeObject<UserData>(PlayerPrefs.GetString(USER_DATA, ""));
        }

        OnDataLoaded?.Invoke();
    }

    private void OnItemChange(GameItem item)
    {
        SaveData();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UIManager.Instance.ShowPopup<Toast>((result) =>
            {
                result.ShowNoti("You gained 100 gold!");
            });
        }
    }

    public void UserNameChange(string name)
    {
        userData.userName = name;
        SaveData();
    }

    void SaveData()
    {
        string data = JsonConvert.SerializeObject(userData);
        Debug.Log(data);
        PlayerPrefs.SetString(USER_DATA, data);
        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        UserData = JsonConvert.DeserializeObject<UserData>(PlayerPrefs.GetString(USER_DATA, ""));
        OnDataLoaded?.Invoke();
    }
    public void ExpChange(int value)
    {
        OnExpChange?.Invoke();

    }

}