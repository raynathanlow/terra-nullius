using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private CharacterController controller;
	private Vector3 pos;
	private float moveSpeed = 8f;
	private float jumpHeight = 14f;
	private float gravityScale = 7f;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update () {
		float time = Time.deltaTime;

		// Calculate move direction
		Vector3 forward = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"); // Use whatever direction the player is facing
		forward = forward.normalized * moveSpeed; // Prevent holding two directions from doubling move speed
		float x = forward.x;
		float z = forward.z;

		// Calculate jumping and falling
		float y = pos.y;
		if (controller.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                y = jumpHeight;
            }
        } else {
            y += Physics.gravity.y * gravityScale * time;
        }

		// Set player velocity
		pos = new Vector3(x, y, z);
		controller.Move(pos * time);
	}
}
