using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour {

	public float lookSpeed = 15.0F;
	public float moveSpeed = 15.0F;
	//public float rotationX = 0.0F;
	public float rotationY = 0.0F;

	public float vDir = 0.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		//transform.localRotation = Quaternion.AngleAxis(rotationX, Vector2.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector2.left);
		transform.position += transform.forward*moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime;
		if (Input.GetKey("q")) vDir = 1;
		if (Input.GetKey("e")) vDir = -1;
		transform.position += transform.up*moveSpeed*vDir*Time.deltaTime;
	}
}
