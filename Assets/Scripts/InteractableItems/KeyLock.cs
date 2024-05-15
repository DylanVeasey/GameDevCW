using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Door))]
public class KeyLock : MonoBehaviour
{
    public ItemData key_unlock;

    public void TryUnlock()
    {
        Door door = GetComponent<Door>();
        GameObject player = GameObject.Find("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        ItemData currentItem = inventory.inventory_items[inventory.currentSlot].itemType;
        if(currentItem != null) 
        {
            if (currentItem == key_unlock)
            {
                door.b_isBlocked = false;
                door.Interact();
                inventory.RemoveCurrentInventoryItem();
            }
            else
            {
                door.Rattle();
            }
        }
        else
        {
            door.Rattle();
        }     
    }
}
