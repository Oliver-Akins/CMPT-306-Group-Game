using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainMenu : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM.SetGameState(GameState.MAIN_MENU);
	}
}