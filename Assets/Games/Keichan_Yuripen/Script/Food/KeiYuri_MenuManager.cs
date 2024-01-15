using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class KeiYuri_MenuManager : MonoBehaviour
{
    public KeiYuri_RestaurantManager rm;
    [SerializeField]
    private KeiYuri_KiraritchiData kd;

    public GameObject UI;
    public GameObject FoodImage;
    public GameObject FoodName;
    public GameObject FoodPrice;
    KeiYuri_FoodData foodData;
    // Start is called before the first frame update
    void OnEnable()
    {
        SetMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                NextFood();
                SetMenu();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(kd.PayMoney(foodData.price))
                {
                    rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.‘I‘ðŽˆ);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) Back();
        }
    }

    private void SetMenu()
    {
        foodData = rm.foods[rm.currentFood];
        FoodImage.GetComponent<Image>().sprite = foodData.sprites[0];
        FoodName.GetComponent<TextMeshProUGUI>().text = foodData.foodsName.ToString();
        FoodPrice.GetComponent<TextMeshProUGUI>().text = foodData.price.ToString();
        
    }

    private void NextFood()
    {
        rm.NextFood();
    }
    private void Back()
    {
        GetComponent<KeiYuri_ChangeScene>().ChangeScene();
    }
}
