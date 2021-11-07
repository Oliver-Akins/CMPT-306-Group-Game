using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devScene : MonoBehaviour {
	GameStateManager GM;

	void Awake() {
		GM = GameStateManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}

	public void HandleOnStateChange() {
		Debug.Log("State change event");
	}
};