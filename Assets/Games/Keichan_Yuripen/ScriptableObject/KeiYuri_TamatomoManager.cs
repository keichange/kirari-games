using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TamatomoManager")]
public class KeiYuri_TamatomoManager : ScriptableObject
{
    public Tamatomo.Tamatomos currentTamatomo = Tamatomo.Tamatomos.None;
    public KeiYuri_TamatomoData[] tamatomoDatas;
    public bool isEatingAvailable;
    public bool isOdekakeAvailable;
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
