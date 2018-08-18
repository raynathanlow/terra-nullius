using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform target;
	public Vector3 distance; // Distance kept from player

	void Start () {
		distance = target.position - transform.position;
	}
	
	void Update () {
		// Follow player
		transform.position = target.position - distance;

		// Rotate camera to always point to player
		transform.LookAt(target);
	}
}
