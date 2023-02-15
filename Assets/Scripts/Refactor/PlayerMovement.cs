using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PlayerMovement : MonoBehaviour,IMoveable
    {

        // Movement
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private Vector2 moveDir;


        Rigidbody2D rb;

        
        PlayerInput playInput;

        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public Vector2 MoveDir { get=>moveDir; set => moveDir = value; }



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playInput= GetComponent<PlayerInput>();
        }

        // Update is called once per frame
        void Update()
        {
            playInput.InputManagement();
        }

        private void FixedUpdate()
        {
            Move();
        }

        

        public void Move()
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }
    }
}