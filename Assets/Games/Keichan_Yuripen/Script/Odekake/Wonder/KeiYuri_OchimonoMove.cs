using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeiYuri_OchimonoMove : MonoBehaviour
{
    public KeiYuri_GameSettings gs;
    public WonderSettings ws;

    public int ochiID;

    SpriteRenderer sr;
    Sprite img;

    int partsId;
    System.Random r = new System.Random();

    float waitTime;
    int hurueState=0;
    int hurueDir;

    // Start is called before the first frame update

    void OnEnable()
    {
        ws = gs.wonder;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            if(waitTime < 0.3)
            {
                hurueState = (hurueState + 1) % 4;
                switch(hurueState)
                {
                    case 1:
                    case 0:
                        hurueDir = 1; break;
                    case 2:
                    case 3:
                        hurueDir = -1; break;
                }
                transform.position += new Vector3(hurueDir*ws.hurueHaba, 0, 0);
            }
        }
        else
        {
            transform.position = new Vector3(ws.startPos[ochiID].x, transform.position.y, transform.position.z);
            transform.position -= new Vector3(0, ws.speed * Time.deltaTime, 0);
        }

        if (transform.position.y <= ws.endPos[ochiID].y)
        {
            Reset();
        }
    }

    void Reset()
    {
        transform.position = ws.startPos[ochiID];
        partsId = r.Next(ws.PartsList.Length);
        sr.sprite = ws.getParts(partsId).img;
        waitTime = (float)r.NextDouble()*ws.maxWaitTime;
    }
}
