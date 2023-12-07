using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiYuri_OchimonoPlayerMove : MonoBehaviour
{
    int x = 9999999;
    int pileNum = 0;
    public GameObject[] partsObj;

    public KeiYuri_GameSettings gs;
    WonderSettings ws;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x--;
        }

        transform.position = ws.endPos[x % 3];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ochimono"))
        {
            Debug.Log("ochi");
            int partsId = collision.gameObject.GetComponent<KeiYuri_OchimonoMove>().partsId;
            sr = partsObj[pileNum].GetComponent<SpriteRenderer>();
            sr.sprite = ws.getParts(partsId).img;   // スプライトの設定
            collision.gameObject.transform.position += new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, ws.getParts(partsId).layer); // レイヤーの設定
            pileNum += 1;
            if(pileNum >= 3)
            {
                pileNum = 0;
                foreach(GameObject obj in partsObj)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = null;
                }
            }

        }
    }
}
