using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// a animator variable
	public Animator myAnim;
	public Rigidbody2D enemyRb;
	// To keep track of the player
	private Transform target;

	public float speed;
	public bool dead;

	// variables to restrict the range of enemies can be modified here.
	public float maxRange;

	public float minRange;
	public float attackRange;
	// enemies max and current health
	public int maxHealth;
	public int currentHealth;
	public HealthBar healthBar;

	public float waitTime;

	public List<GameObject> items = new List<GameObject>();

	public Achievements achievements;

	public float timeBetweenAttacks;
	public float startTimeBetweenAttacks;
	public int attackDamage;

	public Transform meleeAttackPoint;
	public LayerMask playerLayer;

	void Awake() {
		achievements = FindObjectOfType<Achievements>();
	}

	// Start is called before the first frame update
	void Start() {
		// getting an animator and player object to operate onto.
		myAnim = GetComponent<Animator>();
		target = FindObjectOfType<Player>().transform;
		enemyRb = GetComponent<Rigidbody2D>();

		// setup enemy health and scaling
		maxHealth = maxHealth + (10 * (GameStateManager.Instance.level - 1));
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		// setup attack damage and scaling
		attackDamage = attackDamage + (2 * (GameStateManager.Instance.level - 1));
	}

	public void TakeDamage(int damageValue) {
		currentHealth -= damageValue;
		myAnim.SetTrigger("Hurt");
		if (currentHealth <= 0){
			// this needs to be removed here so that the dots don't keep ticking
			// when the enemy is dead
			Destroy(GetComponent<StatusManager>());
			Die();
		}
		healthBar.SetCurrentHealth(currentHealth);
	}

	void Die(){

		AchievementCollection.killCollection += 1;
		AchievementCollection.killStreak += 1;

		achievements.checkAchievements();
		// Die animation and sound
		SoundAssets.Instance.playEnemeyDeathSound();
		myAnim.SetBool("IsDead", true);
		// disable enemy script and collider
		GetComponent<Collider2D>().enabled = false;

		this.dead = true;

		Invoke("DestroyEnemy", waitTime);
	}

	void DestroyEnemy(){	

		// can have a death effect to if we want
		Destroy(gameObject);

		// enemies drop 2-5 coins during killstreak
		if(AchievementCollection.killStreak > 4) {
			int coins = Random.Range(2, 5);

			for(int i = 0; i < coins; i++) {
				Instantiate(items[0], transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
			}

			Instantiate(items[Random.Range(1, items.Count-1)], transform.position, Quaternion.identity);

		} else {
			Instantiate(items[Random.Range(0, items.Count-1)], transform.position, Quaternion.identity);
		}
	}

	public void Attack(){
		SoundAssets.Instance.playEnemeyAttackSound();	
		myAnim.SetTrigger("Attack");
		Invoke("dealDamage", .5f);
	}

	void dealDamage(){
		Collider2D[] hitplayer = Physics2D.OverlapCircleAll(meleeAttackPoint.position, 1f, playerLayer);
		foreach(Collider2D player in hitplayer){
			player.GetComponent<Player>().TakeDamage(attackDamage);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(meleeAttackPoint.position, .7f);
	}
}