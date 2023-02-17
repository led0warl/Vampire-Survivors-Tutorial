using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.Weapon
{
    /// <summary>
    /// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
    /// </summary>
    public abstract class MeleeWeaponBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected WeaponScriptableObject weaponData;

        [SerializeField]
        float destroyAfterSecond;

        //Current stats
        protected float currentDamage;
        protected float currentSpeed;
        protected float currentCooldownDuration;
        protected float currentPierce;

        void Awake()
        {
            currentDamage = weaponData.Damage;
            currentSpeed = weaponData.Speed;
            currentCooldownDuration= weaponData.CooldownDuration;
            currentPierce= weaponData.Pierce;
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Destroy(gameObject,destroyAfterSecond);
        }

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                EnemyStat enemy = col.GetComponent<EnemyStat>();
                enemy.TakeDamage(currentDamage);
            }
        }


    }
}