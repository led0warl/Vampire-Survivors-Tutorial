using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.Weapon
{
    /// <summary>
    /// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
    /// </summary>
    public abstract class MeleeWeaponBehaviour : MonoBehaviour
    {
        [SerializeField]
        float destroyAfterSecond;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Destroy(gameObject,destroyAfterSecond);
        }


    }
}