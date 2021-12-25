using UnityEngine;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        /* SERIALIZED VARIABLES */
        [SerializeField] private GameObject projectile;
        [SerializeField] private GameObject particleShooting;
        [SerializeField] [Range(0, 0.5f)] private float weaponFireRate;

        /* PRIVATE VARIABLES */
        private const int WeaponOffset = (-90);
        private Camera _camera;
        private AudioSource _audio;
        private Transform _shotPoint;
        private float _weaponFireTimer;

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */

        private void Awake()
        {
            // Loads first child of weapon which it's his shotPoint
            _shotPoint = transform.GetChild(0);

            _camera = Camera.main;
            _audio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            transform.rotation = WeaponDirection();

            FireWeaponWithFireRate();
        }

        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  PRIVATE FUNCTIONS
         */

        /* Calculates rotation for weapon to look in the mouse-direction */
        private Quaternion WeaponDirection()
        {
            var difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotZ + WeaponOffset);
        }

        /* Handles weapon-shooting with fireRate */
        private void FireWeaponWithFireRate()
        {
            if (_weaponFireTimer <= 0)
            {
                // Left Mouseclick for shooting
                if (!Input.GetMouseButton(0)) return;

                var shotPointPosition = _shotPoint.position;
                // Creates shooting-particles
                Instantiate(particleShooting, shotPointPosition, Quaternion.identity);
                // Creates projectile-prefab
                Instantiate(projectile, shotPointPosition, transform.rotation);

                // Plays shot-audio
                _audio.Play();

                // Resets FireRateTimer
                _weaponFireTimer = weaponFireRate;
            }
            else
            {
                _weaponFireTimer -= Time.deltaTime;
            }
        }
    }
}