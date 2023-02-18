using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire.Weapon;

namespace Vampire.WeaponBehaviour
{
    public class GarlicBehaviour : MeleeWeaponBehaviour
    {
        List<GameObject> markedEnemies;
        protected override void Start()
        {
            base.Start();
            markedEnemies = new List<GameObject>();
        }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
            {
                EnemyStat enemy = col.GetComponent<EnemyStat>();
                enemy.TakeDamage(currentDamage);

                markedEnemies.Add(col.gameObject); // Mark the enemy
            }
            else if (col.CompareTag("Prop"))
            {
                if (col.gameObject.TryGetComponent(out BreakableProps breakable) && !markedEnemies.Contains(col.gameObject))
                {
                    breakable.TakeDamage(currentDamage);

                    markedEnemies.Add(col.gameObject);
                }
            }
        }
    }


}