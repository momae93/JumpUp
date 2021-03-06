﻿using UnityEngine;

public class GameObjectMove : MonoBehaviour {
	public float speed = 2;
	public float leftLimit = -10;
	public float rightLimit = 10;

	private Vector3 nextPosition;
	private Vector3 begin;
	private Vector3 end;

	void Start () {
		begin = new Vector3 (leftLimit, transform.position.y);
		end = new Vector3 (rightLimit, transform.position.y);
		nextPosition = begin;
	}
	
	void Update () {
		Move ();	
	}

	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, nextPosition) <= 0.1)
			nextPosition = nextPosition == begin ? end : begin;
	}
}