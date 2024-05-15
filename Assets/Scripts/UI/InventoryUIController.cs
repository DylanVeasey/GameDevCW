using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
    public List<InventorySlot> UIinventory_items = new List<InventorySlot>();

    private VisualElement m_root;
    private VisualElement m_SlotContainer;
    private Label m_HealthLabel;


    private void Awake()
    {
        m_root = GetComponent<UIDocument>().rootVisualElement;
        m_SlotContainer = m_root.Q<VisualElement>("SlotContainer");
        m_HealthLabel = m_root.Q<Label>("HealthLabel");


        for (int i=0; i<3; i++)
        {
            InventorySlot item = new InventorySlot();
            UIinventory_items.Add(item);
            m_SlotContainer.Add(item);
        }
    }

    public void updateUI(ItemInstance[] inventory_items, int currentSlot)
    { 
        for (int i=0; i<inventory_items.Length; i++)
        {
            if (inventory_items[i].itemType != null)
            {
                UIinventory_items[i].style.backgroundImage = new StyleBackground(inventory_items[i].itemType.icon);
            }
            else
            {
                UIinventory_items[i].style.backgroundImage = null;
            }
            if (i == currentSlot)
            {
                UIinventory_items[i].icon.AddToClassList("ActiveSlotIcon");
            }
            else
            {
                UIinventory_items[i].icon.RemoveFromClassList("ActiveSlotIcon");
            }
        }
    }

    public void updateUI(int playerHealth)
    {
        m_HealthLabel.text = "Health: " + playerHealth;
    }
}
