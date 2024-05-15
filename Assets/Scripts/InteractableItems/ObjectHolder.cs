using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public bool isFilled;

    public void testing(PlayerController player)
    {
        Debug.Log(player.inventory.currentSlot);

        
        if(player.inventory.inventory_items[player.inventory.currentSlot].itemType.itemName == "Red Gem")
        {
            Debug.Log("wowo");
        }
        //Store value is Filled

        // Check if the item in the current slot is 'GEM' AND that the ObjectHolder is empty
        // Update the object model/values, ect to reflect this gem, and remove from inventory


        // If ObjectHolder is not empty then update the model, and add the gem to inventory.
    }
}
