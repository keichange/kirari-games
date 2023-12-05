using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoData : MonoBehaviour
{
    public KeiYuri_GameSettings.foods favoriteFood;
    public KeiYuri_GameSettings.foods hatedFood;
    public KeiYuri_GameSettings gs;

    public int Eat(KeiYuri_GameSettings.foods food)
    {
        if(food == favoriteFood)
        {
            return gs.favoriteSealNum;
        }else if(food == hatedFood)
        {
            return gs.hatedSealNum;
        }
        else
        {
            return gs.neutralSealNum;
        }
    }

}
