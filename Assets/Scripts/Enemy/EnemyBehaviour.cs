using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        /* PUBLIC VARIABLES */
        public GameObject deathTrap;
        public GameObject particleDeath;

        /* PRIVATE VARIABLES */
        private const float OffsetHealthBarY = (-0.8f);
        private Vector3 _enemyPosition;
        private HealthBar _healthBar;
        private DeadMenu _deadMenu;


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Start()
        {
            _healthBar = GetComponent<HealthBar>();
            _deadMenu = GameObject.Find("EventSystem").GetComponent<DeadMenu>();
        }

        private void Update()
        {
            // Check if the player is dead
            if (!_healthBar.isDead) return;

            // Get current enemy position
            _enemyPosition = transform.position;

            // Create DeathTrap on enemy-position
            Instantiate(deathTrap,
                new Vector2(_enemyPosition.x, _enemyPosition.y + OffsetHealthBarY),
                Quaternion.identity);

            // Create death-particles on enemy-position
            Instantiate(particleDeath,
                new Vector2(_enemyPosition.x, _enemyPosition.y + OffsetHealthBarY),
                Quaternion.identity);

            // Counts killed enemy
            _deadMenu.kills += 1;

            // Destroys enemy
            Destroy(this.gameObject);
        }
    }
}