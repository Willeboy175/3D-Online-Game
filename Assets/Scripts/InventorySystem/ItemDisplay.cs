using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public int itemIndex;
    public Image image;

    public void UpdateItemDisplay(Sprite newSprite, int newItemIndex)
    {
        //Sets image to itemIcon
        //Sets itemIndex
        image.sprite = newSprite;
        itemIndex = newItemIndex;
    }

    public void DropFromInventory(InventoryDisplay inventoryDisplay)
    {
        //Drops item on this slot
        inventoryDisplay.DropItem(itemIndex);
    }
}
