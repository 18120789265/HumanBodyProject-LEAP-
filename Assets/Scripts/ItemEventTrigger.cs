using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ItemEventTrigger : MonoBehaviour {

    [Header("手指点击事件")]
    public MyUnityEvent ItemBeginEvents;
    [Header("手指离开事件")]
    public MyUnityEvent ItemEndEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("UITrigger"))
            return;
        ItemBeginEvents.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.name.Equals("UITrigger"))
            return;
        ItemEndEvents.Invoke();
    }

    [Serializable]
    public class MyUnityEvent : UnityEvent { }

    //[Serializable]
    //public class ItemEvent
    //{
    //    [Serializable]
    //    public class MyUnityEvent : UnityEvent { }

    //    [SerializeField]
    //    public MyUnityEvent myEvent = new MyUnityEvent();
    //}
}
