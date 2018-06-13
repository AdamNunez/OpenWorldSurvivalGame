using OpenWorld.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InvSlot[] InvSlots;

    private void Start()
    {
        InvSlots = GetComponentsInChildren<InvSlot>(true);
    }

    public void AddItemToSlot(Item itemToAdd)
    {
        InvSlot emptySlot = GetEmptySlot();
        if (emptySlot)
            emptySlot.AddItem(itemToAdd);

    }

    public InvSlot GetEmptySlot()
    {
        return InvSlots.FirstOrDefault(slot => slot.HasItem == false);
    }
}
