using UnityEngine;
using System.Collections.Generic;

public class Object : MonoBehaviour {
	
	// set object type
	public ItemTypes.ItemType type;

	// object value to be added or subtracted
	public int value;

	// player reference
	private Player player;

	private Achievements achievements;

	private bool magnetToPlayer;
	private GameObject playerObject;
	private Rigidbody2D rb;

	void Awake() {
		player = FindObjectOfType<Player>();
		achievements = FindObjectOfType<Achievements>();
	}

	void Start() {
		rb = GetComponent<Rigidbody2D>();

		if(playerObject == null) {
			playerObject = GameObject.FindWithTag("Player");
		}
	}

	void Update() {

		// move object towards player if magnetToPlayer is true
		if(magnetToPlayer) {
			Vector3 playerPoint = Vector3.MoveTowards(transform.position, playerObject.transform.position, 20 * Time.deltaTime);
			rb.MovePosition(playerPoint);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		// if ItemMagnet collides with object, set magnetToPlayer to true
		if(col.CompareTag("ItemMagnet")) {
			playerObject = GameObject.Find("Player");

			// exclude poison anmd chests from magnet
			switch(type) {
				case ItemTypes.ItemType.POISON:
					break;
				default:
					magnetToPlayer = true;
					break;
			}
		}

		if(col.CompareTag("Player")) {
			// call corresponding method depending on object type
			switch(type) {

				case ItemTypes.ItemType.COIN: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.COIN);
					player.AddCoin(ItemTypes.ItemType.COIN, value);
					break;
				}

				case ItemTypes.ItemType.STRENGTHUP: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.STRENGTHUP);
					player.IncreaseStrength(value);
					break;
				}

				case ItemTypes.ItemType.AGILITYUP: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.AGILITYUP);
					player.IncreaseAgility(value);
					break;
				}

				case ItemTypes.ItemType.STAMINAUP: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.STAMINAUP);
					player.IncreaseStamina(value);
					break;
				}

				case ItemTypes.ItemType.STATSUP: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.STATSUP);
					player.IncreaseStrength(value);
					player.IncreaseAgility(value);
					player.IncreaseStamina(value);
					break;
				}

				case ItemTypes.ItemType.KEY: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.KEY);
					player.AddKey(ItemTypes.ItemType.KEY, value);
					break;
				}

				case ItemTypes.ItemType.POISON: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.POISON);
					if(player.currentHealth > 0)
						player.PickUpPoison(value);
					break;
				}

				case ItemTypes.ItemType.POTION: {
					SoundAssets.Instance.playPickupSound(ItemTypes.ItemType.POTION);
					player.AddPotion(type, value);
					break;
				}

				case ItemTypes.ItemType.HEALTHUP: {
					player.PickUpHealthUp(value);
					break;
				}
				
				case ItemTypes.ItemType.SCYTHE:
				case ItemTypes.ItemType.SWORD:
				case ItemTypes.ItemType.FLAIL:
				case ItemTypes.ItemType.ROCK:
				case ItemTypes.ItemType.ARROW:
				case ItemTypes.ItemType.FIREBALL:{
					player.AddWeapon(type);
					break;
				}
					
			}
			achievements.checkAchievements();
			Destroy(gameObject);
		}
	}
}
