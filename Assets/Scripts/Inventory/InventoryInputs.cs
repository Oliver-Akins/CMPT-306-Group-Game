using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInputs : MonoBehaviour {

	// inventory game object to be toggled
	[SerializeField] GameObject inventoryGameObject;
	// the keys we are interested in using to handle inventory or char screen
	[SerializeField] KeyCode[] toggleInventoryKeys;
	// Update is called once per frame
	void Update() {
		int length = toggleInventoryKeys.Length;
		for (int i = 0; i < length; i++){
			if (Input.GetKeyDown(toggleInventoryKeys[i])){
				inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
				break;
			}
		}
	}
};