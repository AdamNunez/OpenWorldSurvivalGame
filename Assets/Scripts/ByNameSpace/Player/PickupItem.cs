using OpenWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : PlayerBehaviour

{

   private ClientNetworkEvents clientNetworkEvents;

    private void Start()
    {
        clientNetworkEvents = GetComponent<ClientNetworkEvents>();
        Player.Interact.SetTryer(CanInteract);
        Player.Interact.AddListener(Interact);
    }

    bool CanInteract()
    {
        if (Player.RaycastData.Get().collider.GetComponent<InteractableItem>() && Player.RaycastData.Get().collider.GetComponent<BoltEntity>())
          return true;
        return false;
    }

    private void Interact()
    {
        clientNetworkEvents.CreateInteractEvent(Player.RaycastData.Get().collider.GetComponent<BoltEntity>());
    }

}
