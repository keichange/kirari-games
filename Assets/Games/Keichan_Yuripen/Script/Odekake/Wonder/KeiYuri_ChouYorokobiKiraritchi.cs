using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_ChouYorokobiKiraritchi : MonoBehaviour
{
    private SpriteRenderer sr;
    public float[] posYs;
    public float jumpHeight;
    public Sprite[] sprites;
    public float waitTime;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Yorokobi());
    }

    IEnumerator Yorokobi()
    {
        int n = 1;
        sr.sprite = sprites[0];
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            sr.sprite = sprites[n];
            transform.position = new Vector2(transform.position.x, transform.position.y + jumpHeight);
            n = (n+1) % sprites.Length;
            jumpHeight *= -1;
        }
    }
}
