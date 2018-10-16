using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 30f;
	public float turnSpeed = 30f;
    private float powerInput;
	private float turnInput;

	// Use this for initialization
	void Update () {
		powerInput = Input.GetAxis( "Vertical" );
		turnInput = Input.GetAxis( "Horizontal" );
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate( new Vector3( 0f, 0f, powerInput * speed * Time.deltaTime ) );
		transform.Translate( new Vector3( turnSpeed * turnInput * Time.deltaTime, 0f, 0f ) );
	}
}
