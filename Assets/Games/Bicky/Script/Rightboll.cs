using System.Collections;
using System.Collections.Generic;
using TMPro; //TextMeshProを扱えるようにする
using UnityEngine;

public class Rightboll : MonoBehaviour
{
    public Vector3 moveToPosition;
    public Vector3 defaultPosition;
    public float moveSpeed;

    public bool gameExit2 = false; 

    void Update()
    {
        // 右矢印キーが押されている間
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveToTarget();// 所定の位置に行く関数
        }
        else
        {
            // 右矢印キーが離れたら所定の座標に戻る
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    // すり抜けたら、ゲームオーバー
    {
        Debug.Log("衝突関数");
        if(other.gameObject.tag == "obstacle")
        {
            Debug.Log("あたり");
            Destroy(this.gameObject);
            gameExit2 = true;
        }
    }
    void MoveToTarget()
    {
        // moveToPosition 座標に向かって移動
        transform.position = Vector3.MoveTowards(transform.position, moveToPosition, moveSpeed * Time.deltaTime);
        // MoveTowards(現在地,目標地点,スピード)
    }
}