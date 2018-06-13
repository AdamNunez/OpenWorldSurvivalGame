using OpenWorld.EventSystem;
using OpenWorld.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemManager : Bolt.GlobalEventListener {

    [SerializeField]
    private ItemDatabase itemDatabase;
    private RespawnHandler respawnHandler;
    private void Start()
    {
        respawnHandler = GetComponent<RespawnHandler>();
        for (int i = 0; i < 10; i++)
            SpawnItem();
    }
    public void GivePlayerItem(BoltEntity player, Item item)
    {
        player.GetComponent<PlayerEventHandler>().Inventory.AddItemToSlot(item);
    }

    private void SpawnItem()
    {
        var Itemdata = itemDatabase.GetWorldItem("Wood");
       Vector3 newSpawn = respawnHandler.GenerateSpawnPointTerrain();
       Instantiate(Itemdata);
    }
	
}
