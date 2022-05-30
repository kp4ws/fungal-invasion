using UnityEngine;

namespace Kp4wsGames.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        //[SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] private Weapon equippedPrefab = null;
        [SerializeField] private float weaponDamage = 5f;
        [SerializeField] private float weaponRadius = 0.8f;
        //[SerializeField] private float percentageBonus = 0f;
        //[SerializeField] private float weaponRange = 2f;
        //[SerializeField] private bool isRightHanded = true;
        //[SerializeField] private Projectile projectile = null;

        private const string weaponName = "Weapon";

        public Weapon Spawn(Transform weaponHolder, bool hasWeapon)
        {
            //TODO
            //DropOldWeapon(weaponHolder);
            if(hasWeapon)
                DestroyOldWeapon(weaponHolder);

            Weapon weapon = null;
            if (equippedPrefab != null)
            {
                //Transform handTransform = GetTransform(rightHand, leftHand);
                //weapon = Instantiate(equippedPrefab, handTransform);

                //TODO: Determine if I need to have separate hands?
                weapon = Instantiate(equippedPrefab, weaponHolder);
                weapon.gameObject.name = weaponName;
            }

            //var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;

            //if (animatorOverride != null)
            //{
            //    animator.runtimeAnimatorController = animatorOverride;
            //}
            //else if (overrideController != null)
            //{
            //    //Prevents a glitch if the animator override was not set
            //    //If its already an override, find its parent and put that in the runtime animator slot
            //    animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            //}

            return weapon;
        }

        private void DestroyOldWeapon(Transform weaponHolder)
        {
            Transform oldWeapon = weaponHolder.Find(weaponName);
            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING"; //Prevents frame issue if immediately picking up new weapon (differentiates between the name)
            Destroy(oldWeapon.gameObject);
        }

        //TODO
        private void DropOldWeapon(Transform weaponHolder)
        {

        }

        //public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target, GameObject instigator, float calculatedDamage)
        //{
        //    Projectile projectileInstance = Instantiate(projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
        //    projectileInstance.SetTarget(target, instigator, calculatedDamage);
        //}

        //public bool HasProjectile()
        //{
        //    return projectile != null;
        //}

        //public float GetRange() //Use auto implemented properties instead?
        //{
        //    return weaponRange;
        //}

        //public float GetPercentageBonus()
        //{
        //    return percentageBonus;
        //}

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetRadius()
        {
            return weaponRadius;
        }

        //private Transform GetTransform(Transform rightHand, Transform leftHand)
        //{
        //    return isRightHanded ? rightHand : leftHand;
        //}
    }
}
