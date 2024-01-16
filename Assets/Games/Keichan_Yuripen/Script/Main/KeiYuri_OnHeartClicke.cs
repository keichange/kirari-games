using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OnHeartClick : MonoBehaviour
{
    [SerializeField] private GameObject inviteMenu;
    [SerializeField] private GameObject leaveMenu;
    [SerializeField] private KeiYuri_SelectIcon selectIcon;
    [SerializeField] private KeiYuri_TamatomoManager tm;

    private void Start()
    {
        inviteMenu.SetActive(false);
        leaveMenu.SetActive(false);
    }
    public void OnClick()
    {
        if(tm.currentTamatomo == null)
        {
            inviteMenu.SetActive(true);
            selectIcon.enabled = false;
        } 
        else
        {
            leaveMenu.SetActive(true);
            selectIcon.enabled = false;
        }
    }
}
