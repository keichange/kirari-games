using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMood : MonoBehaviour
{
    public KeiYuri_KiraritchiData kd;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = kd.kiraritchiData.mood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
