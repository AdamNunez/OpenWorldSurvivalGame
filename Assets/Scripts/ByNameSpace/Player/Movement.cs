using Bolt;
using OpenWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerBehaviour
{
    [SerializeField]
    private float Speed= 5;
    [SerializeField]
    private float Gravity = 20f;
    

    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
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
            this.CorrectPosition(cmd.Result.Position);
        }
        else
        {
            // apply movement (this runs on both server and client)
            Vector3 ccPosition = MovePlayer(cmd.Input.MovementInput);

            // copy the motor state to the commands result (this gets sent back to the client)
            cmd.Result.Position = ccPosition;
        }
    }
    public void CorrectPosition(Vector3 position)
    {
        transform.position = position;
    }

    public Vector3 MovePlayer(Vector3 movementInput)
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;

        moveDirection.y -= Gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);

        return transform.position;
    }
   
}
