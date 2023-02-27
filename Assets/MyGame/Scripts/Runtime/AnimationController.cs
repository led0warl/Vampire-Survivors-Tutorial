using StatSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGame
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(StatController))]
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private float m_BaseSpeed = 3.5f;
        private Animator m_Animator;
        private NavMeshAgent m_NavMeshAgent;
        private StatController m_StatController;
        private static readonly int MOVEMENT_SPEED = Animator.StringToHash("MovementSpeed");
        private static readonly int VELOCITY = Animator.StringToHash("Velocity");

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_NavMeshAgent= GetComponent<NavMeshAgent>();
            m_StatController= GetComponent<StatController>();
        }

        private void Update()
        {
            m_Animator.SetFloat(VELOCITY, m_NavMeshAgent.velocity.magnitude / m_NavMeshAgent.speed);
        }

        private void OnEnable()
        {
            m_StatController.initialized += OnStatControllerInitialized;
            if (m_StatController.isInitialized)
            {
                OnStatControllerInitialized();
            }
        }

        private void OnDisable()
        {
            m_StatController.initialized -= OnStatControllerInitialized;
            if (m_StatController.isInitialized)
            {
                m_StatController.stats["MovementSpeed"].valueChanged -= OnMovementSpeedChanged;
            }
        }

        private void OnMovementSpeedChanged()
        {
            m_Animator.SetFloat(MOVEMENT_SPEED, m_StatController.stats["MovementSpeed"].value / 100f);
            m_NavMeshAgent.speed = m_BaseSpeed * m_StatController.stats["MovementSpeed"].value / 100f;
        }

        private void OnStatControllerInitialized()
        {
            OnMovementSpeedChanged();
            m_StatController.stats["MovementSpeed"].valueChanged += OnMovementSpeedChanged;
        }

        
    }
}