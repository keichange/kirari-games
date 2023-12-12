using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeiYuri_OchimonoPlayerMove : MonoBehaviour
{
    int x = 9999999;
    int pileNum = 0;
    public GameObject[] partsObj;
    public GameObject sampleObj;

    public KeiYuri_GameSettings gs;
    WonderSettings ws;

    SpriteRenderer sr;

    public string SceneName;

    private bool move = true;

    public float waitTime;

    [SerializeField, Header("落ち物獲得時のストップイベント")]
    private KeiYuri_WonderStopEvent stopEvent = null;

    [SerializeField, Header("落ち物獲得時ストップ後再開イベント")]
    private KeiYuri_WonderRestartEvent wre = null;

    public KeiYuri_OchimonoSample os;

    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Move();

        }
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

        transform.position = ws.endPos[x % ws.startPos.Length];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ochimono"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            int partsId = collision.gameObject.GetComponent<KeiYuri_OchimonoMove>().partsId;
            if(sampleObj.GetComponent<KeiYuri_OchimonoSample>().CompareSample(partsId, pileNum))
            {
                ws.AddPoint(1);
                stopEvent.Raise();
                // 見た目と位置の設定
                sr = partsObj[pileNum].GetComponent<SpriteRenderer>();
                sr.sprite = ws.getParts(partsId).img;   // スプライトの設定
                partsObj[pileNum].transform.position = new Vector3(partsObj[pileNum].transform.position.x, partsObj[pileNum].transform.position.y, ws.getParts(partsId).layer); // レイヤーの設定
            }
            else
            {
                GameOver();
            }
        }
    }

    public void Stop()
    {
        move = false;
        StartCoroutine(WaitSecond());

    }

    public void Restart()
    {
        if(ws.point == 12)
        {
            GameOver();
        }
        move = true;
        // 積み上がった数の変更と初期化
        pileNum += 1;
        if (pileNum == 3)
        {
            os.SetSumple();
            pileNum = 0;
            foreach (GameObject obj in partsObj)
            {
                obj.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(waitTime);
        wre.Raise();
    }
}
