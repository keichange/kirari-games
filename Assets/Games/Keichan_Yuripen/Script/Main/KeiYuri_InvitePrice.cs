using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeiYuri_InvitePrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private KeiYuri_InviteTamatomo it;
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = it.price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
