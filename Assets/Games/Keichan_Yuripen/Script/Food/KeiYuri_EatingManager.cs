using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_EatingManager : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_RestaurantManager rm;
    [SerializeField]
    private KeiYuri_KiraritchiData kd;

    private FoodSettings.Foods currentFood;
    public KiraritchiFoodPreferences.Preferences currentFoodsPreference;

    [SerializeField]
    private GameObject kiraritchiObject;
    private KeiYuri_Fo_KiraritchiAnimation kiraAni;

    // Start is called before the first frame update
    void Awake()
    {
        kiraAni = kiraritchiObject.GetComponent<KeiYuri_Fo_KiraritchiAnimation>();
        currentFood = rm.foods[rm.currentFood].foodsName;
        currentFoodsPreference = kd.CompareFoodPreferences(currentFood);
        EatingKiraritchi();
        //StartCoroutine(EatingAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EatingKiraritchi()
    {
        kd.changeMood(currentFoodsPreference);
        kd.addSatietyLevel(1);
        kiraAni.StartAnimation();
    }

    //IEnumerator EatingAnimation()
    //{
    //    for(int i = 0; i < 3; i++)
    //    {
    //        kiraAni.NextSprite(currentFoodsPreference);
    //        yield return new WaitForSeconds(1);
    //        kiraAni.NextSprite(currentFoodsPreference);
    //        yield return new WaitForSeconds(1);
    //    }

    //    if(currentFoodsPreference == KiraritchiFoodPreferences.Preferences.Œ™‚¢)
    //    {

    //    }
    //}
}
