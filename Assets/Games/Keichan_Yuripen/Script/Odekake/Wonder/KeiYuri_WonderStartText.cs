using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeiYuri_WonderStartText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public KeiYuri_WonderGameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartText()
    {
        tmp.text = "よーい";
        yield return new WaitForSeconds(1);
        tmp.text = "スタート！";
        yield return new WaitForSeconds(1);
        gameStartEvent.Raise();
        tmp.text = "";
    }
}
