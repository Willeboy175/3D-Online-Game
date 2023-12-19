using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public DynamicInventory inventory;

    //Temporary function to pick up items
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InstanceItemContainer foundItem))
        {
            inventory.AddItem(foundItem.TakeItem());
        }
    }
}
