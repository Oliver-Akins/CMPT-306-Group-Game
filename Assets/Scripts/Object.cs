using UnityEngine;

public class Object : MonoBehaviour {
	
	// set object type
	public ItemTypes.ItemType type;

	// object value to be added or subtracted
	public int value;

	// player reference
	private Player player;

	private Achievements achievements;

	void Awake() {
		player = FindObjectOfType<Player>();
		achievements = FindObjectOfType<Achievements>();
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
						player.PickUpPoison(value);
					break;
				}

				case ItemTypes.ItemType.POTION: {
					player.AddPotion(type, value);
					break;
				}

				case ItemTypes.ItemType.HEALTHUP: {
					player.PickUpHealthUp(value);
					break;
				}
			}
			
			Destroy(gameObject);

			achievements.checkAchievements();
		}
	}
}
