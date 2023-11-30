using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName = "KiraritchiData")]
public class KeiYuri_KiraritchiData : ScriptableObject
{
    public SaveData saveData = new SaveData();
    public string saveDataPath;
    private void OnEnable()
    {
        saveDataPath = Application.dataPath + "/../savefile.json";
    }

    public void SaveGame()
    {
        string saveDataJson = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveDataPath, saveDataJson);
    }

    public void LoadData()
    {
        if(File.Exists(saveDataPath))
        {
            string saveDataJson = File.ReadAllText(saveDataPath);
            saveData = JsonUtility.FromJson<SaveData>(saveDataJson);
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int money;
    public int satietyLevel;
    public int mood;
}
