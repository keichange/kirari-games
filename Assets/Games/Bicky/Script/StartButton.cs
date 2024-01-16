using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// シーンを変える時に追記、SceneManagerを扱えるようにする

public class StartButtun : MonoBehaviour
{
     public void OnClick()// startボタンがおされた時の処理　※必ずpublicにします
    {
        SceneManager.LoadScene("Bicky_Game");// Bicky_gameシーンに変える
    }
}
