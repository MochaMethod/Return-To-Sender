﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringUpOnCollision))]
public class PlayerController : MonoBehaviour {
	public float moveSpeed, rotateSpeed, jumpSpeed;
	public GameObject cameraPosition;
	public GameObject cameraTarget;
	public Camera camera;
	public Transform rotationBone;
	private SpringUpOnCollision spring;


	// Use this for initialization
	void Start () {
		spring = GetComponent<SpringUpOnCollision>();

		Cursor.visible = false;
	}
	
	void FixedUpdate () {
		camera.transform.position = cameraPosition.transform.position;	
		camera.transform.LookAt(cameraTarget.transform);

		var x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.fixedDeltaTime * moveSpeed;

		//spring.rootBone.transform.Translate(0, 0, z);

        //spring.rootBone.Rotate(0, x, 0);

		if (Input.GetKeyUp("space")) {
			spring.rootBone.GetComponent<Rigidbody>().AddForce(spring.rootBone.up * jumpSpeed, ForceMode.Impulse);
		}
	}
}
