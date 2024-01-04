using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_ChefSceneManager : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_RestaurantManager rm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.H‚×•¨ƒƒjƒ…[);
        }
    }
}
