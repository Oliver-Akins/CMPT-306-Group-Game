using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStatsUp : MonoBehaviour {

	Player player;
	public int statsUpValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.IncreaseStrength(statsUpValue);
		player.IncreaseAgility(statsUpValue);
		player.IncreaseStamina(statsUpValue);
	}
};