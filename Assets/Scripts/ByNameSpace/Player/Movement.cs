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
    private float Gravity = 100f;


    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    public void CorrectPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void MovePlayer(Vector3 movementinput, Vector3 mouseinput)
    {

        // set local rotation
        transform.rotation = Quaternion.Euler(0, mouseinput.x, 0);

        Vector3 moveDirection = new Vector3(movementinput.x, 0, movementinput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;

        moveDirection.y -= Gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);
    }
   
}
