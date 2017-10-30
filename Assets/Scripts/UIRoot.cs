using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeapmotionUI
{
    public class UIRoot : MonoBehaviour
    {
        public static UIRoot Instance;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        [Header("UI面板")]
        public GameObject UiCanval;
        [Header("距离")]
        public float UiDistance = 0.5f;

        [HideInInspector]
        public Transform Player;

        void Start()
        {
            UiCanval.SetActive(false);
            Player = Camera.main.transform;
        }

        public void ShowUi(bool flag)
        {
            if (flag && !UiCanval.activeSelf)
            {
                UiCanval.SetActive(true);
                Vector3 newPos = Player.position + Vector3.Normalize(new Vector3(Player.forward.x, 0, Player.forward.z)) * UiDistance;
                UiCanval.transform.position = newPos;
                UiCanval.transform.rotation = Quaternion.Euler(0, Player.rotation.eulerAngles.y, 0);
            }
            if (!flag)
            {
                UiCanval.SetActive(false);
            }
        }
    }
}
