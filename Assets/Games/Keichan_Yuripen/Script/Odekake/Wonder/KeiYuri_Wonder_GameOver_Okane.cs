using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeiYuri_Wonder_GameOver_Okane : MonoBehaviour
{
    public KeiYuri_GameSettings gs;
    private WonderSettings ws;
    public KeiYuri_KiraritchiData kd;
    private int okane;
    public Sprite[] imgs;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        okane = ws.point / 3;
        sr.sprite = imgs[okane];
        kd.addMoney(okane);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
