using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraHolder;
    float mouseSensitivity = 2.5f;
    float cameraPitch = 0.0f;

    void mouseUpdate() {
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraPitch -= mouseMovement.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -75.0f, 75.0f); //Clamp range of camera pitch between 75 and -75
        cameraHolder.localEulerAngles = new Vector3(cameraPitch, 0, 0);
        transform.Rotate(Vector3.up * mouseMovement.x * mouseSensitivity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseUpdate();
    }
}