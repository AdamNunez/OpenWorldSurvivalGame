using OpenWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : PlayerBehaviour
{
    public override void SimulateController()
    {
        IPlayerInputCommandsInput input = PlayerInputCommands.Create();

        input.MovementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        entity.QueueInput(input);
    }
}
