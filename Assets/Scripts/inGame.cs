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

				// ! important:
				// this must come before the stats are set because the coins
				// are saved as part of the stats, separately from the inventory
				// and this method overwrites the default-instantiated instance
				// of the inventory with a new one.
				p.SetInventoryItems(GM.inventory);

				p.SetStats(GM.playerStats);
			};
		};
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start() {}
};