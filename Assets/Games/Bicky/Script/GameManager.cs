using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱えるようにする
using UnityEngine.UI;//Slider使うためのクラス
using UnityEngine.SceneManagement;// シーンを変える時に追記、SceneManagerを扱えるようにする


public class GameManager : MonoBehaviour
{
    public int limitedtimer;//制限時間
    public int elapsedtimer;//経過時間
    public int elapsedtimer1;//経過時間1
    public TextMeshProUGUI timertext;//TeXtMeshProを変数として扱うときは、TextMeshProUGUIを使う

    //public TextMeshProUGUI timertext1;//経過時間
    private float spanTime = 0;

    //private float spanTime1 = 0;

    public Slider slider; // UnityエディタでSliderをアタッチする

    public GameObject retryButton;//Retryボタン

    public TextMeshProUGUI gameover;//gameoverのテキスト

    public Leftboll leftBollInstance;//GameManager内にLeftbollのインスタンスを持つフィールドを追加
    //クラス型のLeftbollで
    public Rightboll rightBollInstance;//GameManager内にRightbollのインスタンスを持つフィールドを追加
    //クラス型のRightbollで
    public Lobstacle Linstance;

    public AudioSource bgmAudioSource;//BGM

    public float LSpeed = 12;

    public float RSpeed = 12;

    void Start()
    {
        retryButton.SetActive(false);//Retryボタンを表示させない
    }

    void Update()
    {
        spanTime += Time.deltaTime;
        if(spanTime > 1)
        {
            spanTime = 0;
            limitedtimer -= 1;
            elapsedtimer += 1;
            elapsedtimer1 += 1;
            if(limitedtimer > 0)
            {
                timertext.text = "limited time " + limitedtimer.ToString();//Tostringで変数timerを文字列にする
            }
            else
            {
                SceneManager.LoadScene("Bicky_Clear");// Bicky_Clearシーンに変える
            }
            //timertext1.text = "elasped time " + elapsedtimer.ToString();
            slider.value = elapsedtimer;//
            if (slider.value >= slider.maxValue)
            {
                StartCoroutine("SliderReset");
                //Linstance.SpeedUpL();
                BGMSpeedUP();
                LSpeed += 1.5f;
                RSpeed += 1.5f;
                // for(;slider.value > 1;)
                // {
                //     for(;spanTime1 < 1;)
                //     {
                //         spanTime1 = Time.deltaTime;
                //     }
                //     elapsedtimer1 -= 1;
                //     slider.value = elapsedtimer1;
                //     spanTime1 = 0;
                // }
            }
        }
        if (leftBollInstance.gameExit1 || rightBollInstance.gameExit2 )
        //ゲームオーバーになるとどちらかがtrueになる。
        {
            gameover.text = "GameOver";
            Time.timeScale = 0f; //unity内の時間を0にする---→時間を停止する。
            retryButton.SetActive(true);//Retryボタンを表示させる
        }
    }

    void BGMSpeedUP()
    {
        bgmAudioSource.pitch += 0.1f;
    }
    IEnumerator SliderReset()
    {
        yield return new WaitForSeconds(0.5f);
        slider.value = 0;
        elapsedtimer = 0;
    }
}
