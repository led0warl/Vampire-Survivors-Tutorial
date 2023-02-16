using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vampire.WeaponBehaviour;

namespace Vampire.Weapon
{
    public class Knife : Weapon
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Attack()
        {
            base.Attack();
            GameObject spawnedKnige = Instantiate(prefab);
            spawnedKnige.transform.position = transform.position; // Assign the position to be the same as this object which is parented to the player
            spawnedKnige.GetComponent<KnifeBehaviour>().DirectionChecker(playerMovement.LastMovedVector);


        }
    }
}