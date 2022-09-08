using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class DeathTrap : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; private set; }

        /* PRIVATE VARIABLES */
        private int _health = 2;
        private const float AnimationTime = 0.25f;
        private const float ReduceByHit = 0.60f;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            CurrentHealth = _health;
            StartCoroutine(FlipObject());
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;

            var damageable = col.GetComponent<IDamageable>();
            if (damageable == null) return;
            damageable.ApplyDamage(1);

            Destroy(this.gameObject);
        }


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        /* Function to change scale of DeathTrap */
        private void ChangeScale(float multiplier)
        {
            var myTransform = transform;
            var scale = myTransform.localScale;
            scale.x *= multiplier;
            scale.y *= multiplier;
            myTransform.localScale = scale;
        }

        /* Creates an animation for DeathTrap */
        private IEnumerator FlipObject()
        {
            while (true)
            {
                yield return new WaitForSeconds(AnimationTime);
                ChangeScale(-1);
            }
        }

        
        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PUBLIC FUNCTIONS
         */
        
        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth == 0) Destroy(this.gameObject);
            
            ChangeScale(ReduceByHit);
        }
    }
}