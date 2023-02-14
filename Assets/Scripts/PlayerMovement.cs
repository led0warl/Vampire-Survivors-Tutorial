using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.unrefactor
{
    public class PlayerMovement : MonoBehaviour
    {
        // Movement
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private Vector2 moveDir;
        [SerializeField]
        private float lastHorizontalVec;
        [SerializeField]
        private float lastVerticalVec;
        Rigidbody2D rb;
        

        [HideInInspector]
        public Vector2 MoveDir { get { return moveDir; } set { } }
        [HideInInspector]
        public float LastHorizontalVec { get { return lastHorizontalVec; } set {  } }
        [HideInInspector]
        public float LastVerticalVec { get { return lastVerticalVec; } set { } }

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            InputManagement();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void InputManagement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            if (moveDir.x != 0)
            {
                lastHorizontalVec= moveDir.x;
            }

            if(moveDir.y != 0)
            {
                lastVerticalVec= moveDir.y;
            }
        }

        void Move()
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed,moveDir.y * moveSpeed);
        }
    }
}