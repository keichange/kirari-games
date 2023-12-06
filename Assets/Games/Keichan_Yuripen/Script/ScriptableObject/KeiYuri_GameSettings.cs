using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class KeiYuri_GameSettings : ScriptableObject
{
    public TamatomoSealSettings tamatomoSeal;
    public WonderSettings wonder;
}

[System.Serializable]
public class TamatomoSealSettings
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

[System.Serializable]
public class WonderSettings
{
    public Vector2[] startPos;
    public Vector2[] endPos;
    public float maxWaitTime;
    public float hurueHaba;
    public float speed;
    public Sprite[] img;
    public Sprite[,] sampleImg = new Sprite[3,3];
}