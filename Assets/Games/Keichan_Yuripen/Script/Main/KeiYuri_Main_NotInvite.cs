using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Main_NotInvite : MonoBehaviour
{
    [SerializeField]
    private GameObject inviteMenu;
    [SerializeField]
    private KeiYuri_SelectIcon selectIcon;
    public void OnSelected()
    {
        inviteMenu.SetActive(false);
        selectIcon.enabled = true;

    }
}
