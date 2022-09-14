using System;
using UnityEngine;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; private set; }

        /* SERIALIZED VARIABLES */
        [SerializeField] private int playerHealth;
        [SerializeField] private GameObject particleDeath;
        [SerializeField] private Animator cameraAnimator;

        /* PRIVATE VARIABLES */
        private AudioSource _audio;
        private IHealthBar _health;


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            CurrentHealth = playerHealth;
            _audio = GetComponent<AudioSource>();
            _health = GetComponent<IHealthBar>();
            _health.Initialize();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Enemy")) return;
            if (col.GetType() != typeof(CircleCollider2D)) return;
            
            var damageable = col.GetComponent<IDamageable>();
            if (damageable == null) return;
            ApplyDamage(1);
            damageable.ApplyDamage(3);
        }

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PUBLIC FUNCTIONS
         */

        /* Gives player damage */
        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            _health.ShowHealth(CurrentHealth);

            // Activates camera shake effect
            ShakeCamera();

            // Creates particles
            Instantiate(particleDeath, transform.position, Quaternion.identity);

            // Plays sound
            _audio.Play();

            if (CurrentHealth <= 0)
            {
                GameController.Instance.EndGame();
                
                // DIE
                Destroy(this.gameObject);
            }
        }


        // Todo: Export Function to a new Class for CameraActions
        void ShakeCamera()
        {
            cameraAnimator.SetTrigger("shake");
        }
    }
}