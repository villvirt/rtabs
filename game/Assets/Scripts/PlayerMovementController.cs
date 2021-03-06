﻿using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {
	private int speed = 50;
	public int maxspeed = 5;
	private int jumps_left;
	public int max_jumps = 1;
	public float jumpspeed = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//		Jumping
		
		if (Input.GetButtonDown("Jump"))	{
			if(jumps_left > 0)	{
				rigidbody.velocity = rigidbody.velocity + new Vector3 (0f, jumpspeed, 0f);
				jumps_left--;
			}
		}
	

		
	}

	void FixedUpdate() {
		if (Input.GetAxis ("Horizontal") < 0){
			if(rigidbody.velocity.magnitude < maxspeed)
				rigidbody.AddForce (new Vector3(0, 0, speed));
		}
		if (Input.GetAxis ("Horizontal") > 0){
			if(rigidbody.velocity.magnitude < maxspeed)
				rigidbody.AddForce (new Vector3(0, 0, (-1) * speed));
		}
		if (Input.GetAxis ("Vertical") < 0 ){
			if(rigidbody.velocity.magnitude < maxspeed)
				rigidbody.AddForce (new Vector3((-1) * speed, 0, 0));
		}
		if (Input.GetAxis ("Vertical") > 0 ){
			if(rigidbody.velocity.magnitude < maxspeed)
				rigidbody.AddForce (new Vector3(speed, 0, 0));
		}
	}

//		When to allow the player to jump again
	void OnCollisionEnter(Collision target)	{	
		if(target.gameObject.tag == "floor")	{
			jumps_left = max_jumps;
		}
	}
}
