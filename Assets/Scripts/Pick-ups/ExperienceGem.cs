using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class ExperienceGem : Pickup, ICollectible
    {
        public int experienceGranted;


        public void Collect()
        {
            PlayerStat player = FindObjectOfType<PlayerStat>();
            player.IncreaseExperience(experienceGranted);
        }

        
    }
}