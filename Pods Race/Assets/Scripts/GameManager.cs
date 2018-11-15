using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float restartDelay = 2.0f;
    bool gameHasEnded = false;

	public void EndGame( ) {
        if( !gameHasEnded ) {
            gameHasEnded = true;
            FindObjectOfType< PlayerMovement >( ).DisableMovement( );
            Invoke( "Restart", restartDelay );
        }
    }

    public void Restart( ) {
        SceneManager.LoadScene( SceneManager.GetActiveScene( ).name );
    }
}
