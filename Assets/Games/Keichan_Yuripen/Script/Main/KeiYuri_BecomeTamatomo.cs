using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_BecomeTamatomo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private KeiYuri_TamatomoManager tm;
    [SerializeField] KeiYuri_Clear clear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        StartCoroutine(BecomeTamatomoAnimation());
    }

    IEnumerator BecomeTamatomoAnimation()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = tm.currentTamatomo.tamatomoSprite[j];
                yield return new WaitForSeconds(1);
            }
        }
        bool isClear = true;
        foreach(KeiYuri_TamatomoData tamatomoData in tm.tamatomoDatas)
        {
            if (!tamatomoData.isTamatomo)
            {
                isClear = false;
                break;
            }
        }
        if (isClear)
        {
            clear.gameObject.SetActive(true);
            clear.StartAnimation();
        }
        gameObject.SetActive(false);
    }
}
