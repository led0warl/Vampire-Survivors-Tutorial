using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire;

namespace Vampire.Enemy
{
    public class EnemyMovement : MonoBehaviour,IMoveable
    {
        [SerializeField]
        EnemyStat enemy;

        Transform player;

        public float MoveSpeed { get => enemy.CurrentMoveSpeed; set => value = enemy.CurrentMoveSpeed; }
        

        public void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, enemy.CurrentMoveSpeed * Time.deltaTime);
        }

        private void Start()
        {
            player = FindObjectOfType<PlayerMovement>().transform;
            enemy = GetComponent<EnemyStat>();
            
        }

        void Update()
        {
            Move();
        }


    }
}