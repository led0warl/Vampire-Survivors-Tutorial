using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PlayerMovment : MonoBehaviour
    {

        // Movement
        [SerializeField]
        private float moveSpeed;
        

        Rigidbody2D rb;

        [SerializeField]
        PlayerInput playInput;

      

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

        void Move()
        {
            rb.velocity = new Vector2(playInput.MoveDir.x * moveSpeed, playInput.MoveDir.y * moveSpeed);
        }
    }
}