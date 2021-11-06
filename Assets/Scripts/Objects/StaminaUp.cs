using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaUp : MonoBehaviour {

	Player player;
	public int staminaUpValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.IncreaseStamina(staminaUpValue);
	}
};