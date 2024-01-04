using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_EatingManager : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_RestaurantManager rm;
    [SerializeField]
    private KeiYuri_KiraritchiData kd;

    public FoodSettings.Foods currentFood;
    public KiraritchiFoodPreferences.Preferences currentFoodsPreference;
    [SerializeField]
    private KeiYuri_EatenFood foodScript;

    [SerializeField]
    private GameObject kiraritchiObject;
    private KeiYuri_Fo_KiraritchiAnimation kiraAni;

    [SerializeField]
    private KeiYuri_InitiarizeEatingKiraritchi kiraritchiInitiarizer;

    // Start is called before the first frame update
    void OnEnable()
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
        if (gameObject.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                kiraritchiInitiarizer.Initialize();
                rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.êHÇ◊ï®ÉÅÉjÉÖÅ[);
            }
        }
    }

    private void EatingKiraritchi()
    {
        kd.changeMood(currentFoodsPreference);
        kd.addSatietyLevel(1);
        kiraAni.StartAnimation();
    }
}
