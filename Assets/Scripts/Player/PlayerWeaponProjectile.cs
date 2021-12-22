using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerWeaponProjectile : MonoBehaviour
    {
        /* PUBLIC VARIABLES */
        public GameObject particleShot;
        public LayerMask whatIsSolid;
        public float speed;
        public float distance;
        public int damage;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Update()
        {
            OnHit();
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector2.up * (speed * Time.deltaTime));
        }

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        private void OnHit()
        {
            // Looks if projectile hits something
            var myTransform = transform;
            RaycastHit2D hitInfo = Physics2D.Raycast(myTransform.position, myTransform.up, distance, whatIsSolid);
            if (hitInfo.collider == null) return;
            
            // Looks if object is damageable
            var damageable = hitInfo.collider.GetComponent<IDamageable>();
            if (damageable == null) return;
            damageable.ApplyDamage(1);

            // Hit creates particles
            Instantiate(particleShot, transform.position, Quaternion.identity);
            
            // After a hit the projectile will be destroyed
            Destroy(gameObject);
        }
    }
}