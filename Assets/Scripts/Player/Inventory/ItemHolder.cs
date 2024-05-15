using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour, IInteractable
{
    // Stores a list of acceptable items as itemData
    public List<ItemData> accepted_items = new();

    // Store the current state of the itemHolder
    public bool isFilled = false;
    public ItemData item_contained;

    // TODO: Get this from the player
    public Inventory inventory;


    public GameObject[] GameObjects;
    public LockedLever lockedLever;

    [field: SerializeField] public bool b_canInteract { get; set; }
    [field: SerializeField] public bool b_isBlocked { get; set; }

    private int currentState = -1;
    private int index;

    private GameObject gem;

    public delegate void ResetHandler();

    public event ResetHandler Reset;

    public void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void FailedInteract()
    {
        //RATTLE
        Debug.Log("Failed Interact");
    }

    public void Interact()
    {
        Debug.Log("HERE");
        if (isFilled)
        {
            Debug.Log("IS FILLED");
            inventory.AddItem(new ItemInstance(item_contained));
            Destroy(gem);
            // check if the players current inventory slot if empty
            // If it is, empty the itemHolder and add the object to the players inventory

            // If it is not, do nothing
            currentState = -1;
            isFilled = false;
        }
        //If the item holder does not contain anything
        else
        {
            index = 0;
            // Check if the player's current inventory slot contains an item that is contained in the accepted_items list
            foreach (ItemData item in accepted_items)
            {
                
                // TODO: handle this event if there are no items in the inventory
                if (inventory.inventory_items[inventory.currentSlot].itemType == item)
                {
                    currentState = index + 1;
                    Debug.Log("ADD ITEM");
                    // If it does, then remove the item from the inventory and add it to the item holder
                    inventory.RemoveCurrentInventoryItem();
                    item_contained = item;
                    
                    gem = Instantiate(GameObjects[index], gameObject.transform, false);
                    isFilled = true;
                }
                Debug.Log(isFilled);
                index += 1;
            }
            // If it does not, do nothing
        }
    }

    public int getState()
    {
        return currentState;
    }
}
