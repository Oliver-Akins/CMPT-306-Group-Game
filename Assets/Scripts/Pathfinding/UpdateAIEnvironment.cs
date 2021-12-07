using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Polarith.AI.Move;

public class UpdateAIEnvironment : MonoBehaviour {

	public AIMEnvironment env;
	private bool updated = false;

	// Update is called once per frame
	void Update() {
		if (!this.updated) {
			this.env.UpdateLayerGameObjects();
			this.updated = true;
		};
	}
};