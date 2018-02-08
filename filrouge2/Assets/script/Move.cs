using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float moveSpeed = 3f;
	public float jumpHeight = 10f;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		Movement();
	}
	// Update is called once per frame
	void Movement()
	{
		if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space))
			transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
	}
}
