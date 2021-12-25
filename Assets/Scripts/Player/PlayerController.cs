using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        /* SERIALIZED VARIABLES */
        [SerializeField] private float playerSpeed;

        /* PRIVATE VARIABLES */
        private Animator _playerAnimator;
        private Rigidbody2D _playerRigidbody2D;
        private Vector2 _playerMoveVelocity;
        private bool _playerFacingRight;
        private Camera _playerCamera;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _playerCamera = Camera.main;
        }

        private void Update()
        {
            _playerMoveVelocity = HandleMoveInput();
            FacingPlayerToMouseDirection();
        }

        private void FixedUpdate()
        {
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerMoveVelocity * Time.fixedDeltaTime);
        }

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        /* Handles user input for player movement (Axis-Input : WASD) */
        private Vector2 HandleMoveInput()
        {
            // Creates new Vector2 with player input
            var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Activates player-animation if player is moving
            _playerAnimator.speed = moveInput.magnitude;

            // Returns normalized input (1 or -1) multiplied with playerSpeed
            return moveInput.normalized * playerSpeed;
        }

        /* Facing player to the mouse direction */
        private void FacingPlayerToMouseDirection()
        {
            try
            {
                var mousePosition = _playerCamera.ScreenToWorldPoint(Input.mousePosition).x;
                if (mousePosition < transform.position.x && _playerFacingRight)
                {
                    Flip();
                }

                if (mousePosition > transform.position.x && !_playerFacingRight)
                {
                    Flip();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /* Flips the facing direction of the player */
        private void Flip()
        {
            _playerFacingRight = !_playerFacingRight;

            var playerTransform = transform;

            Vector3 theScale = playerTransform.localScale;
            theScale.x *= -1;
            playerTransform.localScale = theScale;
        }
    }
}