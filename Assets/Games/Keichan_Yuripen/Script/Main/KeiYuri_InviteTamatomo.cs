using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_InviteTamatomo : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_TamatomoManager tm;
    [SerializeField]
    private KeiYuri_KiraritchiData kd;

    [SerializeField]
    private GameObject tamatomoObject;
    [SerializeField]
    private GameObject inviteMenu;

    [SerializeField]
    private KeiYuri_SelectIcon selectIcon;

    [SerializeField]
    public int price;

    public void Invite()
    {
        if (kd.PayMoney(price))
        {
            tm.currentTamatomo = tm.tamatomoDatas[Random.Range(0, tm.tamatomoDatas.Length)];
            tamatomoObject.SetActive(true);
            tamatomoObject.GetComponent<KeiYuri_TamatomoMove>().Invited();
            selectIcon.enabled = true;
            inviteMenu.SetActive(false);
        }
    }
}
