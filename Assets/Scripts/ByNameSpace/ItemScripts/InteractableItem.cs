using System.Collections;
using System.Collections.Generic;
using OpenWorld.Models;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{

    [SerializeField]
    private bool m_CanBePickedUp;

    private int Quantity;

    public Item ItemData { get; private set; }

    public bool CanBePickedUp { get { return m_CanBePickedUp;  } }

    public string GetItemDescription { get{ return ItemData.Description; } }

    public int GetQuantityLeft { get { return Quantity; } }

    public void AddItemData(Item setItemData)
    {
        ItemData = setItemData;
        Quantity = Random.Range(1, 20);
    }
}
