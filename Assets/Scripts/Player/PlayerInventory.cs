using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        /* SERIALIZED VARIABLES */
        [SerializeField] private int inventorySize = 3;

        /* PRIVATE VARIABLES */
        private List<IPickableItem> _items;


        /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
         *  UNITY FUNCTIONS
         */
        private void Awake()
        {
            _items = new List<IPickableItem>();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E)) return;

            if (_items.Count == 0) return;
            Debug.Log(_items.Count);

            var lastItemIndex = _items.Count - 1;
            var lastItem = _items[lastItemIndex];
            
            lastItem.UseItem(null);
            _items.Remove(lastItem);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Check if collider is an PickableItem
            var pickableItem = col.GetComponent<IPickableItem>();
            if (pickableItem == null) return;

            // Return if Inventory is full
            if (_items.Count >= inventorySize) return;

            // Pick item and add it to the inventory
            pickableItem.PickItem();
            _items.Add(pickableItem);
        }
    }
}