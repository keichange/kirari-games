using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_RestaurantManager : MonoBehaviour
{
    public FoodSettings.Foods[] foods;
    public GameObject[] scenes;
    public enum Scenes
    {
        �I�[�v�j���O = 0,
        �V�F�t�Ƃ̉�b = 1,
        �H�ו����j���[ = 2,
        �I���� = 3,
        �H���A�j���[�V���� = 4,
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
