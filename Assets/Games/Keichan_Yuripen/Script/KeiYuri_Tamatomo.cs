using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoData : MonoBehaviour
{
    public TamatomoSealSettings.foods favoriteFood;
    public TamatomoSealSettings.foods hatedFood;
    public TamatomoSealSettings tts;

    public int Eat(TamatomoSealSettings.foods food)
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
