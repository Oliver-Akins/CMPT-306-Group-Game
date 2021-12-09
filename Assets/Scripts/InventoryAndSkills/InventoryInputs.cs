using UnityEngine;

public class InventoryInputs : MonoBehaviour {

	// inventory game object to be toggled
	[SerializeField] 
	GameObject inventoryGameObject;
	[SerializeField]
	GameObject SkillGameObject;
	// the keys we are interested in using to handle inventory or char screen
	[SerializeField] 
	KeyCode[] toggleInventoryKeys;
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(toggleInventoryKeys[0])){
			inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
			Tooltip.HideTooltip_Static();
		}
		if (Input.GetKeyDown(toggleInventoryKeys[1])){
			SkillGameObject.SetActive(!SkillGameObject.activeSelf);
			Tooltip.HideTooltip_Static();
		}
	}
};