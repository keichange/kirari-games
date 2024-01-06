using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject eatingKiraritchiObject;
    private KeiYuri_Fo_KiraritchiAnimation kiraAni;

    [SerializeField]
    private KeiYuri_InitiarizeEatingKiraritchi kiraritchiInitiarizer;

    [SerializeField]
    private GameObject tamatomoObject;
    [SerializeField]
    private KeiYuri_TamatomoManager tm;

    private bool isKiraritchi;

    [SerializeField]
    private string mainSceneName;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentFood = rm.foods[rm.currentFood].foodsName;
        foodScript.SetFood(currentFood);

        isKiraritchi = tm.currentTamatomo == Tamatomo.Tamatomos.None;
        if (isKiraritchi)
        {
            currentFoodsPreference = kd.CompareFoodPreferences(currentFood);
            EatingKiraritchi();
        }
        else
        {
            currentFoodsPreference = kd.CompareFoodPreferences(currentFood);
            EatingTamatomo();
        }
            //StartCoroutine(EatingAnimation());
        }

        // Update is called once per frame
        void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Reset();
                if (isKiraritchi) rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.êHÇ◊ï®ÉÅÉjÉÖÅ[);
                else SceneManager.LoadScene(mainSceneName);
            }
        }
    }

    private void EatingKiraritchi()
    {
        kiraritchiObject.SetActive(true);
        kiraAni = eatingKiraritchiObject.GetComponent<KeiYuri_Fo_KiraritchiAnimation>();
        kd.changeMood(currentFoodsPreference);
        kd.addSatietyLevel(1);
        kiraAni.StartAnimation();
    }

    private void EatingTamatomo()
    {
        tamatomoObject.SetActive(true);
        tamatomoObject.GetComponent<KeiYuri_EatingTamatomo>().EatingTamatomo(tm.currentTamatomo, currentFood);
    }

    private void Reset()
    {
        kiraritchiInitiarizer.Initialize();
        kiraritchiObject.SetActive(false);
        tamatomoObject.SetActive(false);
    }
}
