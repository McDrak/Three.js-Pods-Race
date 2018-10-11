using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour {
    public Dictionary< List< int >, List< int > > ruleSet;

	// Use this for initialization
	void Start () {
		ruleSet = new Dictionary< List< int >, List< int > >( ) {
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int > { 1 } },
            { new List< int >( ) { 1, 1, 1, 0 }, new List< int >( ) { 1, 4 } },
            { new List< int >( ) { 1, 1, 0, 0 }, new List< int >( ) { 0, 1, 2 } },
            { new List< int >( ) { 0, 0, 0, 0 }, new List< int >( ) { 0 } },
            { new List< int >( ) { 0, 0, 0, 1 }, new List< int >( ) { 0, 3 } },
            { new List< int >( ) { 3, 0, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 0, 0, 3 }, new List< int >( ) { 0, 2 } },
            { new List< int >( ) { 0, 0, 3, 1 }, new List< int >( ) { 0, 1, 5 } },
            { new List< int >( ) { 5, 3, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 0, 5 }, new List< int >( ) { 0 } }, // --------------------------
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } },
            { new List< int >( ) { 1, 1, 1, 1 }, new List< int >( ) { 1 } }
        };
	}
}
