using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeiYuri_MenuManager : MonoBehaviour
{
    public int currentFood;
    private bool isShowMenu = true;
    public KeiYuri_FoodData[] foods;
    public KeiYuri_RestaurantManager rm;
    public GameObject UI;
    public GameObject FoodImage;
    public GameObject FoodName;
    public GameObject FoodPrice;
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
                currentFood = (currentFood + 1) % foods.Length;
                SetMenu();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.�I����);
            }
        }
    }

    private void SetMenu()
    {
        KeiYuri_FoodData foodData = foods[currentFood];
        FoodImage.GetComponent<Image>().sprite = foodData.sprite;
        FoodName.GetComponent<TextMeshProUGUI>().text = foodData.foodsName.ToString();
        FoodPrice.GetComponent<TextMeshProUGUI>().text = foodData.price.ToString();
        
    }
}
