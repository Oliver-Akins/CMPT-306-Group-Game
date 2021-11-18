using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class inGame : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM = GameStateManager.Instance;
	}

	void Start() {
		if (GM.gameState == GameState.IN_GAME) {
			GameObject p = GameObject.Find("Player");
			GM.player = p.GetComponent<Player>();
		}
	}
};