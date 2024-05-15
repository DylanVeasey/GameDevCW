using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentSlot = 0;
    public int maxItems = 5;
    public ItemInstance[] inventory_items;
    public GameObject player;

    public InventoryUIController inventoryUI;

    private void Awake()
    {
        inventory_items = new ItemInstance[maxItems];
        for (int i = 0; i < inventory_items.Length; i++)
        {
            inventory_items[i] =  new ItemInstance(null);
        }
    }

    private void Start()
    {
        inventoryUI.updateUI(inventory_items, currentSlot);
    }

    public bool AddItem(ItemInstance itemToAdd)
    {
        Debug.Log("ADDING ITEM");
        for(int i=0; i<inventory_items.Length; i++)
        {
            if (inventory_items[i].itemType == null)
            {
                inventory_items[i] = itemToAdd;

                //Update the UI
                inventoryUI.updateUI(inventory_items, currentSlot);
                

                return true;
            }
        }
        return false;
    }

    public void RemoveCurrentItem()
    {
        if (inventory_items[currentSlot].itemType != null)
        {
            //Drop Item
            ItemInstance itemToRemove = inventory_items[currentSlot];

            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;

            Vector3 spawnPos = playerPos + (playerDirection);

            GameObject droppedItem = Instantiate(itemToRemove.itemType.model, spawnPos, playerRotation, null);
            RemoveCurrentInventoryItem();
            
        }
         
    }

    public void RemoveCurrentInventoryItem()
    {
        Debug.Log("REMOVING ITEM");
        //Remove item from inventory
        inventory_items[currentSlot].itemType = null;
        //Update the UI
        inventoryUI.updateUI(inventory_items, currentSlot);
    }

    public void setCurrentSlot(int newCurrentSlot)
    {
        foreach(ItemInstance item in inventory_items)
        {
            Debug.Log(item);
        }
        currentSlot = newCurrentSlot;
        //Update the UI
        inventoryUI.updateUI(inventory_items,currentSlot);
    }

}
