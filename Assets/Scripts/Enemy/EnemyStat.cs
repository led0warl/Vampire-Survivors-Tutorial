using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    
    public class EnemyStat : MonoBehaviour
    {
        
        public EnemyScriptableObject enemyData;

        //Current stats
        float currentMoveSpeed;
        float currentHealth;
        float currentDamage;

        void Awake()
        {
            //Assign the variable
            currentMoveSpeed = enemyData.MoveSpeed;
            currentHealth = enemyData.MaxHealth;
            currentDamage = enemyData.Damage;
        }

        public void TakeDamage(float dmg)
        {
            currentHealth -= dmg;

            if (currentHealth <= 0)
            {
                Kill();
            }

        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            //Reference the script from the collider and deal damage using TakeDamage()
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerStat player = collision.gameObject.GetComponent<PlayerStat>();
                player.TakeDamage(currentDamage); //Make sure to use currentDamage instead of weaponData.damage in case any damage multipliers in the future
            }
        }


    }
}