using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Wonder : ScriptableObject
{
    public FoodSettings.Foods favoriteFood;
    public FoodSettings.Foods hatedFood;
    public Sprite nomalSprite;
    public Sprite happySprite;
    public Sprite[] eatingSprite;
    public int count;
    public int tamatomoSeal;

    public int Eat(FoodSettings.Foods food)
    {
        if(food == favoriteFood)
        {
            ChangeCount(1);
            return 1;
        }
        if(food == hatedFood)
        {
            ChangeCount(-1);
            return -1;
        }
        return 0;
    }

    //public int GoingOut()
    //{

    //}

    private void ChangeCount(int num)
    {
        count += num;
        if(count >= 3)
        {
            tamatomoSeal += 1;
            count = 0;
        }
    }
}
