using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using WiimoteApi;

public class PlayerMovement : MonoBehaviour {
    enum State {
        NONE,
        TURBO,
        BRAKE
    };
	public Transform playerRot;
	// Current Wiimote
    private Wiimote wiimote;
    public float speed = 30f;
	public float turnSpeed = 30f;
    public float timer = 15.0f;
    public float xOffset = 0.2f;
    public float xMax = 0.8f;
    public float xMin = -0.7f;
    private State currentState;
    private float powerInput;
	private float turnInput;

	// Use this for initialization
	void Start() {
        // Wiimote Calibration 
		WiimoteManager.FindWiimotes( );
        if( WiimoteManager.HasWiimote( ) ) {
            wiimote = WiimoteManager.Wiimotes[ 0 ];
			wiimote.SendPlayerLED( true, false, false, false );
			wiimote.SendDataReportMode( InputDataType.REPORT_BUTTONS_ACCEL );
		}

        currentState = State.NONE;
        powerInput = 0.2f;
	}

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

		if ( WiimoteManager.HasWiimote() ) {
            // Wiimote Identification
            wiimote = WiimoteManager.Wiimotes[ 0 ];
            // Wiimote Data Read
            int response;
            do
            {
                response = wiimote.ReadWiimoteData();
            } while (response > 0);

            // Movement Management
            Vector3 accelVector = GetAccelVector( );

            // Vertical Movement
            if( accelVector.x > 0.3f && currentState == State.NONE ) {
                powerInput *= 2.0f;
                currentState = State.TURBO;
            }
            else if( accelVector.x < 0.1f && currentState == State.NONE ) {
                powerInput *= 0.5f;
                currentState = State.BRAKE;
            }
            else {
                if( currentState == State.TURBO ) {
                    powerInput *= 0.5f;
                    currentState = State.NONE;
                }
                else if( currentState == State.BRAKE ) {
                    powerInput *= 2;
                    currentState = State.NONE;
                }
            }

            //Horizontal Movement
            float moveX = accelVector.z + xOffset;
            if( moveX <= 0.2f && moveX >= -0.2f ) {
                turnInput = 0;
            }
            else if( moveX > 0.2f ) {
                turnInput = moveX / xMax;
                turnInput = turnInput > 1.0f ? 1.0f : turnInput;
            }
            else {
                turnInput = -moveX / xMin;
                turnInput = turnInput < -1.0f ? -1.0f : turnInput;
            }
        }

        if( timer <= 0 ) {
            powerInput += 0.2f;
            timer = 15.0f;
        }
	}
	
	void FixedUpdate () {
		transform.Translate( new Vector3( 0f, 0f, powerInput * speed * Time.deltaTime ) );
		transform.Translate( new Vector3( turnSpeed * turnInput * Time.deltaTime, 0f, 0f ) );
	}

	Vector3 GetAccelVector( ) {
		float[ ] accel = wiimote.Accel.GetCalibratedAccelData( );
		Vector3 accelVec = new Vector3( accel[ 0 ], -accel[ 2 ], -accel[ 1 ] ).normalized;
		return accelVec;
	}

	void OnDrawGizmos() {
        if ( wiimote != null ) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine( playerRot.position, playerRot.position + playerRot.rotation * GetAccelVector( ) * 2 );
		}
    }
}
