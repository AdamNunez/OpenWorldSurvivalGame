using OpenWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : PlayerBehaviour {

    [SerializeField]
    private Vector3 m_OffsetFromPlayer;

    private Transform m_TargetToFollow;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalCameraRotation;
    Quaternion originalPlayerRotation;

    void Start()
    { 
        originalCameraRotation = transform.localRotation;
        originalPlayerRotation = transform.root.rotation;
    }
    public void Update()
    {
        rotationX += Player.MouseInput.Get().x;
        rotationY += Player.MouseInput.Get().y;

        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

        transform.root.rotation = originalPlayerRotation * xQuaternion;
        transform.localRotation = originalCameraRotation * yQuaternion;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }


}
