using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WonderGameStartEvent")]
public class KeiYuri_WonderGameStartEvent : ScriptableObject
{
    private List<KeiYuri_WonderGameStartEventListener> listeners = new List<KeiYuri_WonderGameStartEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(KeiYuri_WonderGameStartEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(KeiYuri_WonderGameStartEventListener listener)
    {
        listeners.Remove(listener);
    }
}
