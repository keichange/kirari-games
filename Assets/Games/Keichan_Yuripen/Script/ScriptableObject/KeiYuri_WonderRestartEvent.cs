using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WonderRestartEvent")]
public class KeiYuri_WonderRestartEvent : ScriptableObject
{
    private List<KeiYuri_WonderRestartEventListener> listeners = new List<KeiYuri_WonderRestartEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(KeiYuri_WonderRestartEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(KeiYuri_WonderRestartEventListener listener)
    {
        listeners.Remove(listener);
    }
}
