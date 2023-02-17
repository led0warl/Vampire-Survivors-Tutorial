using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire;

namespace Vampire.Enemy
{
    public class EnemyMovement : MonoBehaviour,IMoveable
    {
        [SerializeField]
        EnemyScriptableObject enemyData;

        Transform player;

        public float MoveSpeed { get => enemyData.MoveSpeed; set => value = enemyData.MoveSpeed; }
        

        public void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
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