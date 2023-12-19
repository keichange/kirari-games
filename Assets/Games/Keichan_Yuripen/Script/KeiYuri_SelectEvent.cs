using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeiYuri_SelectEvent : MonoBehaviour
{
    public UnityEvent function;
    
    public void OnSelected()
    {
        function.Invoke();
    }
}
