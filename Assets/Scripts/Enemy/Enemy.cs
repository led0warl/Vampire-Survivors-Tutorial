using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed;

        public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

       

        
    }
}