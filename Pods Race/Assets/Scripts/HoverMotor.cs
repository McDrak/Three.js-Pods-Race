using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour {
	public float hoverForce = 75f;
	public float hoverHeight = 3.5f;
	private Rigidbody carRigidbody;

	void Awake () {
		carRigidbody = GetComponent<Rigidbody>( );
	}
	
	void Update () {
        
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
	}
}
