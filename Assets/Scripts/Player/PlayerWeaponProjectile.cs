using UnityEngine;

namespace Player
{
    public class PlayerWeaponProjectile : MonoBehaviour
    {
        /* SERIALIZED VARIABLES */
        [SerializeField] private GameObject particleShot;
        [SerializeField] private LayerMask whatIsSolid;
        [SerializeField] private float speed;
        [SerializeField] private float distance;
        [SerializeField] private int damage;

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
            var hitInfo = Physics2D.Raycast(myTransform.position, myTransform.up, distance, whatIsSolid);
            if (hitInfo.collider == null) return;
            if (hitInfo.transform.CompareTag("Player")) return;

            
            // Looks if object is damageable
            var damageable = hitInfo.collider.GetComponent<IDamageable>();
            if (damageable == null) return;
            damageable.ApplyDamage(damage);

            // Hit creates particles
            Instantiate(particleShot, transform.position, Quaternion.identity);
            
            // After a hit the projectile will be destroyed
            Destroy(gameObject);
        }
    }
}