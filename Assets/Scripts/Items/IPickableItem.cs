using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public interface IPickableItem
    {
        public void PickItem();
        public void UseItem(Vector2? pos);
    }
}