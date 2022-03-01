using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _eventArray;

    public void Spawn(int eventId)
    {
        _eventArray[eventId].Invoke();
    }
}
