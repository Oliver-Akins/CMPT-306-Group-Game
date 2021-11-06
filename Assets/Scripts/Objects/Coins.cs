using UnityEngine;

public class Coins : MonoBehaviour {

	Player player;
	public int coinValue;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		player.AddCoin(coinValue);
	}
};