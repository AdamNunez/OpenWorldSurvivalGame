using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGlobalCallBacks : Bolt.GlobalEventListener
{
    [SerializeField]
    GameObject PlayerCamera;
    public override void ControlOfEntityGained(BoltEntity entity)
    {
        // camera setup
        GameObject Camera =  Instantiate(PlayerCamera);
        Camera.GetComponent<PlayerCamera>().getPitch = () => entity.GetState<IPlayerState>().Pitch;
        Camera.GetComponent<PlayerCamera>().SetTarget(entity);
    }



}
