using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour {
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		// Checks if the player is active
		if( player.activeSelf ) {
			// Updates Camera position acording to the Player position
			transform.position = new Vector3( player.transform.position.x, player.transform.position.y + 3.5f, player.transform.position.z - 7.0f );
		}
	}
}
