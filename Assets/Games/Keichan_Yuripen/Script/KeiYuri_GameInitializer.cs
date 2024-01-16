using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameInitializer : MonoBehaviour
{
    public KeiYuri_KiraritchiData kd;
    // Start is called before the first frame update
    void OnEnable()
    {
        kd.LoadData();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
