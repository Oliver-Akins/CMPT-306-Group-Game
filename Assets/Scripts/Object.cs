using UnityEngine;

public class Object : MonoBehaviour {

	// // enum for object types
	// public enum ObjectType{COIN, STRENGTHUP, AGILITYUP, STAMINAUP, STATSUP,
	// 	KEY, POISON, POTION, HEALTHUP}
	
	
	// set object type
	public ItemTypes.ItemType type;

	// object value to be added or subtracted
	public int value;

	// player reference
	private Player player;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("Player")) {
			
			// call corresponding method depending on object type
			switch(type) {

				case ItemTypes.ItemType.COIN: {
					player.AddCoin(ItemTypes.ItemType.COIN, value);
					break;
				}

				case ItemTypes.ItemType.STRENGTHUP: {
					player.IncreaseStrength(value);
					break;
				}

				case ItemTypes.ItemType.AGILITYUP: {
					player.IncreaseAgility(value);
					break;
				}

				case ItemTypes.ItemType.STAMINAUP: {
					player.IncreaseStamina(value);
					break;
				}

				case ItemTypes.ItemType.STATSUP: {
					player.IncreaseStrength(value);
					player.IncreaseAgility(value);
					player.IncreaseStamina(value);
					break;
				}

				case ItemTypes.ItemType.KEY: {
					player.AddKey(ItemTypes.ItemType.KEY, value);
					break;
				}

				case ItemTypes.ItemType.POISON: {
					if(player.currentHealth > 0)
						player.TakeDamage(value);
					break;
				}

				case ItemTypes.ItemType.POTION: {
					player.HealOrAddPotion(type, value);
					break;
				}

				case ItemTypes.ItemType.HEALTHUP: {
					player.IncreaseMaxHealth(value);
					break;
				}
			}
			
			Destroy(gameObject);
		}
	}
}
