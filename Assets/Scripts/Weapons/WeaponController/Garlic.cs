using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.Weapon
{
    public class Garlic : Weapon
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Attack()
        {
            base.Attack();
            GameObject spawnedGarlic = Instantiate(prefab);
            spawnedGarlic.transform.position = transform.position; // Assign the position to be the same as this object which is parented to the player
            spawnedGarlic.transform.parent = transform;

        }
    }
}