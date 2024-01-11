using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TamatomoManager")]
public class KeiYuri_TamatomoManager : ScriptableObject
{
    public KeiYuri_TamatomoData currentTamatomo = null;
    public KeiYuri_TamatomoData[] tamatomoDatas;
    public bool isEatingAvailable;
    public bool isOdekakeAvailable;

    public void SetRandomTamatomo()
    {
        currentTamatomo = tamatomoDatas[Random.Range(0, tamatomoDatas.Length)];
    }
}

[System.Serializable]
public class Tamatomo
{
    public enum Tamatomos
    {
        Lily,
        Ron,
        Bicky,
        Keichan,
        Yuripen,
        Hiroppe,
        None
    }
}
