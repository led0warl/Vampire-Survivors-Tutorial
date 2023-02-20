using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class HealthPotion : Pickup, ICollectible
    {
        public int healthToRestore;

        public void Collect()
        {
            PlayerStat player = FindObjectOfType<PlayerStat>();
            player.RestoreHealth(healthToRestore);
        }

        
    }
}