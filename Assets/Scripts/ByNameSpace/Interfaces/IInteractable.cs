using OpenWorld.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool CanBePickedUp { get; }

    int GetQuantityLeft { get; }

    string GetItemDescription { get; }

}
