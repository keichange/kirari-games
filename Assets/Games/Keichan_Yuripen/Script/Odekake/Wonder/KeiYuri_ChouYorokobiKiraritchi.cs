using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_ChouYorokobiKiraritchi : MonoBehaviour
{
    private SpriteRenderer sr;
    public float[] posYs;
    public Sprite[] sprites;
    public float waitTime;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Yorokobi());
    }

    IEnumerator Yorokobi()
    {
        int n = 0;
        while (true)
        {
            sr.sprite = sprites[n];
            transform.position = new Vector2(transform.position.x, posYs[n]);
            n = (n+1) % sprites.Length;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
