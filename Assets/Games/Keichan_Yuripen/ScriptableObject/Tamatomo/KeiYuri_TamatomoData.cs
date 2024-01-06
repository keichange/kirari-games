using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tamatomo;
using static KiraritchiFoodPreferences;

[CreateAssetMenu(menuName = "TamatomoData")]
public class KeiYuri_TamatomoData : ScriptableObject
{
    public Tamatomos tamatomoName;
    public FoodSettings.Foods favoriteFood;
    public FoodSettings.Foods hatedFood;

    public Sprite idle;
    public Sprite sit;
    public Sprite[] yorokobiSprites;
    public Sprite[] happySprites;
    public Sprite[] angrySprites;
    public Sprite[] eatingSpriteNormal;
    public Sprite[] eatingSpriteFavorite;
    public Sprite[] eatingSpriteHated;

    public int count;
    public int tamatomoSeal;

    public bool isEatingAvairable = true;
    public bool isOdekakeAvairable = true;

    public void Invite()
    {
        isEatingAvairable = true;
        isOdekakeAvairable = true;
    }

    public Preferences Eat(FoodSettings.Foods food)
    {
        isEatingAvairable = false;
        if(food == favoriteFood)
        {
            ChangeCount(1);
            return Preferences.D‚«;
        }
        if(food == hatedFood)
        {
            ChangeCount(-1);
            return Preferences.Œ™‚¢;
        }
        return Preferences.•’Ê;
    }

    private void ChangeCount(int num)
    {
        count += num;
        if(count >= 3)
        {
            tamatomoSeal += 1;
            count = 0;
        }else if(count < 0)
        {
            count = 0;
        }
    }
}
