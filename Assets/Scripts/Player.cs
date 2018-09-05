using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Input Settings")]
	public KeyCode ForwardInput = KeyCode.W; 
	public KeyCode BackwardInput = KeyCode.S;
	public KeyCode LeftInput = KeyCode.A;
	public KeyCode RightInput = KeyCode.D;

	public float movementSpeed = 0.3f;

	void Start () {
		
	}

	void FixedUpdate () {
		
		// Up, Down.
		if (Input.GetKey (ForwardInput)) {
			transform.position += Vector3.forward * movementSpeed;
		}
		else if (Input.GetKey (BackwardInput)) {
			transform.position += Vector3.back * movementSpeed;
		}
		// Left, Right.
		if (Input.GetKey (LeftInput)) {
			transform.position += Vector3.left * movementSpeed;
		}
		else if (Input.GetKey (RightInput)) {
			transform.position += Vector3.right * movementSpeed;
		}
	}
}
