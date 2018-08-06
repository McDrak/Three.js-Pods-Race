using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour {
	public float speed = 30f;
	public float turnSpeed = 30f;
	public float hoverForce = 75f;
	public float hoverHeight = 3.5f;

	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidbody;

	void Awake () {
		carRigidbody = GetComponent<Rigidbody>( );
	}
	
	void Update () {
		powerInput = Input.GetAxis( "Vertical" );
		turnInput = Input.GetAxis( "Horizontal" );
	}

	void FixedUpdate( ) {
		Ray ray = new Ray( transform.position, -transform.up );
		RaycastHit hit;

		// Hover Check
		if( Physics.Raycast( ray, out hit, hoverHeight ) ) {
			float proportionalHeight = ( hoverHeight - hit.distance ) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce( appliedHoverForce, ForceMode.Acceleration );
		}

		transform.Translate( new Vector3( 0f, 0f, powerInput * speed * Time.deltaTime ) );
		transform.Translate( new Vector3( turnSpeed * turnInput * Time.deltaTime, 0f, 0f ) );
	}
}
