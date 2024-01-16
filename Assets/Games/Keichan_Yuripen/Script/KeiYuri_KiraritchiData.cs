using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static KiraritchiFoodPreferences;

[CreateAssetMenu(menuName = "KiraritchiData")]
public class KeiYuri_KiraritchiData : ScriptableObject
{
    public KiraritchiData kiraritchiData = new KiraritchiData();
    public string kiraritchiDataPath;
    public KiraritchiFoodPreferences kiraritchiFoodPreferences = new KiraritchiFoodPreferences();
    [SerializeField] KeiYuri_TamatomoManager tm;

    private void OnEnable()
    {
        kiraritchiDataPath = Application.dataPath + "/../savefile.json";
    }

    public void SaveGame()
    {
        TamatomoData[] tDatas = new TamatomoData[0];
        for (int i = 0; i < tm.tamatomoDatas.Length; i++)
        {
            System.Array.Resize(ref tDatas, i + 1);
            tDatas[i] = tm.tamatomoDatas[i].tData;
        }
        SaveData saveData = new SaveData()
        {
            tds = tDatas,
            kd = kiraritchiData

        };
        string kiraritchiDataJson = JsonUtility.ToJson(saveData);
        File.WriteAllText(kiraritchiDataPath, kiraritchiDataJson);
    }

    public void LoadData()
    {
        if(File.Exists(kiraritchiDataPath))
        {
            string saveDataJson = File.ReadAllText(kiraritchiDataPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataJson);
            kiraritchiData = saveData.kd;
            for(int i = 0; i < tm.tamatomoDatas.Length; i++)
            {
                tm.tamatomoDatas[i].tData = saveData.tds[i];
            }
        }
    }

    public void addMoney(int n) 
    {
        kiraritchiData.money += n;
    }

    public bool PayMoney(int n)
    {
        if (kiraritchiData.money >= n)
        {
            kiraritchiData.money -= n;
            return true;
        }
        return false;
    }

    public void addSatietyLevel(int n)
    {
        if(kiraritchiData.satietyLevel <= 0){
            kiraritchiData.mood -= 20;
        }
        else kiraritchiData.satietyLevel = Mathf.Clamp(kiraritchiData.satietyLevel + n, 0, 4);
    }

    public void changeMood(Preferences preferences)
    {
        switch (preferences)
        {
            case Preferences.D‚«:
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.favoriteChangeMood, 0, 100);
                break;
            case Preferences.Œ™‚¢:
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.hatedChangeMood, 0, 100);
                break;
            case Preferences.•’Ê:
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.normalChangeMood, 0, 100);
                break;
        }
        
    }

    public bool DoseLeaving()
    {
        return kiraritchiData.mood <= 0;
    }

    public Preferences CompareFoodPreferences(FoodSettings.Foods food)
    {
        if (CompareFoods(food, kiraritchiFoodPreferences.favoriteFoods))
        {
            return Preferences.D‚«;
        }
        else if (CompareFoods(food, kiraritchiFoodPreferences.hatedFoods))
        {
            return Preferences.Œ™‚¢;
        }
        return Preferences.•’Ê;
    }

    private bool CompareFoods(FoodSettings.Foods comparedfood, FoodSettings.Foods[] foods)
    {
        foreach(FoodSettings.Foods food in foods)
        {
            if (food == comparedfood) return true;
        }
        return false;
    }
}

[System.Serializable]
public class KiraritchiData
{
    public int money;
    public int satietyLevel;
    public int mood;
}

[System.Serializable]
public class KiraritchiFoodPreferences
{
    public enum Preferences
    {
        D‚«,
        Œ™‚¢,
        •’Ê
    }
    public FoodSettings.Foods[] favoriteFoods;
    public FoodSettings.Foods[] hatedFoods;
    public int favoriteChangeMood;
    public int hatedChangeMood;
    public int normalChangeMood;
}

[System.Serializable]
public class SaveData
{
    public KiraritchiData kd;
    public TamatomoData[] tds;
}