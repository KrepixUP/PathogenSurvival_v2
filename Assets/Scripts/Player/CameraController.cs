using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    Rigidbody RB;

    public Transform Camera;
    public float Sensitivity = 200;
    float xRotation = 90;
    
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseX);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Camera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;




        if (MouseX == 0) {
            RB.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else {
            RB.constraints = RigidbodyConstraints.None;
            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

    }

}
