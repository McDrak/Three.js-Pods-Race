using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using WiimoteApi;

public class PlayerMovement : MonoBehaviour {
	public Transform playerRot;
	// Current Wiimote
    private Wiimote wiimote;
    public float speed = 30f;
	public float turnSpeed = 30f;
    private float powerInput;
	private float turnInput;

	// Use this for initialization
	void Start() {
		WiimoteManager.FindWiimotes( );

        if( WiimoteManager.HasWiimote( ) ) {
            wiimote = WiimoteManager.Wiimotes[ 0 ];
			wiimote.SendPlayerLED( true, false, false, false );
			wiimote.SendDataReportMode( InputDataType.REPORT_BUTTONS_ACCEL );
		}
	}

	void Update () {
		if (!WiimoteManager.HasWiimote()) { return; }

		wiimote = WiimoteManager.Wiimotes[ 0 ];

        int ret;
        do
        {
            ret = wiimote.ReadWiimoteData();

            if (ret > 0 && wiimote.current_ext == ExtensionController.MOTIONPLUS) {
                Vector3 offset = new Vector3(  -wiimote.MotionPlus.PitchSpeed,
                                                wiimote.MotionPlus.YawSpeed,
                                                wiimote.MotionPlus.RollSpeed) / 95f; // Divide by 95Hz (average updates per second from wiimote)
                //wmpOffset += offset;

                //model.rot.Rotate(offset, Space.Self);
            }
        } while (ret > 0);

		powerInput = Input.GetAxis( "Vertical" );
		turnInput = Input.GetAxis( "Horizontal" );
		if( Input.GetButton( "Jump" ) ) {
			CalibraterWiimote( );
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate( new Vector3( 0f, 0f, powerInput * speed * Time.deltaTime ) );
		transform.Translate( new Vector3( turnSpeed * turnInput * Time.deltaTime, 0f, 0f ) );
	}

	/*void OnGUI()
    {
        GUI.Box(new Rect(0,0,320,Screen.height), "");

        GUILayout.BeginVertical(GUILayout.Width(300));
        GUILayout.Label("Wiimote Found: " + WiimoteManager.HasWiimote());
        if (GUILayout.Button("Find Wiimote"))
            WiimoteManager.FindWiimotes();

        if (GUILayout.Button("Cleanup"))
        {
            WiimoteManager.Cleanup(wiimote);
            wiimote = null;
        }

        if (wiimote == null)
			return;

        GUILayout.Label("Extension: " + wiimote.current_ext.ToString());

        GUILayout.Label("LED Test:");
        GUILayout.BeginHorizontal();
        for (int x = 0; x < 4;x++ )
            if (GUILayout.Button(""+x, GUILayout.Width(300/4)))
                wiimote.SendPlayerLED(x == 0, x == 1, x == 2, x == 3);
        GUILayout.EndHorizontal();

        GUILayout.Label("Set Report:");
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("But/Acc", GUILayout.Width(300/4)))
            wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL);
        if(GUILayout.Button("But/Ext8", GUILayout.Width(300/4)))
            wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_EXT8);
        if(GUILayout.Button("B/A/Ext16", GUILayout.Width(300/4)))
            wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL_EXT16);
        if(GUILayout.Button("Ext21", GUILayout.Width(300/4)))
            wiimote.SendDataReportMode(InputDataType.REPORT_EXT21);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Request Status Report"))
            wiimote.SendStatusInfoRequest();

        GUILayout.Label("IR Setup Sequence:");
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Basic", GUILayout.Width(100)))
            wiimote.SetupIRCamera(IRDataType.BASIC);
        if(GUILayout.Button("Extended", GUILayout.Width(100)))
            wiimote.SetupIRCamera(IRDataType.EXTENDED);
        if(GUILayout.Button("Full", GUILayout.Width(100)))
            wiimote.SetupIRCamera(IRDataType.FULL);
        GUILayout.EndHorizontal();

        GUILayout.Label("WMP Attached: " + wiimote.wmp_attached);
        if (GUILayout.Button("Request Identify WMP"))
            wiimote.RequestIdentifyWiiMotionPlus();
        if ((wiimote.wmp_attached || wiimote.Type == WiimoteType.PROCONTROLLER) && GUILayout.Button("Activate WMP"))
            wiimote.ActivateWiiMotionPlus();
        if ((wiimote.current_ext == ExtensionController.MOTIONPLUS ||
            wiimote.current_ext == ExtensionController.MOTIONPLUS_CLASSIC ||
            wiimote.current_ext == ExtensionController.MOTIONPLUS_NUNCHUCK) && GUILayout.Button("Deactivate WMP"))
            wiimote.DeactivateWiiMotionPlus();

        GUILayout.Label("Calibrate Accelerometer");
        GUILayout.BeginHorizontal();
        for (int x = 0; x < 3; x++)
        {
            AccelCalibrationStep step = (AccelCalibrationStep)x;
            if (GUILayout.Button(step.ToString(), GUILayout.Width(125)))
                wiimote.Accel.CalibrateAccel(step);
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Print Calibration Data"))
        {
            StringBuilder str = new StringBuilder();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    str.Append(wiimote.Accel.accel_calib[y, x]).Append(" ");
                }
                str.Append("\n");
            }
            Debug.Log(str.ToString());
        }
	}*/

	void CalibraterWiimote( ) {
		wiimote.SendDataReportMode( InputDataType.REPORT_BUTTONS_ACCEL );
		//wiimote.Accel.CalibrateAccel( AccelCalibrationStep.A_BUTTON_UP );
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
