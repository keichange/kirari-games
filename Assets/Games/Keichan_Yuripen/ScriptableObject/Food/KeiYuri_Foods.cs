using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewFood")]
public class KeiYuri_FoodData : ScriptableObject
{
    public FoodSettings.Foods foodsName;
    public Sprite[] sprites;
    public int price;
}
