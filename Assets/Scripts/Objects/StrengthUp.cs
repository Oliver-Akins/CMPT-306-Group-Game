using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUp : MonoBehaviour {

	Player player;
	public int strengthUpValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.IncreaseStrength(strengthUpValue);
	}
};