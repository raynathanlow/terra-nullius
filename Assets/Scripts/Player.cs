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
		// Player movement
		float time = Time.deltaTime;
		float x = Input.GetAxis("Horizontal") * moveSpeed;
		float z = Input.GetAxis("Vertical") * moveSpeed;
		float y = pos.y;
		if (controller.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                y = jumpHeight;
            }
        } else {
            y += Physics.gravity.y * gravityScale * time;
        }
		pos = new Vector3(x, y, z);
		controller.Move(pos * time);
	}
}
