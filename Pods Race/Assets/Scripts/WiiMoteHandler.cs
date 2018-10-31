using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class WiiMoteHandler : MonoBehaviour {
    // Current Wiimote
    private Wiimote wiimote;

	// Use this for initialization
	void Start () {

	}

    /// Update is called every frame, if the MonoBehaviour is enabled.
    void Update() {
        WiimoteManager.FindWiimotes( );

        if( WiimoteManager.HasWiimote( ) ) {
            wiimote = WiimoteManager.Wiimotes[ 0 ];
        }
    }
}
