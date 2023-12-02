using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TamatomoData")]
public class KeiYuri_TamatomoData : ScriptableObject
{
    public string name;
    public KeiYuri_FoodsData.foods favoriteFood;
    public KeiYuri_FoodsData.foods hatedFood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
