using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PlayerInput : MonoBehaviour
    {

        [SerializeField]
        private float lastHorizontalVec;
        [SerializeField]
        private float lastVerticalVec;

        PlayerMovement playerMovement;


        [HideInInspector]
        public float LastHorizontalVec { get { return lastHorizontalVec; } set { } }
        [HideInInspector]
        public float LastVerticalVec { get { return lastVerticalVec; } set { } }
        [HideInInspector]
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }


        public void InputManagement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            playerMovement.MoveDir = new Vector2(moveX, moveY).normalized;

            if (playerMovement.MoveDir.x != 0)
            {
                lastHorizontalVec = playerMovement.MoveDir.x;
            }

            if (playerMovement.MoveDir.y != 0)
            {
                lastVerticalVec = playerMovement.MoveDir.y;
            }
        }
    }
}