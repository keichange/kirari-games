using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_TamatomoMove : MonoBehaviour
{
    [SerializeField]
    private KeiYuri_TamatomoManager tm;

    private KeiYuri_TamatomoData currentTamatomo;
    private void OnEnable()
    {
        currentTamatomo = tm.currentTamatomo;
    }
}
