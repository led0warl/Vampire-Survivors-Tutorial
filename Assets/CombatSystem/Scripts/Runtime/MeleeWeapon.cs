using CombatSystem.Runtime.Core;
using System;
using UnityEngine;

namespace CombatSystem.Runtime
{
    public class MeleeWeapon : MonoBehaviour
    {
        public event Action<CollisionData> hit;

        private void OnTriggerEnter(Collider other)
        {
            hit?.Invoke(new CollisionData
            {
                target = other.gameObject,
                source = this
            });
        }
    }
}
