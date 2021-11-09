using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Ingame : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM = GameStateManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}

	public void HandleOnStateChange() {
		Debug.Log("State change event");
	}
}