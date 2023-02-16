using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire;

namespace Vampire.Enemy
{
    public class EnemyMovement : MonoBehaviour,IMoveable
    {
        [SerializeField]
        float moveSpeed;

        Transform player;

        public float MoveSpeed { get => moveSpeed; set => value = moveSpeed; }

        public void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, moveSpeed * Time.deltaTime);
        }

        private void Start()
        {
            player = FindObjectOfType<PlayerMovement>().transform;
            
        }

        void Update()
        {
            Move();
        }


    }
}