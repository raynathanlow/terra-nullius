using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float distanceFromTarget;
    public float mouseSensitivity;

    public Vector2 pitchMinMax = new Vector2(-22, 85);

    private float yaw;
    private float pitch;

    private float rotationSmoothTime = .12f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    void Start () {
        distanceFromTarget = 4f;
        mouseSensitivity = 2f;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void LateUpdate () {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
