using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_EatenFood : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private KeiYuri_FoodData currentFoodData;
    [SerializeField]
    private KeiYuri_RestaurantManager rm;
    System.Random r = new System.Random();

    private int countryMomsRandNum;
    private int isCountryMom;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFood(FoodSettings.Foods food)
    {
        foreach(KeiYuri_FoodData foodData in rm.foods)
        {
            if (foodData.foodsName == food) currentFoodData = foodData;
        }
        if(food == FoodSettings.Foods.カントリーマアム)
        {
            isCountryMom = 1;
            countryMomsRandNum = r.Next(2);
        } else
        {
            isCountryMom = 0;
        }

    }

    public void ChangeSprite(int n)
    {
        if (countryMomsRandNum == 0) n += 1; else n += 4;
        sr.sprite = currentFoodData.sprites[n];
    }
}
