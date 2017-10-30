using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

namespace LeapmotionUI
{
    public class UIDragBehaviour : InteractionBehaviour
    {

        public Transform UIPanel;

        public LineRenderer Line;

        public float MoveSpeed = 1.0f;

        List<Vector3> _points;

        int len = 0;
        Vector3 DragPos;
        private void Update()
        {
            if (isGrasped)
            {
                DragPos = GetGraspPoint(graspingController);
                //Line.positionCount++;
                //Line.SetPosition(len++, GetGraspPoint(graspingController));
                moveUIPanel(DragPos);
            }
            else {
                oldPos = Vector3.zero;
            }
        }

        Vector3 oldPos = Vector3.zero;
        void moveUIPanel(Vector3 newPos)
        {
            if (oldPos.Equals(Vector3.zero))
            {
                oldPos = newPos;
                return;
            }
            Vector3 diff = newPos - oldPos;
            UIPanel.position += diff * MoveSpeed;
            oldPos = newPos;
        }

    }
}
