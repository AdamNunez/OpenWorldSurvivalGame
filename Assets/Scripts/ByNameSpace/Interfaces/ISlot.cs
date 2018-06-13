using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlot
{
     Enums.SlotType SlotType { get; }

    bool HasItem { get; }

    int MaxStackSize { get; }

    int ItemId { get; }


}
