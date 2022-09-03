using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public Transform cameraHolder;
    public float maxCameraPitch = 90;
    public float sensitivity = 2f;
    Vector2 camVec;

    void SetCameraVector(Vector2 vec) {
        camVec = vec;
    }
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate() {
        camVec = new Vector2(camVec.x, Mathf.Clamp(camVec.y, -maxCameraPitch, maxCameraPitch));
        transform.Rotate(transform.up * camVec.x * sensitivity * Time.deltaTime);
        cameraHolder.localEulerAngles = new Vector3(camVec.y * (sensitivity * Time.deltaTime), 0, 0);
    }
}