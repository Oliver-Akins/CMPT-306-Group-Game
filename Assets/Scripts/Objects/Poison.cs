using UnityEngine;

public class Poison : MonoBehaviour {

	Player player;
	public int damageValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);

		if(player.currentHealth > 0)
			player.TakeDamage(damageValue);
	}
};