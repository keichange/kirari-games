using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robstacle : MonoBehaviour
{
    float[] Rposx = {0.25f,1.25f}; //float型のposition_x配列
    public GameObject R_obstacle; //Robstacleのプレハブ

    //public float RobstacleSpeed;  // 障害物の移動速度

    bool RcloneOnce = false; 

    public GameManager setting;

    //bool isRSpeedUpRunning = false;
    void Update()
    {
        transform.Translate(Vector3.back * setting.RSpeed * Time.deltaTime);
        if (!RcloneOnce && transform.position.z < 67)
        {
            //Debug.Log("一回とは？");
            CloneRobstacle();//障害物生成
            RcloneOnce = true;
        }
        if (R_obstacle.transform.position.z <= -1) //削除
        {
            Destroy(gameObject);
        }
        // if (setting.slider.value >= setting.slider.maxValue && !isRSpeedUpRunning)
        // {
        //     StartCoroutine("RSpeedUP");
        //     //Debug.Log(setting.slider.value);
        // }
    }
    void CloneRobstacle() //障害物生成プログラム
    {
            int Rrnd = Random.Range(0,2);
            GameObject robstacle = Instantiate(R_obstacle) as GameObject;//Robstacleは、プレハブ。クローンされたものは、robstacleとして格納
            //Debug.Log(Rrnd);
            //Debug.Log(Rposx[Rrnd]);
            robstacle.transform.position = new Vector3(Rposx[Rrnd],0,73); //robstacleの生成する場所を、x座標は、配列を使って生成
            //Debug.Log("R生成");
    }

    // IEnumerator RSpeedUP()
    // {
    //     isRSpeedUpRunning = true; // コルーチンが実行中であることをマーク
    //     yield return new WaitForSeconds(1.0f);
    //     RobstacleSpeed += 5;
    //     //Debug.Log("RobstacleSpeed: " + RobstacleSpeed);
    //     isRSpeedUpRunning = false; // コルーチンが終了したことをマーク
    // }
}
