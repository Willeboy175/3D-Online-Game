using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DynamicInventory : ScriptableObject
{
    public int maxItems = 10;
    public List<ItemInstance> items = new();

    public bool AddItem(ItemInstance itemToAdd)
    {
        // Finds an empty slot if there is one
        /*
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                Debug.Log("Add Item");
                items[i] = itemToAdd;
                return true;
            }
        }
        */

        // Adds a new item if the inventory has space
        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            Debug.Log("Add Item");
            return true;
        }
        Debug.Log("No space in the inventory");
        return false;
    }
}
