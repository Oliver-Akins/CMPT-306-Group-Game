using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainMenu : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		this.GM = GameStateManager.Instance;
		this.GM.SetGameState(GameState.MAIN_MENU, false);
	}

	public void StartGame() {
		this.GM.SetGameState(GameState.IN_GAME);
	}
}