using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

public class Icon : MonoBehaviour
{
    public TransitionSettings transition;
    public float loadDelay;
    public GameObject[] stageNames;
    public string[] sceneNamas;
    private int stageNum = 0;
    private RectTransform rectTransform;
    private AirPlaneMove airPlaneMove;
    private BGM bgm;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Vector3 pos = rectTransform.position;
        pos.y = stageNames[stageNum].transform.position.y;
        airPlaneMove = GameObject.Find("AirPlane").GetComponent<AirPlaneMove>();
        bgm = GameObject.Find("BGM").GetComponent<BGM>();
    }

    // Update is called once per frame
    void Update()
    {
        if(( Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) ) && airPlaneMove.isMove == false)
        {
                stageNum--;
                stageNum = (stageNum + stageNames.Length)% stageNames.Length;
                Vector3 pos = rectTransform.position;
                pos.y = stageNames[stageNum].transform.position.y;
                rectTransform.position = pos;
        } else if( ( Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && airPlaneMove.isMove == false)
        {
                stageNum++;
                stageNum = stageNum % stageNames.Length;
                Vector3 pos = rectTransform.position;
                pos.y = stageNames[stageNum].transform.position.y;
                rectTransform.position = pos;
        } else if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && airPlaneMove.isMove == false)
        {
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        bgm.IsFadeOut = true;
        airPlaneMove.isMove = true;
        for(int i = 0; i < 5; i++)
        {
            stageNames[stageNum].SetActive(false);
            yield return new WaitForSeconds(0.1f);
            stageNames[stageNum].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        TransitionManager.Instance().Transition(sceneNamas[stageNum], transition, loadDelay);
    }
}
