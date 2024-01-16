using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobstacle : MonoBehaviour
{
    float[] Lposx = {-0.75f,-1.75f}; //float型のposition_x配列
    public GameObject L_obstacle; //obstacleのプレハブ

    //public float LobstacleSpeed;  // 障害物の移動速度

    bool LcloneOnce = false;
    
    // public int elapsedtimer2;//経過時間2

    // private float spanTime2 = 0;

    //bool SpeedUP_L = false;

    public GameManager setting;

    //bool isLSpeedUpRunning = false;
    void Update()
    {
        // spanTime2 += Time.deltaTime;
        // if(spanTime2 > 1)
        // {
        //     spanTime2 = 0;
        //     elapsedtimer2 += 1;
        //     Debug.Log(elapsedtimer2);
        //     if (elapsedtimer2 % 10 == 0 )
        //     {
        //         Debug.Log(elapsedtimer2);
        //         LobstacleSpeed += 5;
        //     }
        // }
        transform.Translate(Vector3.back * setting.LSpeed * Time.deltaTime);
        if (!LcloneOnce && transform.position.z < 67)
        {
            //Debug.Log("一回とは？");
            CloneLobstacle();//障害物生成
            LcloneOnce = true;
            //Debug.Log(LobstacleSpeed);
        }
        if (L_obstacle.transform.position.z <= -1) //削除
        {
            Destroy(gameObject);
        }

        //Debug.Log("Current Speed: " + LobstacleSpeed);
        // if (setting.slider.value >= setting.slider.maxValue && !isLSpeedUpRunning)
        // {
        //     StartCoroutine("LSpeedUP");
        //     Debug.Log(setting.slider.value);
        // }
    }
    void CloneLobstacle() //障害物生成プログラム
    {
            int Lrnd = Random.Range(0,2);
            GameObject lobstacle = Instantiate(L_obstacle) as GameObject;//Lobstacleは、プレハブ。クローンされたものは、lobstacleとして格納
            //Debug.Log(Lrnd);
            //Debug.Log(Lposx[Lrnd]);
            lobstacle.transform.position = new Vector3(Lposx[Lrnd],0,73); //lobstacleの生成する場所を、x座標は、配列を使って生成
            //Debug.Log("L生成");

    }

    // IEnumerator LSpeedUP()
    // {
    //     isLSpeedUpRunning = true; // コルーチンが実行中であることをマーク
    //     yield return new WaitForSeconds(1.0f);
    //     LobstacleSpeed += 5;
    //     Debug.Log("LobstacleSpeed: " + LobstacleSpeed);
    //     isLSpeedUpRunning = false; // コルーチンが終了したことをマーク
    // }

    // public void SpeedUpL()
    // {
    //     LobstacleSpeed += 5;
    //     Debug.Log("LobstacleSpeed: " + LobstacleSpeed);
    //     //Debug.Log(LobstacleSpeed);
    // }
}
