using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour {
    public GameObject mapContainer;
    // Player Gameobject
    public GameObject player;
    // loadiong Screen Game Object
    public GameObject loadingScreen;
    // Loading Screen Slider
    public Slider slider;

    public GameObject generationFlag;
    // List of Possible Prefabs
    public GameObject[] prefabs = new GameObject[ 6 ];
    // Procedural Rule Container
    private Dictionary< string, List< int > > ruleSet;

    // Initial Map Identifiers
    private List< List< int > > initialMap;

    // Map items that have been generated
    private float currentGenerated;

    private float initialVerticalPosition;
    private float initialHorizontalPosition;

	// Use this for initialization
	void Awake () {
        currentGenerated = 0;
		ruleSet = new Dictionary< string, List< int > >( ) {
            { "1111", new List< int > { 1 } },
            { "1110", new List< int >( ) { 1, 4 } },
            { "1100", new List< int >( ) { 0, 1, 2 } },
            { "0000", new List< int >( ) { 0 } },
            { "0001", new List< int >( ) { 0, 3 } },
            { "3011", new List< int >( ) { 1 } },
            { "1003", new List< int >( ) { 0 } },
            { "0031", new List< int >( ) { 0, 1, 5 } },
            { "5311", new List< int >( ) { 1 } },
            { "1105", new List< int >( ) { 0 } },
            { "0051", new List< int >( ) { 0 } },
            { "0511", new List< int >( ) { 1, 5 } },
            { "4100", new List< int >( ) { 0 } },
            { "0005", new List< int >( ) { 0 } },
            { "3511", new List< int >( ) { 1 } },
            { "1114", new List< int >( ) { 1, 4 } },
            { "4140", new List< int >( ) { 0 } },
            { "0400", new List< int >( ) { 0, 3 } },
            { "3003", new List< int >( ) { 1 } },
            { "1031", new List< int >( ) { 1 } },
            { "1311", new List< int >( ) { 1 } },
            { "0403", new List< int >( ) { 0, 3 } },
            { "0311", new List< int >( ) { 1, 5 } },
            { "1140", new List< int >( ) { 0, 2 } },
            { "2400", new List< int >( ) { 0 } },
            { "0003", new List< int >( ) { 0, 3 } },
            { "1120", new List< int >( ) { 1, 4 } },
            { "1200", new List< int >( ) { 0, 1, 2 } },
            { "2000", new List< int >( ) { 0 } },
            { "1112", new List< int >( ) { 1 } },
            { "0011", new List< int >( ) { 0, 1, 5 } },
            { "0111", new List< int >( ) { 1, 5 } },
            { "4200", new List< int >( ) { 0 } },
            { "1000", new List< int >( ) { 0 } },
            { "1001", new List< int >( ) { 0 } },
            { "1101", new List< int >( ) { 0 } },
            { "3000", new List< int >( ) { 1 } },
            { "2403", new List< int >( ) { 0 } },
            { "2003", new List< int >( ) { 0 } },
            { "1103", new List< int >( ) { 0 } },
            { "3031", new List< int >( ) { 1 } },
            { "5031", new List< int >( ) { 1 } },
            { "1203", new List< int >( ) { 0 } },
            { "4205", new List< int >( ) { 0 } },
            { "4103", new List< int >( ) { 0 } },
            { "5111", new List< int >( ) { 1 } },
            { "3005", new List< int >( ) { 1 } }, // Keep in mind
            { "0030", new List< int >( ) { 1, 5 } },
            { "4203", new List< int >( ) { 0 } },
            { "1115", new List< int >( ) { 1 } },
            { "1300", new List< int >( ) { 0 } },
            { "4101", new List< int >( ) { 0 } },
            { "5030", new List< int >( ) { 0 } },
            { "1005", new List< int >( ) { 0, 2 } },
            { "5310", new List< int >( ) { 4 } },
            { "1310", new List< int >( ) { 4 } },
            { "0310", new List< int >( ) { 0, 4 } },
            { "0100", new List< int >( ) { 0 } },
            { "0401", new List< int >( ) { 0 } },
            { "0014", new List< int >( ) { 0 } },
            { "2405", new List< int >( ) { 0 } },
            { "2001", new List< int >( ) { 0 } },
            { "3001", new List< int >( ) { 0, 1 } },
            { "2401", new List< int >( ) { 0 } },
            { "0140", new List< int >( ) { 0 } },
            { "2005", new List< int >( ) { 0 } },
            { "1201", new List< int >( ) { 0 } },
            { "1314", new List< int >( ) { 0, 4 } },
            { "0010", new List< int >( ) { 0 } },
            { "3030", new List< int >( ) { 0, 1, 4 } },
            { "0405", new List< int >( ) { 0 } },
            { "1205", new List< int >( ) { 0, 2 } },
            { "4105", new List< int >( ) { 0 } },
            { "1301", new List< int >( ) { 0 } },
            { "1305", new List< int >( ) { 0, 2 } },
            { "3010", new List< int >( ) { 1, 4 } }
        };

        initialMap = new List< List < int > >( ) {
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 },
            new List< int >( ) { 1, 1, 1, 0, 0, 0, 1, 1, 1 },
        };
        
        // Uses the rules to generate a map
        StartCoroutine( generateMap( ) );
	}

    // Update is called once per frame
    void Update () {
        if( !player.activeSelf ) {
            UpdateSlider( );
        }
    }

    IEnumerator generateMap( ) {
        // Initial Z Position
        initialVerticalPosition = 25.0f;
        // X Modifier
        float horizonalModifier = 10.0f;
        // Y Modifier
        float verticalModifier = 10.0f;

        // From botton to top in the innitial map list
        for( int i = initialMap.Count - 1; i >= 0; i-- ) {
            // Initial X Position
            initialHorizontalPosition = -40.0f;

            // From left to right
            for( int j = 0; j < initialMap[ i ].Count; j++ ) {
                // If the value has not been assigned yet
                if( initialMap[ i ][ j ] == -1 ) {
                    // Creates a string to store the values around the local index
                    string rule = initialMap[ i ][ j - 1 ] + "" +
                        initialMap[ i + 1][ j - 1 ] + "" +
                        initialMap[ i + 1 ][ j ] + "" +
                        initialMap[ i + 1 ][ j + 1];

                    // Get the list of possible outcomes out of the rules set
                    List< int > outcomes;
                    if (!ruleSet.TryGetValue(rule, out outcomes)) {
                        Debug.Log("Key Error: " + rule);
                        initialMap[ i ][ j ] = 0;
                    }
                    else {
                        // Get a random number in the range of the indices of the outcome
                        int randIndex = Random.Range(0, outcomes.Count);

                        // Sets the new slot with the value in the random index
                        initialMap[ i ][ j ] = outcomes[ randIndex ];
                    }
                }

                // Instantiates a new gameobject from the index in the map
                GameObject tile = Instantiate( prefabs[ initialMap[ i ][ j ] ], new Vector3( initialHorizontalPosition, 10.0f, initialVerticalPosition ), prefabs[ initialMap[ i ][ j ] ].transform.rotation );
                tile.transform.SetParent( mapContainer.transform );
                // Increments X Position
                initialHorizontalPosition += horizonalModifier;

                // Update the Current Generated
                currentGenerated++;

                // Signals a new frame
                yield return null;
            }
            // Increments Z Position
            initialVerticalPosition += verticalModifier;
        }
    }

    void UpdateSlider( ) {
        slider.value = currentGenerated / (float) ( initialMap.Count * initialMap[ 0 ].Count );

        if( slider.value == 1 ) {
            loadingScreen.SetActive( false );
            player.SetActive( true );
        }
    }

    IEnumerator generateExtendedMap( ) {
        List< List< int > > extendedMap = new List< List< int > >( );
        extendedMap.Add( initialMap[ initialMap.Count - 1 ] );

        // X Modifier
        float horizonalModifier = 10.0f;
        // Y Modifier
        float verticalModifier = 10.0f;

        for( int i = 1; i < 20; i++ ) {
            initialHorizontalPosition = -40.0f;
            extendedMap.Add( new List< int >( ) { 1, -1, -1, -1, -1, -1, -1, -1, 1 } );

            for( int j = 0; j < extendedMap[ i ].Count; j++ ) {
                // If the value has not been assigned yet
                if( extendedMap[ i ][ j ] == -1 ) {
                    // Creates a string to store the values around the local index
                    string rule = extendedMap[ i ][ j - 1 ] + "" +
                        extendedMap[ i - 1][ j - 1 ] + "" +
                        extendedMap[ i - 1 ][ j ] + "" +
                        extendedMap[ i - 1 ][ j + 1];

                    // Get the list of possible outcomes out of the rules set
                    List< int > outcomes;
                    if (!ruleSet.TryGetValue(rule, out outcomes)) {
                        Debug.Log("Key Error: " + rule);
                        extendedMap[ i ][ j ] = 0;
                    }
                    else {
                        // Get a random number in the range of the indices of the outcome
                        int randIndex = Random.Range(0, outcomes.Count);

                        // Sets the new slot with the value in the random index
                        extendedMap[ i ][ j ] = outcomes[ randIndex ];
                    }
                }

                // Instantiates a new gameobject from the index in the map
                GameObject tile = Instantiate( prefabs[ extendedMap[ i ][ j ] ], new Vector3( initialHorizontalPosition, 10.0f, initialVerticalPosition ), prefabs[ extendedMap[ i ][ j ] ].transform.rotation );
                tile.transform.SetParent( mapContainer.transform );
                // Increments X Position
                initialHorizontalPosition += horizonalModifier;

                // Update the Current Generated
                currentGenerated++;

                // Signals a new frame
            }

            // Increments Z Position
            initialVerticalPosition += verticalModifier;

            yield return null;
        }
    }

    void OnTriggerEnter(Collider other) {
        generationFlag.transform.position = new Vector3( generationFlag.transform.position.x, generationFlag.transform.position.y, generationFlag.transform.position.z + 115.0f );
        StartCoroutine( generateExtendedMap( ) );
    }
}
