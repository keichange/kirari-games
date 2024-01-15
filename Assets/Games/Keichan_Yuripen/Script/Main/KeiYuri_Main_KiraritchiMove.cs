using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Main_KiraritchiMove : MonoBehaviour
{
    int n;
    [SerializeField]
    private Sprite[] yorokobiSprite;
    private SpriteRenderer sr;
    [SerializeField]
    private float waitTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yorokobi(int n)
    {
        StartCoroutine(YorokobiAnimation());
    }

    IEnumerator YorokobiAnimation()
    {
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                sr.sprite = yorokobiSprite[j];
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
