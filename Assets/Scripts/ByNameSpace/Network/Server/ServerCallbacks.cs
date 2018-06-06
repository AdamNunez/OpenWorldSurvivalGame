using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Server)]
public class ServerCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadRemoteDone(BoltConnection connection)
    {
        PlayerRegistry.CreatePlayer(connection);
        PlayerRegistry.GetPlayer(connection).CreateNewPlayer();
    }

}
