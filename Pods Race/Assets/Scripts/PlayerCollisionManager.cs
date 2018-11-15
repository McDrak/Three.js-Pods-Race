using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour {
    public GameObject particle;

	void OnCollisionEnter( Collision other ) {
        Instantiate( particle, transform.position, new Quaternion( 0.0f, 0.0f, 0.0f, 1 ) );
        FindObjectOfType< GameManager >( ).EndGame( );
    }
}
