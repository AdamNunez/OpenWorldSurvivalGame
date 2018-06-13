using OpenWorld.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlot : MonoBehaviour, ISlot
{

    [SerializeField]
    private Enums.SlotType m_SlotType = Enums.SlotType.Inventory;
    public Enums.SlotType SlotType { get { return m_SlotType; } }

    public bool HasItem { get; private set; }

    public Item ItemData { get; private set; }

    public int ItemId { get { return ItemData.Id;  } }

    public int MaxStackSize { get { return ItemData.MaxStackSize; } }


    public void AddItem(Item itemToAdd)
    {
        ItemData = itemToAdd;
        HasItem = true;
    }

}
