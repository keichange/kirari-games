using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_LeaveTamatomo : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_TamatomoMove tamatomoMove;
    [SerializeField]
    private KeiYuri_SelectIcon selectIcon;
    [SerializeField] private GameObject inviteMenu;

    public void OnClick()
    {
        tamatomoMove.LeaveTamatomo();
        selectIcon.enabled = true;
        inviteMenu.SetActive(false);
    }
}
