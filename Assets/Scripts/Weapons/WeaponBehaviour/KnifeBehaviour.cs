using UnityEngine;
using Vampire.Weapon;

namespace Vampire.WeaponBehaviour
{
    public class KnifeBehaviour : ProjectileWeaponBehaviour
    {
        

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            transform.position += direction * weaponData.Speed * Time.deltaTime;
        }
    }
}