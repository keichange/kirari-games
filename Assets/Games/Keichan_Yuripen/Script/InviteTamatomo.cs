using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteTamatomo : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_TamatomoManager tm;

    [SerializeField]
    private GameObject tamatomoObject;

    public void Invite()
    {
        tm.tamatomoDatas[Random.Range(0, tm.tamatomoDatas.Length)]
    }
}
