using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Shake : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Animation()
    {
        while (true)
        {
            for(int i = 0; i < 2; i++)
            {
                sr.sprite = sprites[i];
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
