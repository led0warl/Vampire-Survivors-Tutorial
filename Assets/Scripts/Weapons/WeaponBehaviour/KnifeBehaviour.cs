using UnityEngine;
using Vampire.Weapon;

namespace Vampire.WeaponBehaviour
{
    public class KnifeBehaviour : ProjectileWeaponBehaviour
    {
        Knife knife;

        protected override void Start()
        {
            base.Start();
            knife = FindObjectOfType<Knife>();
        }

        private void Update()
        {
            transform.position += direction * knife.Speed * Time.deltaTime;
        }
    }
}