using Core;
using System.Collections;
using UnityEngine;

namespace StatSystem
{
    public class HealthModifier : StatModifier, IDamage
    {
        public bool isCriticalHit { get; set; }

        public GameObject instigator { get; set; }
    }
}