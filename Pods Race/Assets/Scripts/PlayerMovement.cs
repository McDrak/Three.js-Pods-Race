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

    public GameObject playerMesh;
    public float roll;
    public float rotationSpeed = 750.0f;
    public float maxRotationAngle = 45.0f;

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
    private float powerMod;

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
        powerMod = 0.2f;
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
                playerMesh.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, 0.0f );
            }
            else if( moveX > 0.2f ) {
                turnInput = moveX / xMax;
                turnInput = turnInput > 1.0f ? 1.0f : turnInput;

                roll = rotationSpeed * Time.deltaTime * -turnInput;
                playerMesh.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, roll );
            }
            else {
                turnInput = -moveX / xMin;
                turnInput = turnInput < -1.0f ? -1.0f : turnInput;

                roll = rotationSpeed * Time.deltaTime * -turnInput;
                playerMesh.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, roll );
            }
        }

        if( timer <= 0 ) {
            powerInput += powerMod;
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

    void OnCollisionEnter(Collision other) {
        powerInput = 0;
        powerMod = 0;
    }
}
