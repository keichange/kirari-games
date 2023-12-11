using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OchimonoGenerator : MonoBehaviour
{
    public GameObject ochimonoPre;
    private GameObject ochimono;
    public KeiYuri_GameSettings gs;
    private WonderSettings ws;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        for (int i = 0; i < ws.startPos.Length; i++)
        {
            ochimono = Instantiate(ochimonoPre);
            ochimono.GetComponent<KeiYuri_OchimonoMove>().ochiID = i;
            yield return new WaitForSeconds(0);

        }
    }
}
