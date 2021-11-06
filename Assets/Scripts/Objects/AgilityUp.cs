using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgilityUp : MonoBehaviour {

	Player player;
	public int agilityUpValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.IncreaseAgility(agilityUpValue);
	}

}