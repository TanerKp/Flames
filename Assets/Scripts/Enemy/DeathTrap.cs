using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class DeathTrap : MonoBehaviour
    {
        /* PRIVATE VARIABLES */
        private int _health = 2;
        private const float AnimationTime = 0.25f;
        private const float ReduceByHit = 0.60f;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            StartCoroutine(FlipObject());
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

        /* Reduces scale of DeathTrap if its getting hit */
        public void ReduceScale()
        {
            // Takes 1 health
            _health--;

            // Destroys if DeathTrap has no health anymore
            if (_health == 0) Destroy(this.gameObject);
            
            // Reduces scale of the Deathtrap
            ChangeScale(ReduceByHit);
        }
    }
}