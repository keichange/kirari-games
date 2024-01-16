using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeiYuri_ShowMoney : MonoBehaviour
{
    public KeiYuri_KiraritchiData kd;
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = kd.kiraritchiData.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
