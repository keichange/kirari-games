using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeiYuri_Wonder_GameOver_Okane : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public KeiYuri_GameSettings gs;
    private WonderSettings ws;
    public KeiYuri_KiraritchiData kd;
    private int okane;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        okane = ws.point / 3 * 50;
        tmp.text = okane.ToString();
        kd.addMoney(okane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
