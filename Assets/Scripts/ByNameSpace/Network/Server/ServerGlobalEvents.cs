using OpenWorld.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.Network {
    [BoltGlobalBehaviour(BoltNetworkModes.Server)]
    public class ServerNetworkEvents : Bolt.GlobalEventListener {

        public override void OnEvent(PlayerInteract evnt)
        {
            var Player = PlayerRegistry.GetPlayer(evnt.RaisedBy).Character;

            Player.GetComponent<PlayerEventHandler>().Inventory.AddItemToSlot(evnt.ItemToInteractBoltEntityId.GetComponent<InteractableItem>().ItemData);
        }

    }
}
