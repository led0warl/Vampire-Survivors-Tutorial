using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PlayerMovement : MonoBehaviour,IMoveable
    {

        // Movement
        [SerializeField]
        private Vector2 moveDir;
        Vector2 lastMovedVector;

        // References
        Rigidbody2D rb;
        PlayerInput playInput;
        PlayerStat player;

        

        public float MoveSpeed { get => player.CurrentMoveSpeed;  }
        public Vector2 MoveDir { get=>moveDir; set => moveDir = value; }

        [HideInInspector]
        public Vector2 LastMovedVector { get=>lastMovedVector; set => lastMovedVector = value; }


        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<PlayerStat>();
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
            rb.velocity = new Vector2(moveDir.x * player.CurrentMoveSpeed, moveDir.y * MoveSpeed);
        }
    }
}