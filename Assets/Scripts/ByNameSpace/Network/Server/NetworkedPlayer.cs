using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPlayer
{

    public BoltEntity Character { get; set; }
    public BoltConnection Connection { get; set; }

    public void CreateNewPlayer()
    {
        if (!Character)
        {
            Character = BoltNetwork.Instantiate(BoltPrefabs.Player);
            Character.AssignControl(Connection);
        }

        // teleport entity to a random spawn position
        Character.transform.position = new Vector3(2, 2, 2);
    }

    public void LoadExistingPlayer()
    {
        
    }
}
