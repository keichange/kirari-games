using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keiyuri_MeterManager : MonoBehaviour
{
    [SerializeField] KeiYuri_ChangeScene cs;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            cs.ChangeScene();
        }
    }
}
