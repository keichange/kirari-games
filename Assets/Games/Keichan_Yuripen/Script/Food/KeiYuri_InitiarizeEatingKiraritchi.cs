using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_InitiarizeEatingKiraritchi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] kiraritchies;
    public void Initialize()
    {
        kiraritchies[0].SetActive(true);
        kiraritchies[1].SetActive(false);
        kiraritchies[2].SetActive(false);
        
    }
}
