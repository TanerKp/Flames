﻿using System;
using UnityEngine;

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

        private void Awake()
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

        /* Gives player damage */
        private void DamagePlayer()
        {
            // Activates camera shake effect
            ShakeCamera();

            // Creates particles
            Instantiate(particleDeath, transform.position, Quaternion.identity);
            
            // Plays sound
            _audio.Play();
            
            // Takes 1 hearth from his health
            _health.TakeDamage(1);
            
            if (_health.isDead) Destroy(this.gameObject);
        }

        
        // Todo: Export Function to a new Class for CameraActions
        void ShakeCamera()
        {
            cameraAnimator.SetTrigger("shake");
        }
    }
}