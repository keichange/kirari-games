using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Clear : MonoBehaviour
{
    [SerializeField] private Sprite[] clearSprites;
    [SerializeField] private SpriteRenderer sr;

    public void StartAnimation()
    {
        StartCoroutine(ClearAnimation());
    }

    IEnumerator ClearAnimation()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = clearSprites[j];
                yield return new WaitForSeconds(1);
            }
        }
        sr.sprite = clearSprites[0];
        yield return new WaitForSeconds(1);
        sr.sprite = clearSprites[2];
    }
}
