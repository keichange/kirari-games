using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OchimonoSample : MonoBehaviour
{
    System.Random r = new System.Random();
    public KeiYuri_GameSettings gs;
    WonderSettings ws;

    public PartsSet[] sampleList;
    public PartsSet sample;
    public OchimonoParts partsData;
    public GameObject[] partsObj;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        SetSumple();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSumple()
    {
        // サンプルをランダムに選び、パーツ毎にSpriteとレイヤーを設定する。
        sample = sampleList[r.Next(sampleList.Length)];
        for (int i = 0; i < partsObj.Length; i++)
        {
            sr = partsObj[i].GetComponent<SpriteRenderer>();
            partsData = ws.getParts(sample.partsIDs[i]);
            sr.sprite = partsData.img;


            partsObj[i].transform.position = new Vector3(partsObj[i].transform.position.x, partsObj[i].transform.position.y,  partsData.layer);
        }
    }
    
    public bool CompareSample(PartsSet ps)
    {
        return sample.CompareParts(ps);
    }
}

[System.Serializable]
public class PartsSet
{
    public int[] partsIDs; // bottomから昇順にパーツのIDが入る

    public bool CompareParts(PartsSet ps)
    {
        if(partsIDs == ps.partsIDs)
        {
            return true;
        }else
        {
            return false;
        }

    }
}
