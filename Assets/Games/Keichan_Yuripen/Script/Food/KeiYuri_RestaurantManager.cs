using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_RestaurantManager : MonoBehaviour
{
    public FoodSettings.Foods[] foods;
    public GameObject[] scenes;
    public enum Scenes
    {
        オープニング = 0,
        シェフとの会話 = 1,
        食べ物メニュー = 2,
        選択肢 = 3,
        食事アニメーション = 4,
    }
    private Scenes currentScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(Scenes currentScene)
    {
        for(int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive((int)currentScene == i);
        }
    }
}
