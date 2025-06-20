using System;
using System.Collections.Generic;
[Serializable]
public class UserData
{
    public string userName = "Guest 1";
   
    public List<Setting> settings;

}
[Serializable]
public class Setting
{
    public SettingType settingType;
    public bool value;
}