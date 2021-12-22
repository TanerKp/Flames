using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        /* PUBLIC VARIABLES */
        [Range(1, 10)] public float speed;

        /* PRIVATE VARIABLES */
        private GameObject _player;
        private Transform _enemy;
        private float _lastPosition;
        private bool _facingRight;


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
            MoveToPlayer();
        }


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        /* Moves Enemy to Player */
        private void MoveToPlayer()
        {
            // Do nothing if player does not exist
            if (_player == null) return;

            _enemy = transform;
            var enemyPosition = _enemy.position;

            // It Moves to the Player
            transform.position = Vector2.MoveTowards(enemyPosition, _player.transform.position,
                speed * Time.fixedDeltaTime);

            // Handles facing-direction
            FacingDirection();

            // Saves the last position, to recognize the moveDirection
            _lastPosition = enemyPosition.x;
        }

        /* Facing enemy in the right direction */
        private void FacingDirection()
        {
            if (!(_lastPosition > transform.position.x && _facingRight) &&
                !(_lastPosition < transform.position.x && !_facingRight)) return;

            _facingRight = !_facingRight;
            var theScale = transform.localScale;
            theScale.x *= -1;
            _enemy.localScale = theScale;
        }
    }
}