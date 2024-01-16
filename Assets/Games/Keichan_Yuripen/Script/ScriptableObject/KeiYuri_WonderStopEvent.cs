using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WonderStopEvent")]
public class KeiYuri_WonderStopEvent : ScriptableObject
{
    private List<KeiYuri_WonderStopEventListener> listeners = new List<KeiYuri_WonderStopEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(KeiYuri_WonderStopEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(KeiYuri_WonderStopEventListener listener)
    {
        listeners.Remove(listener);
    }
}
