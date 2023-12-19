using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoData : MonoBehaviour
{
    public FoodSettings.Foods favoriteFood;
    public FoodSettings.Foods hatedFood;
    public TamatomoSealSettings tts;

    public int Eat(FoodSettings.Foods food)
    {
        if(food == favoriteFood)
        {
            return tts.favoriteSealNum;
        }else if(food == hatedFood)
        {
            return tts.hatedSealNum;
        }
        else
        {
            return tts.neutralSealNum;
        }
    }

}
