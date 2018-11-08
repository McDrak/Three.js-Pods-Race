using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {
	public void LoadLevelClick( ) {
        SceneManager.LoadScene( 1 );
    }
}
