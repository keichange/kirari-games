using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Fo_ChangeScene : MonoBehaviour
{
    public KeiYuri_RestaurantManager.ScenesEnum scene;
    public KeiYuri_RestaurantManager rm;
    
    public void ChangeScene()
    {
        rm.ChangeScene(scene);
    }
}
