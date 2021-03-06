﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCameraCollision : MonoBehaviour {
	public float minDistance = 1.0f;
    public float maxDistance = 2.5f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public float distance;

	// Use this for initialization
	void Awake () {
		dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 desiredCameraPosition = transform.parent.TransformPoint( dollyDir * maxDistance );

        RaycastHit hit;
        if( Physics.Linecast ( transform.parent.position, desiredCameraPosition, out hit ) ) {
            distance = Mathf.Clamp( (hit.distance * 0.9f ), minDistance, maxDistance );
        }
        else {
            distance = maxDistance;
        }
        
        transform.localPosition = Vector3.Lerp( transform.localPosition, dollyDir * distance, Time.deltaTime * smooth );
	}
}
