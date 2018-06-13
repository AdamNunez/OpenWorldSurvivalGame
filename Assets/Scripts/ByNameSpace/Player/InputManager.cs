
using OpenWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : PlayerBehaviour
{

    [SerializeField]
    float m_LookSensitivity = 8f;
    [SerializeField]
    float m_minLookDown = -85f;
    [SerializeField]
    float m_MaxLookUp = 85f;

    private float MouseX;
    private float MouseY;

    public override void SimulateController()
    {

        PollKeys(false);

        IPlayerInputCommandsInput input = PlayerInputCommands.Create();
        input.MouseMovement = new Vector3(MouseX, MouseY);
        input.MovementInput = new Vector3(Player.MovementInput.Get().x, Player.MovementInput.Get().y);

        entity.QueueInput(input);
    }

    private void Update()
    {
        PollKeys(true);
    }

    public void PollKeys(bool mouse)
    {
        Player.MovementInput.Set(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        if (Input.GetButtonDown("Interact"))
            Player.Interact.Try();

        if (!mouse)
            return;

        MouseX += (Input.GetAxisRaw("Mouse X") * m_LookSensitivity);
        MouseX %= 360f;

        MouseY += (-Input.GetAxisRaw("Mouse Y") * m_LookSensitivity);
        MouseY = Mathf.Clamp(MouseY, m_minLookDown, m_MaxLookUp);

        Player.MouseInput.Set(new Vector2(0, MouseY));
    }
}
