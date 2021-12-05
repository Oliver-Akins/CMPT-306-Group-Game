using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Player movement // can change as needed
	// move speed baseline
	public float moveSpeed = 5f;

	// used to manipluate the driver/rigid body
	public Rigidbody2D rb;

	public Rigidbody2D firePointRb;

	// for animations this can be used with the blend tree
	public Animator animator;

	// Camera reference to handle aiming weapon attacks
	public Camera cam;

	Vector2 movement;
	Vector2 mousePosition;

	// player max health
	// notes this is the base and gets modified by the stamina the player has
	// at start and whenever the stamina increases
	public int maxHealth;

	// player current health - initializes to max health at start
	public int currentHealth;

	// player health bar
	public HealthBar healthBar;

	// player strength
	public int strength;

	//player agility
	public int agility;

	//player stamina
	public int stamina;

	//inventory
	private Inventory inventory;
	[SerializeField]
	private UI_Inventory UIinventory;


	//player skill coins
	public int skillCoins;

	// current number of kills
	public int kills;

	// number of keys acquired
	public int keys;

	// screen damage effect overlay
	public GameObject damageEffectOverlay;
	private Coroutine damageEffectOverlayRoutine;
	private bool damageEffectRunning = false;

	// screen heal effect overlay
	public GameObject healEffectOverlay;
	private Coroutine healEffectOverlayRoutine;
	private bool healEffectRunning = false;

	private float attackRange;
	private float attackOffset;
	private int meleeDamage;

	private int rangeDamage;
	// item magnet collider reference
	public GameObject itemMagnet;

	public Dictionary<string, int> GetStats() {
		Dictionary<string, int> stats = new Dictionary<string, int>();
		stats.Add("strength", this.strength);
		stats.Add("agility", this.agility);
		stats.Add("stamina", this.stamina);

		// Find the amount of coins that the player has
		foreach (var item in this.inventory.GetItemList()) {
			if (item.type == ItemTypes.ItemType.COIN) {
				stats.Add("skillCoins", item.amount);
			};
		};

		return stats;
	}

	public void SetStats(Dictionary<string, int> stats) {
		this.strength = stats["strength"];
		this.agility = stats["agility"];
		this.stamina = stats["stamina"];

		// Re-add the skill coins to the player's inventory
		this.inventory.AddItem(
			ItemTypes.ItemType.COIN,
			stats["skillCoins"]
		);
		UIinventory.RefreshInventoryItems();
	}

	public List<InventoryItem> GetInventoryItems() {
		return this.inventory.GetItemList();
	}

	public Dictionary<string, InventoryItem> GetEquippedWeaps(){
		return this.inventory.GetEquipped();
	}

	public void SetInventoryItems(List<InventoryItem> items,
		Dictionary<string, InventoryItem> previouslyEquipped) {
		this.inventory = new Inventory(
			UseItem,
			items.Where(item => item.type != ItemTypes.ItemType.COIN).ToList(),
			previouslyEquipped
		);
		UIinventory.SetInventory(inventory);
	}

	private void Awake() {
		/**
			After the first level this gets overriden by the players
			previous items and equipped weaps
		*/
		inventory = new Inventory(UseItem);
		UIinventory.SetInventory(inventory);
	}

	// Start() is called when script is enabled
	void Start() {
		//Start the player with some equipped weapons and with them in the inventory
		// if it is empty and equip it
		if (inventory.IsEmpty()){
			// remove this section for final release:
			UseItem( new InventoryItem{type = ItemTypes.ItemType.SCYTHE, amount = 1});
			inventory.AddItem(ItemTypes.ItemType.SCYTHE, 1);
			UseItem( new InventoryItem {type = ItemTypes.ItemType.FLAIL, amount = 1});
			inventory.AddItem(ItemTypes.ItemType.FLAIL, 1);
			UseItem( new InventoryItem{type = ItemTypes.ItemType.ARROW});
			inventory.AddItem(ItemTypes.ItemType.ARROW, 1);
			UseItem( new InventoryItem{type = ItemTypes.ItemType.FIREBALL, amount = 1});
			inventory.AddItem(ItemTypes.ItemType.FIREBALL, 1);

			// this is the default items for the player to have weaps!
			// if we get the tutorial level working this can change.
			UseItem(new InventoryItem{ type = ItemTypes.ItemType.SWORD, amount = 1});
			inventory.AddItem(ItemTypes.ItemType.SWORD, 1);
			UseItem( new InventoryItem{ type = ItemTypes.ItemType.ROCK, amount = 1});
			inventory.AddItem(ItemTypes.ItemType.ROCK, 1);
			UIinventory.RefreshInventoryItems();
		} else {
			// always need to ensure the player is equipped
			Dictionary<string, InventoryItem> equippedItems = inventory.GetEquipped();
			UseItem(equippedItems["equippedRange"]);
			UseItem(equippedItems["equippedMelee"]);
		}
	
		// initialize max health to inspector value input
		// also adds the stamina mod to flatly increase the health on 1:1 basis
		currentHealth = maxHealth + stamina;
		healthBar.SetMaxHealth(maxHealth + stamina);
	}

	// Update is called once per frame
	// not good for physics D: but great for inputs
	void Update() {
		// gives a value between -1 and 1 depending on which key left or right,
		// but if no move in this direction will return 0
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		// Sets the animation when we need it
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		// more optimized with square root magnitude as we won't need to calculate it on the vector
		animator.SetFloat("Speed", movement.sqrMagnitude);

		if(Input.GetKeyDown(KeyCode.H)){
			if(currentHealth < maxHealth + stamina){
				InventoryItem foundItem = inventory.FindItem(ItemTypes.ItemType.POTION);
				if (foundItem != null && foundItem.amount > 0){
					UseItem(foundItem);
					SoundAssets.Instance.playUseSound(foundItem.type);
				}
			}
		}
		if(currentHealth <= 0){
			animator.SetBool("isDead", true);
			Invoke("GameOverScene", 0.75f);
		}
		// keyboard inputs for testing - delete if needed
		// un-comment these when testing; should not be in the main build

		// if(Input.GetKeyDown(KeyCode.Space)){
		// 	if(currentHealth > 0){
		// 		TakeDamage(100);
		// 	}
		// }
		
		// move ItemMagnet to follow center of Player
		itemMagnet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


		// if(Input.GetKeyDown(KeyCode.N)){
		// 	DecreaseMaxHealth(100);
		// }

		// if(Input.GetKeyDown(KeyCode.M)){
		// 	IncreaseMaxHealth(100);
		// }

		// if(Input.GetKeyDown(KeyCode.K)){
		// 	AddKill();
		// }
	}
	void GameOverScene(){
		SceneManager.LoadScene("gameOver");
	}

	// works the same way, but executed on a fixed timer and stuck to the frame rate
	// approx 50 times a second
	void FixedUpdate() {
		/**
			turn the agi stat into percentage but half the value first as this stat
			will also affect attack speed as well.
			This assume its will be fractional increases to the player movement
			hence the calculation to figure the speed increase from base; this is
			about a 5 percent increase of base speed at each level
		*/
		float agiModdedMoveSpeed = this.agility > 0 ? moveSpeed + (( (float)this.agility /2) / 10) : moveSpeed;
		rb.MovePosition(rb.position + movement.normalized * agiModdedMoveSpeed * Time.fixedDeltaTime);
		Vector2 aimDirection = mousePosition - rb.position;
		// calculate the angle so the firepoint can rotate to correctly shoot from the player
		float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		// because the original implementation was on the sprite and rotated the sprite
		// this is instead rotating the fire point at the center of the player
		// note this isn't perfect when we start adding colliders onto the player
		firePointRb.MovePosition(rb.position + movement.normalized * agiModdedMoveSpeed * Time.fixedDeltaTime);
		firePointRb.rotation = angle;
	}

	private void UseItem(InventoryItem item){
		if (item.isMeleeWeap()){
			inventory.EquipMeleeWeap(item);
		}
		else if (item.isRangeWeap()){
			inventory.EquipRangeWeap(item);
		}
		switch(item.type){
			case ItemTypes.ItemType.POTION:
				HealPlayer(50); // change this later lol
				inventory.RemoveItem(new InventoryItem{type = ItemTypes.ItemType.POTION, amount = 1});
				UIinventory.RefreshInventoryItems();
				break;
			case ItemTypes.ItemType.ROCK:
				this.rangeDamage = 15;
				break;
			case ItemTypes.ItemType.ARROW:
				this.rangeDamage = 10;
				break;
			case ItemTypes.ItemType.FIREBALL:
				this.rangeDamage = 5;
				break;
			case ItemTypes.ItemType.SWORD:
				this.attackOffset = 1.5f;
				this.attackRange = .6f;
				this.meleeDamage = 30;
				break;
			case ItemTypes.ItemType.FLAIL:
				this.attackOffset = 2.5f;
				this.attackRange = .4f;
				this.meleeDamage = 25;
				break;
			case ItemTypes.ItemType.SCYTHE:
				this.attackOffset = 1.1f;
				this.attackRange = .9f;
				this.meleeDamage = 35;
				break;
		}
	}

	// wanted strength to affect ranged weaps but less strongly
	// also yay for integer division?
	public int getRangeDamage(){
		int rangeDam = this.rangeDamage + strength/3;
		return rangeDam;
	}

	public float getAttackOffset(){
		return this.attackOffset;
	}

	public float getAttackRange(){
		return this.attackRange;
	}

	public int getMeleeAttackDamage(){
		return this.meleeDamage;
	}

	public void TakeDamage(int damageValue) {
		currentHealth -= damageValue;
		DamageEffectOverlay();

		// update health bar
		healthBar.SetCurrentHealth(currentHealth);

		ResetKillStreak();
	}

	public void HealPlayer(int healValue) {
		// checks if the player is only getting a portion of healing from the potion
		int newHealth = maxHealth + stamina < currentHealth + healValue ?
			currentHealth = maxHealth + stamina :
			currentHealth + healValue ;
		HealEffectOverlay();

		// update health bar
		healthBar.SetCurrentHealth(newHealth);
	}

	/**
		TODO logic of this needs to change so the stam mod is correctly
		calculating and influencing the max health.
		This likely not gonna be used in game but this is not great with
		stamina affecting the player health
	*/
	public void DecreaseMaxHealth(int healthDown) {
		maxHealth -= healthDown;

		// set current health to new max health if current
		// is greater than max
		if(currentHealth > maxHealth + stamina)
			currentHealth = maxHealth + stamina;

		// update health bar
		healthBar.DecreaseMaxHealth(currentHealth, maxHealth + stamina);
	}

	/**
		TODO the logic of this needs to change, I would recommend not using
		this at all until the logic changes or we feel we need this implemented
	*/
	public void IncreaseMaxHealth(int healthUp) {
		maxHealth += healthUp;
		currentHealth += healthUp;

		// update health bar
		healthBar.IncreaseMaxHealth(currentHealth, maxHealth + stamina);
	}

	// call damage effect routine if currently not running
	public void DamageEffectOverlay() {
		if(!damageEffectRunning)
			StartCoroutine(DamageEffectOverlayRoutine());
	}

	private IEnumerator DamageEffectOverlayRoutine() {

		damageEffectRunning = true;

		GameObject overlay = Instantiate(damageEffectOverlay,
			transform.position, transform.rotation) as GameObject;

		yield return new WaitForSeconds(1);

		Destroy(overlay);

		damageEffectRunning = false;
	}

	// call heal effect routine if currently not running
	public void HealEffectOverlay() {
		if(!healEffectRunning)
			StartCoroutine(HealEffectOverlayRoutine());
	}

	private IEnumerator HealEffectOverlayRoutine() {

		healEffectRunning = true;

		GameObject overlay = Instantiate(healEffectOverlay,
			transform.position, transform.rotation) as GameObject;

		yield return new WaitForSeconds(1);

		Destroy(overlay);

		healEffectRunning = false;
	}

	public void AddPotion( ItemTypes.ItemType type, int value){
		inventory.AddItem(type, value);
		UIinventory.RefreshInventoryItems();

		AchievementCollection.potionCollection += 1;
	}

	public void AddCoin( ItemTypes.ItemType type, int numCoins) {
		inventory.AddItem(type, numCoins);
		UIinventory.RefreshInventoryItems();

		AchievementCollection.coinCollection += numCoins;
	}

	public void UseCoins(int numCoins) {
		skillCoins -= numCoins;
	}

	public void AddKey( ItemTypes.ItemType type, int numKey) {
		inventory.AddItem(type, numKey);
		UIinventory.RefreshInventoryItems();

		AchievementCollection.keyCollection += numKey;
	}

	public void UseKey(int numKey) {
		keys -= numKey;
	}

	// this needs to be updated to do things based on the weapon!
	public void AddWeapon(ItemTypes.ItemType type){
		inventory.AddItem(type, 1);
		UIinventory.RefreshInventoryItems();
	}

    public void IncreaseStrength(int strengthUp) {
        strength += strengthUp;
        AchievementCollection.strengthUpCollection += 1;
    }

	public void IncreaseAgility(int agilityUp) {
		agility += agilityUp;
		AchievementCollection.agilityUpCollection += 1;
	}

	/**
		Because this changes dynamically on item pickup
		the mod needs to be calculated on its own, without the current stamina
		as that would double dip in the stamina increase and cause non linear
		increases in stamina
	*/
	public void IncreaseStamina(int staminaUp) {
		stamina += staminaUp;
		currentHealth += staminaUp;
		healthBar.IncreaseMaxHealth(currentHealth + staminaUp, maxHealth + staminaUp);
		AchievementCollection.staminaUpCollection += 1;

	}

	public void PickUpHealthUp(int healthUp) {
		IncreaseMaxHealth(healthUp);
		AchievementCollection.healthUpCollection += 1;
	}

	public void PickUpPoison(int poisonValue) {
		TakeDamage(poisonValue);
		AchievementCollection.poisonCollection += 1;
	}

	public void AddKill() {
		AchievementCollection.killCollection += 1;
		AchievementCollection.killStreak += 1;
	}

	// call when player dies
	public void ResetKillStreak() {
		AchievementCollection.killStreak = 0;
	}

}
