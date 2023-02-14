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
        [SerializeField]
        private Vector2 moveDir;

        



        
        [HideInInspector]
        public float LastHorizontalVec { get { return lastHorizontalVec; } set { } }
        [HideInInspector]
        public float LastVerticalVec { get { return lastVerticalVec; } set { } }
        [HideInInspector]
        public Vector2 MoveDir { get { return moveDir; } set { } }


        // Start is called before the first frame update
        void Start()
        {
          
        }

       



        public void InputManagement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            if (moveDir.x != 0)
            {
                lastHorizontalVec = moveDir.x;
            }

            if (moveDir.y != 0)
            {
                lastVerticalVec = moveDir.y;
            }
        }
    }
}