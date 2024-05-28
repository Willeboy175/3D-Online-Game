using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryDisplay : MonoBehaviour
{
    public DynamicInventory inventory;
    public ItemDisplay[] slots;

    private void Start()
    {
        UpdateInventory();
    }

    private void Update()
    {
        UpdateInventory();

        if (Input.GetKeyDown(KeyCode.E))
        {
            DropItem(0);
        }
    }

    void UpdateInventory()
    {
        //Cycles through all slots in inventory
        for (int i = 0; i < slots.Length; i++)
        {
            //If slot is occupied by an item
            if (i < inventory.items.Count)
            {
                //Sets slot active
                //Updates itemDisplay
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].itemType.icon, i);
            }
            else
            {
                //Sets slot inactive
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    public void DropItem(int itemIndex)
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        //Creates a new object
        //Adds a rigidbody
        //Adds itemInstance to the instanceItemContainer
        //Instantiates gameobject with items model
        //GameObject droppedItem = new GameObject();
        //droppedItem.AddComponent<Rigidbody>();
        //droppedItem.AddComponent<InstanceItemContainer>().item = inventory.items[itemIndex];
        GameObject itemModel = Instantiate(inventory.items[itemIndex].itemType.model, player.transform.position + player.transform.forward, player.transform.rotation);

        //Removes the item from the inventory
        inventory.items.RemoveAt(itemIndex);

        //Updates the inventory again
        //UpdateInventory();
    }
}
