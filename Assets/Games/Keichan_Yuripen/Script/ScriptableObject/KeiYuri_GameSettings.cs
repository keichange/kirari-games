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

    public enum place
    {
        wonder,
        karaoke
    }
    public int favoriteSealNum = 3;
    public int neutralSealNum = 1;
    public int hatedSealNum = 0;
}

// お出かけ
// ワンダー
[System.Serializable]
public class WonderSettings
{
    public int point;
    public Vector2[] startPos;
    public Vector2[] endPos;
    public OchimonoParts[] partsList;

    public OchimonoParts getParts(int n)
    {
        return partsList[n];
    }

    public int GetPoint()
    {
        return point;
    }

    public void AddPoint(int n)
    {
        point += n;
    }

    public void ResetPoint()
    {
        point = 0;
    }
}

[System.Serializable]
public class OchimonoParts
{
    public Sprite img;
    public int layer;
}

// ご飯
public class FoodSettings
{
    public enum Foods
    {
        蒙古タンメン10辛,
        パパパパパイン,
        日本酒,
        麻婆豆腐,
        キムチ,
        ラム肉,
        餃子,
        カントリーマアム,
        銀だこ,
        ピスタチオ,
        唐揚げ,
        ほろよい,
        ビール,
        親子丼,
        カレー
    }
}
