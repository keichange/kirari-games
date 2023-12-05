using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class KeiYuri_GameSettings : ScriptableObject
{
    public enum foods
    {
        Salmon
    }

    public enum place
    {
        wonder,
        karaoke
    }

    public int favoriteSealNum = 3;
    public int neutralSealNum = 1;
    public int hatedSealNum = 0;
}
