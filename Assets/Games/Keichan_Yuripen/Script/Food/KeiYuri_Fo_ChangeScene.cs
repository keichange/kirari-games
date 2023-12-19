using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Fo_ChangeScene : MonoBehaviour
{
    public KeiYuri_RestaurantManager.Scenes scene;
    public KeiYuri_RestaurantManager rm;
    
    public void ChangeScene()
    {
        rm.ChangeScene(scene);
    }
}
