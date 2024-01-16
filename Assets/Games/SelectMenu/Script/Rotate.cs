using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        // transformを取得
        Transform myTransform = this.transform;
 
        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        localAngle.y += speed * Time.deltaTime; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        myTransform.localEulerAngles = localAngle; // 回転角度を設定
 
    }
}
