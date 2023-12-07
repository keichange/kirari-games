using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeiYuri_WonderPointText : MonoBehaviour
{
    public KeiYuri_GameSettings gs;
    private WonderSettings ws;
    int point;
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        ws = gs.wonder;
        ws.ResetPoint();
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        point = ws.point;
        tmp.text = point.ToString();
    }
}
