using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
    }

}
