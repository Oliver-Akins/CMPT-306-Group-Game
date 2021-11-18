using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class inGame : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM = GameStateManager.Instance;
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (GM.gameState == GameState.IN_GAME) {
			Player p = GameObject.Find("Player").GetComponent<Player>();
			GM.player = p;
			if (GM.playerStats != null) {
				p.SetStats(GM.playerStats);
			};
		};
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start() {}
};