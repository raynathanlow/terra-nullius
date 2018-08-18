using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform target;
	
	public Transform pivot;
	private Vector3 distance; // Distance kept from player
	private float rotateSpeed = 5f; // Speed to rotate around player

	void Start () {
		distance = target.position - transform.position;

		pivot.transform.position = target.transform.position; // Go where the target is in the world
		pivot.transform.parent = target.transform; // Make pivot a child of the player

		Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor to the center of the window
	}
	
	// LateUpdate happens after Update, to prevent jerky player movements
	void LateUpdate () {
		// Rotate player around mouse position
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.Rotate(0f, horizontal, 0f);
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
		pivot.Rotate(-vertical, 0f, 0f);

		// Follow and rotate camera around player rotation
		float desiredYAngle = target.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0f);
		transform.position = target.position - (rotation * distance);

		// Clamp camera rotation
		if (transform.position.y < target.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
		}

		// Rotate camera to always point to player
		transform.LookAt(target);
	}
}
