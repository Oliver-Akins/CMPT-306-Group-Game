using UnityEngine;
using System.Collections;

public class inGame : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM = GameStateManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}

	void Start() {
		GM.SetGameState(GameState.IN_GAME);
	}

	public void HandleOnStateChange() {
		if (GM.gameState == GameState.IN_GAME) {
			Player p = GameObject.Find("Player").GetComponent<Player>();
			GM.player = p;
		}
	}
};