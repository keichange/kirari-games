using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    public KeiYuri_KiraritchiData kd;
    // Start is called before the first frame update
    void Start()
    {
        kd.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
