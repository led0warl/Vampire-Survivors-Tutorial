using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PlayerStat : MonoBehaviour
    {
        [SerializeField]
        CharacterScriptableObject characterData;

        //current stats
        float currentRecovery;
        float currentMoveSpeed;
        float currentHealth;
        float currentMight;
        float currentProjectileSpeed;
        float currentMagnet;

        public float CurrentRecovery { get=>currentRecovery; set=>currentRecovery = value; }
        public float CurrentMoveSpeed { get => currentMoveSpeed; set => currentMoveSpeed = value; }

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

        public float CurrentMight { get => currentMight; set => currentMight = value;
        }

        public float CurrentProjectilSpeed { get => currentProjectileSpeed; set => currentProjectileSpeed = value;
        }

        public float CurrentMagnet { get => currentMagnet;set => currentMagnet = value; }


        //Spawned Weapon
        public List<GameObject> spawnedWeapons;

        //Experience and level of the player
        [Header("Experience/Level")]
        int experience = 0;
        int level = 1;
        int experienceCap;

        //Class for defining a level range and the corresponding experience cap increase for that range
        [System.Serializable]
        public class LevelRange
        {
            public int startLevel;
            public int endLevel;
            public int experienceCapIncrease;

        }

        //I-Frame
        [Header("I-Frames")]
        public float invincibilityDuration;
        float invinvibilityTimer;
        bool isInvincible;

        public List<LevelRange> levelRanges;

        void Awake()
        {

            characterData = CharacterSelector.GetDta();
            CharacterSelector.instance.DestroySingleton();

            //Assign the variables
            currentHealth = characterData.MaxHealth;
            currentRecovery = characterData.Recovery;
            currentMoveSpeed = characterData.MoveSpeed;
            currentMight = characterData.Might;
            currentProjectileSpeed = characterData.ProjectileSpeed;
            currentMagnet = characterData.Magnet;

            //Spawn the starting weapon
            SpawnWeapon(characterData.StartingWeapon); 
        }

        void Start()
        {
            //Initialize the experience cap as the first experience cap increase
            experienceCap = levelRanges[0].experienceCapIncrease;
        }

        void Update()
        {
            if (invinvibilityTimer > 0)
            {
                invinvibilityTimer -= Time.deltaTime;
            }
            //If the invinvibility timer has reached 0, set the invincibility flag to false;
            else if (isInvincible)
            {
                isInvincible = false;
            }

            Recover();
        }

        public void IncreaseExperience(int amount)
        {
            experience += amount;
            LevelUpChecker();
        }

        void LevelUpChecker()
        {
            if (experience >= experienceCap)
            {
                level++;
                experience -= experienceCap;

                int experienceCapIncrease = 0;
                foreach (LevelRange range in levelRanges)
                {
                    if (level >= range.startLevel && level <= range.endLevel)
                    {
                        experienceCapIncrease = range.experienceCapIncrease;
                        break;
                    }
                }
                experienceCap += experienceCapIncrease;
            }
        }

        public void TakeDamage(float dmg)
        {
            //If the player is not currently invincible, reduce health and start invincibility
            if (!isInvincible)
            {
                currentHealth -= dmg;

                invinvibilityTimer = invincibilityDuration;
                isInvincible = true;
                if (currentHealth <= 0)
                {
                    Kill();

                }

            }


        }

        public void Kill()
        {
            Debug.Log("PLAYER IS DEAD");
        }

        public void RestoreHealth(float amount)
        {
            //Only heal the player if their current health is less than their maximum health
            if (currentHealth < characterData.MaxHealth)
            {
                currentHealth += amount;

                //Make sure the player's health doesn't exceed their maximum health
                if (currentHealth > characterData.MaxHealth)
                {
                    currentHealth = characterData.MaxHealth;
                }
            }
        }

        void Recover()
        {
            if (currentHealth < characterData.MaxHealth)
            {
                currentHealth += currentRecovery * Time.deltaTime; 

                // Make sure the player's health doesn't exceed their maximum health
                if (currentHealth > characterData.MaxHealth)
                {
                    currentHealth = characterData.MaxHealth;
                }
            }
        }


        public void SpawnWeapon(GameObject weapon)
        {
            //Spawn the starting weapon
            GameObject spawnedWeapon = Instantiate(weapon,transform.position, Quaternion.identity);
            spawnedWeapon.transform.SetParent(transform); // Set the weapon to be a child of the player
            spawnedWeapons.Add(spawnedWeapon); // Add it to the list of spawned weapons
        }
    }
}