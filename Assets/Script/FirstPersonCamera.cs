using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 300.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;

    private bool IsFirstPersonCameraEnabled = false;

    public void FirstPersonCameraEnabled(bool enabled)
    {
        IsFirstPersonCameraEnabled = enabled;
        if(IsFirstPersonCameraEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;

            xRotation = 0.0f;
            yRotation = 0.0f;
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        if (!IsFirstPersonCameraEnabled)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
