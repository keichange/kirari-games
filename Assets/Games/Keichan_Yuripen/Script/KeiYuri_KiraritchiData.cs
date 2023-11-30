using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName = "KiraritchiData")]
public class KeiYuri_KiraritchiData : ScriptableObject
{
    public KiraritchiData kiraritchiData = new KiraritchiData();
    public string kiraritchiDataPath;
    private void OnEnable()
    {
        kiraritchiDataPath = Application.dataPath + "/../savefile.json";
    }

    public void SaveGame()
    {
        string kiraritchiDataJson = JsonUtility.ToJson(kiraritchiData);
        File.WriteAllText(kiraritchiDataPath, kiraritchiDataJson);
    }

    public void LoadData()
    {
        if(File.Exists(kiraritchiDataPath))
        {
            string kiraritchiDataJson = File.ReadAllText(kiraritchiDataPath);
            kiraritchiData = JsonUtility.FromJson<KiraritchiData>(kiraritchiDataJson);
        }
    }

    public void addMoney(int n) 
    {
        kiraritchiData.money += n;
    }

    public void addSatietyLevel(int n)
    {
        kiraritchiData.satietyLevel = Mathf.Clamp(kiraritchiData.satietyLevel + n, 0, 4);
    }

    public void addMood(int n)
    {
        kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + n, 0, 100);
    }
}

[System.Serializable]
public class KiraritchiData
{
    public int money;
    public int satietyLevel;
    public int mood;
}
