using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        /*
         *  Todo:
         *  -   Create deathSound
         */

        /* PUBLIC VARIABLES */
        public GameObject particleDeath;
        public Animator cameraAnimator;

        /* PRIVATE VARIABLES */
        private AudioSource _audio;
        private HealthBar _health;


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _health = GetComponent<HealthBar>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollideWithTraps(collision);
            OnCollideWithEnemy(collision);
        }


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        /* On collide with enemy traps */
        private void OnCollideWithTraps(Collider2D c)
        {
            if (!c.CompareTag("Traps")) return;

            // Takes 1 damage from player
            DamagePlayer();
        }

        /* On collide with enemy */
        private void OnCollideWithEnemy(Collider2D c)
        {
            if (!c.CompareTag("Enemy")) return;

            // Only attack if enemy is in the near of the player
            if (c.transform.position.y < transform.position.y - 0.75f)
            {
                DamagePlayer();
            }

            // Enemy explodes after attacking player
            c.GetComponent<HealthBar>().isDead = true;
        }

        /* Checks if player has health otherwise it kills him */
        private void CheckPlayerHealth()
        {
            if (!_health.isDead) return;
            Destroy(this.gameObject);
        }

        /* Gives player damage */
        void DamagePlayer()
        {
            Console.WriteLine("CHECKED?");
            // Activates camera shake effect
            ShakeCamera();

            // Creates particles
            Instantiate(particleDeath, transform.position, Quaternion.identity);
            
            // Plays sound
            _audio.Play();
            
            // Takes 1 hearth from his health
            _health.TakeDamage(1);
        }

        
        // Todo: Export Function to a new Class for CameraActions
        void ShakeCamera()
        {
            cameraAnimator.SetTrigger("shake");
        }
    }
}