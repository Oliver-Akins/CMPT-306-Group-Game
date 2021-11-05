using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		Debug.Log("1");
		GM = GameStateManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}

	public void HandleOnStateChange() {
		Debug.Log("2");
		GM.SetGameState(GameState.IN_GAME);
		Invoke("LoadGame", 3f);
	}

	public void LoadGame() {
		Debug.Log("3");
		SceneManager.LoadScene("devScene");
	}
}