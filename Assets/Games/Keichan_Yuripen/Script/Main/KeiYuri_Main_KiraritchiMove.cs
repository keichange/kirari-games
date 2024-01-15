using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_Main_KiraritchiMove : MonoBehaviour
{
    int n;
    [SerializeField] private Sprite[] yorokobiSprite;
    [SerializeField] private Sprite leavingSprite;
    [SerializeField] private float[] leavingAnimationXs;
    [SerializeField] private GameObject gameOverObject;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float waitTime = 1;

    [SerializeField] KeiYuri_KiraritchiData kd;
    // Start is called before the first frame update
    void Start()
    {
        if(kd.DoseLeaving()) LeavingKiraritchi();
    }

    private void LeavingKiraritchi()
    {
        sr.sprite = leavingSprite;
        StartCoroutine(LeavingAnimation());
    }

    IEnumerator LeavingAnimation()
    {
        float y = transform.position.y;
        float z = transform.position.z;
        foreach(float x in leavingAnimationXs)
        {
            transform.position = new Vector3(x, y, z);
            yield return new WaitForSeconds(1);
        }
        gameOverObject.SetActive(true);
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
