using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeiYuri_OchimonoMove : MonoBehaviour
{
    // 設定フィアル
    public KeiYuri_GameSettings gs;
    public WonderSettings ws;
    System.Random r = new System.Random();

    // 識別子
    public int ochiID;  // オブジェクト
    public int partsId; // Sprite

    // sprite
    SpriteRenderer sr;
    Sprite img;

    // 落ちる前
    float waitTime;
    int hurueState=0;
    int hurueDir;

    // パーツ取得時のストップ管理
    bool move = true;

    // 動き
    public float fallSpeed;
    public float hurueHaba;
    public float maxWaitTime;

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
        if (move)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
                if (waitTime < 0.3)
                {
                    hurueState = (hurueState + 1) % 4;
                    switch (hurueState)
                    {
                        case 1:
                        case 0:
                            hurueDir = 1; break;
                        case 2:
                        case 3:
                            hurueDir = -1; break;
                    }
                    transform.position += new Vector3(hurueDir * hurueHaba, 0, 0);
                }
            }
            else
            {
                if(waitTime > -0.2) transform.position = new Vector3(ws.startPos[ochiID].x, transform.position.y, transform.position.z);

                transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
            }

            if (transform.position.y <= ws.endPos[ochiID].y)
            {
                Reset();
            }
        }
    }

    void Reset()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.position = ws.startPos[ochiID];
        partsId = r.Next(ws.partsList.Length);
        sr.sprite = ws.getParts(partsId).img;
        waitTime = (float)r.NextDouble()*maxWaitTime;
    }

    public void Stop()
    {
        move = false;
    }

    public void ReStart()
    {
        move = true;
    }
}
