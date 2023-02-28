using UnityEngine;

namespace CombatSystem.Runtime.Core
{
    public interface IDamage
    {
        bool isCriticalHit { get; }
        int magnitude { get; }
        GameObject instigator { get; }
        Object source { get; }
    }
}