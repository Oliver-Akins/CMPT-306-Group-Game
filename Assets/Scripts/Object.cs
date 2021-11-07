using UnityEngine;

public class Object : MonoBehaviour {

	public enum ObjectType{COIN, STRENGTHUP, AGILITYUP, STAMINAUP, STATSUP,
		KEY, POISON, POTION, HEALTHUP}
	public ObjectType type;
	public int value;
	private Player player;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("Player")) {
			
			switch(type) {

				case ObjectType.COIN: {
					player.AddCoin(value);
					break;
				}

				case ObjectType.STRENGTHUP: {
					player.IncreaseStrength(value);
					break;
				}

				case ObjectType.AGILITYUP: {
					player.IncreaseAgility(value);
					break;
				}

				case ObjectType.STAMINAUP: {
					player.IncreaseStamina(value);
					break;
				}

				case ObjectType.STATSUP: {
					player.IncreaseStrength(value);
					player.IncreaseAgility(value);
					player.IncreaseStamina(value);
					break;
				}

				case ObjectType.KEY: {
					player.AddKey(value);
					break;
				}

				case ObjectType.POISON: {
					if(player.currentHealth > 0)
						player.TakeDamage(value);
					break;
				}

				case ObjectType.POTION: {
					if(player.currentHealth < player.maxHealth)
						player.HealPlayer(value);
					break;
				}

				case ObjectType.HEALTHUP: {
					player.IncreaseMaxHealth(value);
					break;
				}
			}
			
			Destroy(gameObject);
		}
	}
};