using LevelSystem;
using StatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    [RequireComponent(typeof(PlayerStatController))]
    public class Player : MonoBehaviour
    {
        private PlayerStatController m_PlayerStatController;
        private ILevelable m_Levelable;

        private void Awake()
        {
            m_PlayerStatController= GetComponent<PlayerStatController>();
            m_Levelable = m_PlayerStatController.GetComponent<ILevelable>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                (m_PlayerStatController.stats["Health"] as Attribute).ApplyModifier(new StatModifier
                {
                    magnitude = -10,
                    type = ModifierOperationType.Additive
                });
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                (m_PlayerStatController.stats["Mana"] as Attribute).ApplyModifier(new StatModifier
                {
                    magnitude = -10,
                    type = ModifierOperationType.Additive
                });
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                m_Levelable.currentExperience += 50;
            }
        }
    }
}