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

    public bool PayMoney(int n)
    {
        if (kiraritchiData.money > n)
        {
            kiraritchiData.money -= n;
            return true;
        }
        return false;
    }

    public void addSatietyLevel(int n)
    {
        kiraritchiData.satietyLevel = Mathf.Clamp(kiraritchiData.satietyLevel + n, 0, 4);
    }

    public void changeMood(Preferences preferences)
    {
        switch (preferences)
        {
            case Preferences.çDÇ´:
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.favoriteChangeMood, 0, 100);
                break;
            case Preferences.åôÇ¢:
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.hatedChangeMood, 0, 100);
                break;
            case Preferences.ïÅí :
                kiraritchiData.mood = Mathf.Clamp(kiraritchiData.mood + kiraritchiFoodPreferences.normalChangeMood, 0, 100);
                break;
        }
        
    }

    public Preferences CompareFoodPreferences(FoodSettings.Foods food)
    {
        if (CompareFoods(food, kiraritchiFoodPreferences.favoriteFoods))
        {
            return Preferences.çDÇ´;
        }
        else if (CompareFoods(food, kiraritchiFoodPreferences.hatedFoods))
        {
            return Preferences.åôÇ¢;
        }
        return Preferences.ïÅí ;
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
        çDÇ´,
        åôÇ¢,
        ïÅí 
    }
    public FoodSettings.Foods[] favoriteFoods;
    public FoodSettings.Foods[] hatedFoods;
    public int favoriteChangeMood;
    public int hatedChangeMood;
    public int normalChangeMood;
}

