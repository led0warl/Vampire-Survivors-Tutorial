using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSystem.Runtime.Core
{
    public interface IDamageable
    {
        int health { get; }
        int maxHealth { get; }
        event Action healthChanged;
        event Action maxHealthChanged;
        bool isInitialized { get; }
        event Action initialized;
        event Action willUninitialize;
        event Action defeated;
        event Action<int> healed;
        event Action<int, bool> damaged;
        void TakeDamage(IDamage rawDamage);

    }
}