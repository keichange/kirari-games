using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeiYuri_WonderYoiStart : MonoBehaviour
{
    public int waitTime;
    public SpriteRenderer sr;
    public Sprite startImage;
    public string startScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(YoiStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator YoiStart()
    {
        yield return new WaitForSeconds(waitTime);
        sr.sprite = startImage;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(startScene);
    }
}
