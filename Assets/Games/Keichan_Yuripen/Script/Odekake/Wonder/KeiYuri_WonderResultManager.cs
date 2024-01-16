using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_WonderResultManager : MonoBehaviour
{
    [SerializeField] private KeiYuri_KiraritchiData kd;
    public KeiYuri_GameSettings gs;
    private WonderSettings ws;
    public GameObject[] objs;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        kd.addSatietyLevel(-1);
        ws = gs.wonder;
        if (ws.point == 12)
        {
            StartCoroutine(FullScore());
        }
        else
        {
            StartCoroutine(NotFullScore());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FullScore()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            for(int j = 0; j < objs.Length; j++)
            {
                objs[j].SetActive(i == j);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator NotFullScore()
    {
        yield return new WaitForSeconds(waitTime);
        objs[0].SetActive(false);
        objs[objs.Length - 1].SetActive(true);
    }
}
