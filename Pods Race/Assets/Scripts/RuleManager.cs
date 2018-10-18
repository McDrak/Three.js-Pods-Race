﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour {
    // List of Possible Prefabs
    public GameObject[] prefabs = new GameObject[ 6 ];
    // Procedural Rule Container
    private Dictionary< string, List< int > > ruleSet;

    // Initial Map Identifiers
    private List< List< int > > initialMap;

	// Use this for initialization
	void Start () {
		ruleSet = new Dictionary< string, List< int > >( );
        ruleSet.Add( "1111", new List< int > { 1 } );
        ruleSet.Add( "1110", new List< int >( ) { 1, 4 } );
        ruleSet.Add( "1100", new List< int >( ) { 0, 1, 2 } );
        ruleSet.Add( "0000", new List< int >( ) { 0 } );
        ruleSet.Add( "0001", new List< int >( ) { 0, 3 } );
        ruleSet.Add( "3011", new List< int >( ) { 1 } );
        ruleSet.Add( "1003", new List< int >( ) { 0 } );
        ruleSet.Add( "0031", new List< int >( ) { 0, 1, 5 } );
        ruleSet.Add( "5311", new List< int >( ) { 1 } );
        ruleSet.Add( "1105", new List< int >( ) { 0 } );
        ruleSet.Add( "0051", new List< int >( ) { 0 } );
        ruleSet.Add( "0511", new List< int >( ) { 1, 5 } );
        ruleSet.Add( "4100", new List< int >( ) { 0 } );
        ruleSet.Add( "0005", new List< int >( ) { 0 } );
        ruleSet.Add( "3511", new List< int >( ) { 1 } );
        ruleSet.Add( "1114", new List< int >( ) { 1, 4 } );
        ruleSet.Add( "4140", new List< int >( ) { 0 } );
        ruleSet.Add( "0400", new List< int >( ) { 0, 3 } );
        ruleSet.Add( "3003", new List< int >( ) { 1 } );
        ruleSet.Add( "1031", new List< int >( ) { 1 } );
        ruleSet.Add( "1311", new List< int >( ) { 1 } );
        ruleSet.Add( "0403", new List< int >( ) { 0, 3 } );
        ruleSet.Add( "0311", new List< int >( ) { 1, 5 } );
        ruleSet.Add( "1140", new List< int >( ) { 0, 2 } );
        ruleSet.Add( "2400", new List< int >( ) { 0 } );
        ruleSet.Add( "0003", new List< int >( ) { 0, 3 } );
        ruleSet.Add( "1120", new List< int >( ) { 1, 4 } );
        ruleSet.Add( "1200", new List< int >( ) { 0, 1, 2 } );
        ruleSet.Add( "2000", new List< int >( ) { 0 } );
        ruleSet.Add( "1112", new List< int >( ) { 1 } );
        ruleSet.Add( "0011", new List< int >( ) { 0, 1, 5 } );
        ruleSet.Add( "0111", new List< int >( ) { 1, 5 } );
        ruleSet.Add( "4200", new List< int >( ) { 0 } );
        ruleSet.Add( "1000", new List< int >( ) { 0 } );
        ruleSet.Add( "1001", new List< int >( ) { 0 } );
        ruleSet.Add( "1101", new List< int >( ) { 0 } );
        ruleSet.Add( "3000", new List< int >( ) { 1 } );
        ruleSet.Add( "2403", new List< int >( ) { 0 } );
        ruleSet.Add( "2003", new List< int >( ) { 0 } );
        ruleSet.Add( "1103", new List< int >( ) { 0 } );
        ruleSet.Add( "3031", new List< int >( ) { 1 } );
        ruleSet.Add( "5031", new List< int >( ) { 1 } );
        ruleSet.Add( "1203", new List< int >( ) { 0 } );
        ruleSet.Add( "4205", new List< int >( ) { 0 } );
        ruleSet.Add( "4103", new List< int >( ) { 0 } );
        ruleSet.Add( "5111", new List< int >( ) { 1 } );
        ruleSet.Add( "3005", new List< int >( ) { 1 } ); // Keep in mind
        ruleSet.Add( "0030", new List< int >( ) { 1, 5 } );
        ruleSet.Add( "4203", new List< int >( ) { 0 } );
        ruleSet.Add( "1115", new List< int >( ) { 1 } );
        ruleSet.Add( "1300", new List< int >( ) { 0 } );
        ruleSet.Add( "4101", new List< int >( ) { 0 } );
        ruleSet.Add( "5030", new List< int >( ) { 0 } );
        ruleSet.Add( "1005", new List< int >( ) { 0, 2 } );
        ruleSet.Add( "5310", new List< int >( ) { 4 } );
        ruleSet.Add( "1310", new List< int >( ) { 4 } );
        ruleSet.Add( "0310", new List< int >( ) { 0, 4 } );
        ruleSet.Add( "0100", new List< int >( ) { 0 } );
        ruleSet.Add( "0401", new List< int >( ) { 0 } );
        ruleSet.Add( "0014", new List< int >( ) { 0 } );
        ruleSet.Add( "2405", new List< int >( ) { 0 } );
        ruleSet.Add( "2001", new List< int >( ) { 0 } );
        ruleSet.Add( "3001", new List< int >( ) { 0, 1 } );
        ruleSet.Add( "2401", new List< int >( ) { 0 } );
        ruleSet.Add( "0140", new List< int >( ) { 0 } );
        ruleSet.Add( "2005", new List< int >( ) { 0 } );
        ruleSet.Add( "1201", new List< int >( ) { 0 } );
        ruleSet.Add( "1314", new List< int >( ) { 0, 4 } );
        ruleSet.Add( "0010", new List< int >( ) { 0 } );
        ruleSet.Add( "3030", new List< int >( ) { 0, 1, 4 } );
        ruleSet.Add( "0405", new List< int >( ) { 0 } );
        ruleSet.Add( "1205", new List< int >( ) { 0, 2 } );
        ruleSet.Add( "4105", new List< int >( ) { 0 } );
        ruleSet.Add( "1301", new List< int >( ) { 0 } );
        ruleSet.Add( "1305", new List< int >( ) { 0, 2 } );
        ruleSet.Add( "3010", new List< int >( ) { 1, 4 } );

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
        generateMap( );
        printMap( );
	}

    void generateMap( ) {
        // From botton to top in the innitial map list
        for( int i = initialMap.Count - 2; i >= 0; i-- ) { 
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
            }
        }
    }

    void printMap( ) {
        // Initial Z Position
        float initialVerticalPosition = 25.0f;
        // X Modifier
        float horizonalModifier = 10.0f;
        // Y Modifier
        float verticalModifier = 10.0f;
        // From bottom to top
        for( int i = initialMap.Count - 1; i >= 0; i-- ) {
            // Initial X Position
            float initialHorizontalPosition = -40.0f;
            // From left to right
            for( int j = 0; j < initialMap[ i ].Count; j++ ) {
                // Instantiates a new gameobject from the index in the map
                Instantiate( prefabs[ initialMap[ i ][ j ] ], new Vector3( initialHorizontalPosition, this.transform.position.y, initialVerticalPosition ), prefabs[ initialMap[ i ][ j ] ].transform.rotation );
                // Increments X Position
                initialHorizontalPosition += horizonalModifier;
            }
            // Increments Z Position
            initialVerticalPosition += verticalModifier;
        }
    }
}
