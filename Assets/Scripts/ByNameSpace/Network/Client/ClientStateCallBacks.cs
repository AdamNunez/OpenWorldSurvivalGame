using Bolt;
using OpenWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientStateCallBacks : PlayerBehaviour
{
    [SerializeField]
    GameObject m_GameUI;
    private void Start()
    {
        if (!GetComponent<BoltEntity>().isControllerOrOwner)
            return;

        Player.movement = GetComponent<Movement>();
        GameObject GameUI =  Instantiate(m_GameUI);
        Player.Inventory = GameUI.GetComponent<Inventory>();
    }

    public override void Attached()
    {
        state.SetTransforms(state.PlayerTransform, transform);
    }

    public override void ExecuteCommand(Command command, bool resetState)
    {
        PlayerInputCommands cmd = (PlayerInputCommands)command;

        if (resetState)
        {
            // we got a correction from the server, reset (this only runs on the client)
            Player.movement.CorrectPosition(cmd.Result.Position);
        }
        else
        {
            if (entity.isOwner)
            {
                state.Pitch = cmd.Input.MouseMovement.y;
            }

                // apply movement (this runs on both server and client)
                Player.movement.MovePlayer(cmd.Input.MovementInput, cmd.Input.MouseMovement);

            // copy the motor state to the commands result (this gets sent back to the client)
            cmd.Result.Position = transform.position;
        }
    }
}
