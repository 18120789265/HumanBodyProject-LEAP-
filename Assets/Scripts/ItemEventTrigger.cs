using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LeapmotionUI
{
    public enum ClickItemType {
        UI_Button,
        World_OBJ
    }

    [RequireComponent(typeof(Collider))]
    public class ItemEventTrigger : MonoBehaviour
    {
        [Header("物体类型")]
        public ClickItemType ItemType;
        [Header("手指点击事件")]
        public MyUnityEvent ItemBeginEvents;
        [Header("手指离开事件")]
        public MyUnityEvent ItemEndEvents;

        Button button;

        private void Start()
        {
            if (ItemType == ClickItemType.UI_Button) {
                button = GetComponent<Button>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.name.Equals("UITrigger"))
                return;
            if (ItemType == ClickItemType.UI_Button)
            {
                button.interactable = false;
            }
            ItemBeginEvents.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.name.Equals("UITrigger"))
                return;
            if (ItemType == ClickItemType.UI_Button)
            {
                button.interactable = true;
            }
            ItemEndEvents.Invoke();
        }

        [Serializable]
        public class MyUnityEvent : UnityEvent { }
    }
}