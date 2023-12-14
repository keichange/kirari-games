using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeiYuri_OchimonoMove : MonoBehaviour
{
    // �ݒ�t�B�A��
    public KeiYuri_GameSettings gs;
    public WonderSettings ws;
    System.Random r = new System.Random();

    // ���ʎq
    public int ochiID;  // �I�u�W�F�N�g
    public int partsId; // Sprite

    // sprite
    SpriteRenderer sr;
    Sprite img;

    // ������O
    float waitTime;
    int hurueState=0;
    int hurueDir;

    // �p�[�c�擾���̃X�g�b�v�Ǘ�
    bool move = true;

    // ����
    public float fallSpeed;
    public float hurueHaba;
    public float maxWaitTime;

    // �����_��
    public int probabilityOfCorrectParts;
    public GameObject player;
    public GameObject sample;
    private int correctPartsId;

    // Start is called before the first frame update

    void OnEnable()
    {
        ws = gs.wonder;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sample = GameObject.FindGameObjectWithTag("Sample");
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (waitTime > 0)
            {
                WaitMove();
            }
            else
            {
                FallMove();
            }

            if (transform.position.y <= ws.endPos[ochiID].y)
            {
                if (waitTime > -0.2) transform.position = new Vector3(ws.startPos[ochiID].x, transform.position.y, transform.position.z);
                Reset();
            }
        }
    }

    void WaitMove()
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

    void FallMove()
    {

        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }

    void Reset()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

        // �ʒu�̃��Z�b�g
        transform.position = ws.startPos[ochiID];

        // Sprite�̕ύX
        correctPartsId = sample.GetComponent<KeiYuri_OchimonoSample>().sample.partsIDs[player.GetComponent<KeiYuri_OchimonoPlayerMove>().pileNum];
        if(r.Next(100) < probabilityOfCorrectParts)
        {
            partsId = correctPartsId;
        }
        else
        {
            partsId = r.Next(ws.partsList.Length);
        }
        sr.sprite = ws.getParts(partsId).img;

        // �҂����Ԃ̃Z�b�g
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
