using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OchimonoGenerator : MonoBehaviour
{
    public GameObject ochimonoPre;
    private GameObject ochimono;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Update()
    {
        
    }

    void Generate()
    {
        for (int i = 0; i < 3; i++)
        {
            ochimono = Instantiate(ochimonoPre);
            ochimono.GetComponent<KeiYuri_OchimonoMove>().ochiID = i;
        }
    }
}
