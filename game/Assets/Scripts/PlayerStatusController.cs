﻿using UnityEngine;
using System.Collections;

public class PlayerStatusController : MonoBehaviour {

	public GameObject explosion;
	
	private void Start(){
		explosion = GameObject.FindGameObjectWithTag("explosion");
		explosion.particleSystem.Stop();
	}

	public void Update(){
		if (Input.GetKeyDown(KeyCode.End)){
			explosion.transform.position = transform.position;
			Destroy(gameObject);
			explosion.particleSystem.Play();
		}
	}
	
	public void OnDestroy() {
		GameObject managerObj = GameObject.FindGameObjectWithTag("Manager");
		Instantiate(explosion,gameObject.transform.position, Quaternion.identity);
		managerObj.SendMessage("RespawnPlayer");	
		managerObj.SendMessage("AdjustSuspicionBar", -100, SendMessageOptions.RequireReceiver);
	}
}
