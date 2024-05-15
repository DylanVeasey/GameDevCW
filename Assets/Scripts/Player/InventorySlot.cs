using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    public Image icon;
    public InventorySlot()
    {
        icon = new Image();
        Add(icon);

        icon.AddToClassList("SlotIcon");
        AddToClassList("SlotContainer");
    }
}
