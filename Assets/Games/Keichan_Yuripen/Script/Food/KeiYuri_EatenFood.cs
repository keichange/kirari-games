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

    //private int countryMomsRandNum;
    //private Random r;
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
        //if(food == FoodSettings.Foods.カントリーマアム) 

    }

    public void ChangeSprite(int n)
    {
        sr.sprite = currentFoodData.sprites[n];
    }
}
