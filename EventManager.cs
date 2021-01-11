using System;
using System.Collections.Generic;
using UnityEngine;

public enum EventName { };

public class EventManager : MonoBehaviour
{
    private Dictionary<EventName, Action<dynamic>> events;

    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        events = new Dictionary<EventName, Action<dynamic>>();
    }

    public static void StartListening(EventName eventEnum, Action<dynamic> listener)
    {
        Action<dynamic> currentEvent;
        if (Instance.events.TryGetValue(eventEnum, out currentEvent))
        {
            currentEvent += listener;
            Instance.events[eventEnum] = currentEvent;
        }
        else
        {
            currentEvent += listener;
            Instance.events.Add(eventEnum, currentEvent);
        }
    }

    public static void StopListening(EventName eventEnum, Action<dynamic> listener)
    {
        Action<dynamic> currentEvent;
        if (Instance.events.TryGetValue(eventEnum, out currentEvent)&& currentEvent != null)
        {
            currentEvent -= listener;
            Instance.events[eventEnum] = currentEvent;
        }
    }

    public static void TriggerEvent(EventName eventEnum, dynamic data)
    {
        Action<dynamic> currentEvent = null;
        if (Instance.events.TryGetValue(eventEnum, out currentEvent) && currentEvent != null)
        {
            currentEvent.Invoke(data);
        }
    }
}
