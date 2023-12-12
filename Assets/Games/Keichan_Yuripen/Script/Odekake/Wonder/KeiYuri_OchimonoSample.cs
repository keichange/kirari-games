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
    public GameObject[] sampleObjs;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        sampleObjs = GameObject.FindGameObjectsWithTag("OchimonoSample");
        SetSumple();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSumple()
    {
        // �T���v���������_���ɑI�сA�p�[�c����Sprite�ƃ��C���[��ݒ肷��B
        sample = sampleList[r.Next(sampleList.Length)];
        foreach(GameObject sampleObj in sampleObjs) {
            sampleObj.GetComponent<KeiYuri_WonderSampleParts>().ChangeSample(sample.partsIDs);
        }
    }
    
    public bool CompareSample(int partsId, int n)
    {
        return sample.CompareParts(partsId, n);
    }
}

[System.Serializable]
public class PartsSet
{
    public int[] partsIDs; // bottom���珸���Ƀp�[�c��ID������

    public bool CompareParts(int partsId, int n)
    {
        if(partsIDs[n] == partsId)
        {
            return true;
        }else
        {
            return false;
        }

    }
}
