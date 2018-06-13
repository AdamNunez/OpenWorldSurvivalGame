using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.Network {
    [BoltGlobalBehaviour(BoltNetworkModes.Server)]
    public class ServerGlobalEvents : Bolt.GlobalEventListener
    {

        WorldItemManager WorldItemManager;


        public override void SceneLoadLocalDone(string map)
        {
            if (map == "Game")
                WorldItemManager = GameObject.Find("GameManager").GetComponent<WorldItemManager>();
        }
 
        public override void OnEvent(PlayerInteract evnt)
        {
           var Player =  PlayerRegistry.GetPlayer(evnt.RaisedBy).Character;
            WorldItemManager.GivePlayerItem(Player, evnt.ItemToInteractBoltEntityId.GetComponent<InteractableItem>().ItemData);
        }
    }

}
