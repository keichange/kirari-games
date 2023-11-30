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
        //kiraritchiData;
    }
}

[System.Serializable]
public class KiraritchiData
{
    public int money;
    public int satietyLevel;
    public int mood;
}
