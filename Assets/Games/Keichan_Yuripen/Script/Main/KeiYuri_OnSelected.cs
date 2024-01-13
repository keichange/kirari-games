using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeiYuri_OnSelected : MonoBehaviour
{
    [SerializeField]public UnityEvent selectedAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected() 
    {
        selectedAction.Invoke();
    }
}
