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
            
            // After detecting a hit, it handles it
            var hit = hitInfo.collider;
            switch (hit.tag)
            {
                // Hit takes damage from enemy
                case "Enemy":
                    hit.GetComponent<HealthBar>().TakeDamage(damage);
                    break;
                
                // Hit reduce scale of a DeathTrap
                case "Traps":
                    hit.GetComponent<DeathTrap>().ReduceScale();
                    break;
            }
            
            // Hit creates particles
            Instantiate(particleShot, transform.position, Quaternion.identity);
            
            // After a hit the projectile will be destroyed
            Destroy(gameObject);
        }
    }
}