using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;
	void Start ( ) {
		StartCoroutine( LoadAsync( 0 ) );
	}

	IEnumerator LoadAsync( int sceneIndex ) {
		float progress = 0;
		loadingScreen.SetActive( true );
		AsyncOperation operation = SceneManager.LoadSceneAsync( sceneIndex );

		while( progress < 1 ) {
			if( progress <= 0.5f ) {
				progress = Mathf.Clamp01( operation.progress / 0.5f );
			}
			else {
				progress = 0.5f + Mathf.Clamp01( operation.progress / 0.5f );
			}

			slider.value = progress;
			progressText.text = ( progress * 100f ) + "%";

			yield return null;
		}
	}
}
