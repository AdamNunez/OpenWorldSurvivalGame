using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientNetworkEvents : Bolt.GlobalEventListener
{
    public void CreateInteractEvent(BoltEntity itemEntity)
    {
        var playerInteract = PlayerInteract.Create(Bolt.GlobalTargets.OnlyServer);
        playerInteract.ItemToInteractBoltEntityId = itemEntity;
        playerInteract.Send();
    }
}
