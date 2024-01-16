using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// シーンを変える時に追記、SceneManagerを扱えるようにする

public class RetryButton : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Time.timeScale);
        Time.timeScale = 1f; 
    }
    public void OnClick()// retryボタンが押された時の処理
    {
        Time.timeScale = 1f; //unity内の時間を1にする---→時間を再開する。
        Debug.Log("Retry button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
