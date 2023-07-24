using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Mouse Sensitivity
    public float mouseSensitivity = 100f;

    // The Player Body
    public Transform playerbody;

    // Rotation on the X Axis
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor is positioned in the center of the view and cannot be moved. The cursor is invisible in this state
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Detects when the player moves the mouse on the x and y axises and then multiplies them by the Mouse Sensitivity and Time.deltaTime so that it doesn't move faster at a higer fps and slower at a lower fps
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // yo
      
        xRotation -= mouseY;
        // Stops xRotation from being lower than -90 and higer than 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Actually moves the camera on the Y Axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Actually moves the camera on the X Axis
        playerbody.Rotate(Vector3.up * mouseX);
    }
}