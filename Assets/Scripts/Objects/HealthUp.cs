using UnityEngine;

public class HealthUp : MonoBehaviour {

	Player player;
	public int healthUpValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.IncreaseMaxHealth(healthUpValue);
	}
};