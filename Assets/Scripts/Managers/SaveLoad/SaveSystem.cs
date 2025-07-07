using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class SaveSystem
{
    private static SaveData saveData = new();

    [System.Serializable]
    public struct SaveData
    {
        public GameSettings gameSettings;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }

    private static void HandleSaveData()
    {
        SettingsMenu.i.Save(ref saveData.gameSettings);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        SettingsMenu.i.Load(saveData.gameSettings);
    }

}