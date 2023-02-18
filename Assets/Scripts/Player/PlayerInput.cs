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
      
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerMovement.LastMovedVector = new Vector2(1, 0f); //If we don't do this and game starts up and don't move, the projectile weapon will have no momentum
        }


        public void InputManagement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            playerMovement.MoveDir = new Vector2(moveX, moveY).normalized;

            if (playerMovement.MoveDir.x != 0)
            {
                lastHorizontalVec = playerMovement.MoveDir.x;
                playerMovement.LastMovedVector = new Vector2(lastHorizontalVec, 0f);
            }

            if (playerMovement.MoveDir.y != 0)
            {
                lastVerticalVec = playerMovement.MoveDir.y;
                playerMovement.LastMovedVector = new Vector2(0f, lastVerticalVec);
            }

            if(playerMovement.MoveDir.x != 0 && playerMovement.MoveDir.y != 0)
            {
                playerMovement.LastMovedVector = new Vector2(lastHorizontalVec, lastVerticalVec);
            }
        }
    }
}