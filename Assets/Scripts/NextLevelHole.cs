using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHole : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			// change string value to name of scene to be loaded when triggered
			GameStateManager.Instance.SetGameState(GameState.BETWEEN_LEVEL);
		};
	}
}