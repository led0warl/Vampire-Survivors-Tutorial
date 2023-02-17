using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {

        [Header("Weapon Stats")]
        [SerializeField]
        protected WeaponScriptableObject weaponData;
        float currentCooldown;
        

        protected PlayerMovement playerMovement;


        // Start is called before the first frame update
        protected virtual void Start()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            currentCooldown = weaponData.CooldownDuration; // At the start set the current cooldown to be cooldown duration
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0) //Once the cooldown becomes 0, attack
            {
                Attack();
            }
        }

        protected virtual void Attack()
        {
            currentCooldown= weaponData.CooldownDuration; 
        }
    }
}