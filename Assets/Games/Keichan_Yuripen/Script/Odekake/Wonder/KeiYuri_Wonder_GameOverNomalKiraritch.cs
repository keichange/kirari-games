using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Wonder_ResultNomalKiraritch : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite[] sprites;
    public float waitTime;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Yorokobi());
    }

    IEnumerator Yorokobi()
    {
        int n = 0;
        while (true)
        {
            sr.sprite = sprites[n%sprites.Length];
            n++;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
