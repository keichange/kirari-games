using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OchimonoSample : MonoBehaviour
{
    public PartsSet[] sampleList;
    public PartsSet sample;
    public int[] sampleLayerList;
    public GameObject[] partsObj;
    public SpriteRenderer sr;
    System.Random r = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
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
            sr.sprite = sample.partsSprites[i];

            partsObj[i].transform.position = new Vector3(partsObj[i].transform.position.x, partsObj[i].transform.position.y, sample.partsLayer[i]);
        }
    }
}

[System.Serializable]
public class PartsSet
{
    public Sprite[] partsSprites;
    public int[] partsLayer;

    public bool CompareParts(Sprite[] ps)
    {
        if(partsSprites == ps)
        {
            return true;
        }else
        {
            return false;
        }

    }
}
