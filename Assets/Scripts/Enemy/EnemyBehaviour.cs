using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; private set; }

        /* PUBLIC VARIABLES */
        public int health;
        public GameObject deathTrap;
        public GameObject particleDeath;

        /* PRIVATE VARIABLES */
        private const float OffsetDeathTrap = (-0.8f);
        private Vector3 _enemyPosition;
        private IHealthBar _health;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            CurrentHealth = health;

            _health = GetComponent<IHealthBar>();
            _health.Initialize();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;

            var damageable = col.GetComponent<IDamageable>();
            if (damageable == null) return;
            damageable.ApplyDamage(1);

            Explode();
        }

        
        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        private void Explode()
        {
            // Get current enemy position
            _enemyPosition = transform.position;

            // Create DeathTrap on enemy-position
            Instantiate(deathTrap,
                new Vector2(_enemyPosition.x, _enemyPosition.y + OffsetDeathTrap),
                Quaternion.identity);

            // Create death-particles on enemy-position
            Instantiate(particleDeath,
                new Vector2(_enemyPosition.x, _enemyPosition.y + OffsetDeathTrap),
                Quaternion.identity);

            Destroy(this.gameObject);
        }

        
        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PUBLIC FUNCTIONS
         */

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            _health.ShowHealth(CurrentHealth);

            if (CurrentHealth > 0) return;

            Explode();
        }
    }
}