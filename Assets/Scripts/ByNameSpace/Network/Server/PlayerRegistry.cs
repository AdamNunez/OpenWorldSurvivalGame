using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PlayerRegistry
{
    static List<NetworkedPlayer> networkedPlayers = new List<NetworkedPlayer>();

    public static NetworkedPlayer CreatePlayer(BoltConnection boltConnection)
    {
        NetworkedPlayer networkedPlayer = new NetworkedPlayer();

        networkedPlayer.Connection = boltConnection;
        networkedPlayer.Connection.UserData = networkedPlayer;

        networkedPlayers.Add(networkedPlayer);

        return networkedPlayer;
    }

    public static NetworkedPlayer GetPlayer(BoltConnection boltConnection)
    {
       return networkedPlayers.Where(np => np.Connection == boltConnection).FirstOrDefault();
    }
}
