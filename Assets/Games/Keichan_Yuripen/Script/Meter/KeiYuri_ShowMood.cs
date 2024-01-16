using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMood : MonoBehaviour
{
    public KeiYuri_KiraritchiData kd;
    public Image Gauge;
    // Start is called before the first frame update
    void Start()
    {
        Gauge = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Gauge.fillAmount = kd.kiraritchiData.mood / 100.0f;

    }
}
