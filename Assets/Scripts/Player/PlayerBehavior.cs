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