using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Bomb : MonoBehaviour, IPickableItem
    {
        public CircleCollider2D circleCollider2D;
        public GameObject bombPrefab;
        private bool isActive;
        
        private void Explode()
        {
            circleCollider2D.enabled = true;
            Debug.Log("Bombe aktiv");
            // EXPLODE
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!isActive) return;
            
            var damageable = col.GetComponent<IDamageable>();
            if (damageable == null) return;
            
            damageable.ApplyDamage(3);
            Destroy(this.gameObject);
        }

        public void PickItem()
        {
            Debug.Log("PICKED UP ITEM");
            Destroy(gameObject);
        }

        public void UseItem(Vector2? pos)
        {
            Debug.Log("PLACED ITEM");
            isActive = true;
        }


    }
}