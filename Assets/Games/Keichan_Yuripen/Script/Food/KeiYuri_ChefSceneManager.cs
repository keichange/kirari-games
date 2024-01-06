using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_ChefSceneManager : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_RestaurantManager rm;
    [SerializeField]
    private GameObject kiraritchi;
    [SerializeField]
    private GameObject tamatomo;
    [SerializeField]
    private KeiYuri_TamatomoManager tm;

    private void OnEnable()
    {
        bool isTamatomo = tm.currentTamatomo != Tamatomo.Tamatomos.None;

        kiraritchi.SetActive(!isTamatomo);
        tamatomo.SetActive(isTamatomo);
    }
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
            rm.ChangeScene(KeiYuri_RestaurantManager.ScenesEnum.êHÇ◊ï®ÉÅÉjÉÖÅ[);
        }
    }
}
