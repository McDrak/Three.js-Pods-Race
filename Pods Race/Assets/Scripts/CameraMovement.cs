using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float cameraMoveSpeed = 120.0f;
	public float clampAngle = 60.0f;
	public GameObject cameraFollow;
	public float inputSensitivity = 150.0f;
	public GameObject playerObj;
	public float mouseX;
	public float mouseY;
	private float rotationX;
	private float rotationY;

	// Use this for initialization
	void Start () {
		rotationX = 0.0f;
		rotationY = 0.0f;

		Vector3 rot = transform.localRotation.eulerAngles;
		rotationX = rot.x;
		rotationY = rot.y;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.GetAxis( "Mouse X" );
		mouseY = Input.GetAxis( "Mouse Y" );

		rotationY += mouseX * inputSensitivity * Time.deltaTime;
		rotationX += mouseY * inputSensitivity * Time.deltaTime;

		rotationY = Mathf.Clamp( rotationY, -clampAngle, clampAngle );
		rotationX = Mathf.Clamp( rotationX, -clampAngle, clampAngle );

		Quaternion localRotation = Quaternion.Euler( rotationX, rotationY, 0.0f );
		transform.rotation = localRotation;
	}

	void LateUpdate( ) {
		if( playerObj.activeSelf ) {
			CameraUpdater( );
		}
	}

	void CameraUpdater( ) {
		Transform target = cameraFollow.transform;
		float step = cameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards( transform.position, target.position, step );
	}
}
