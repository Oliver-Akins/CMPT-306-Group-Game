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

	void Awake() {
		achievements = FindObjectOfType<Achievements>();
	}

	// Start is called before the first frame update
	void Start() {
		// getting an animator and player object to operate onto.
		myAnim = GetComponent<Animator>();
		target = FindObjectOfType<Player>().transform;
		enemyRb = GetComponent<Rigidbody2D>();
		// setup enemy health
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	public void TakeDamage(int damageValue) {
		currentHealth -= damageValue;
		myAnim.SetTrigger("Hurt");
		if (currentHealth <= 0){
			Die();
		}
		healthBar.SetCurrentHealth(currentHealth);
	}

	void Die(){

		AchievementCollection.killCollection += 1;
		AchievementCollection.killStreak += 1;

		achievements.checkAchievements();
		// Die animation
		myAnim.SetBool("IsDead", true);
		// disable enemy script and collider
		GetComponent<Collider2D>().enabled = false;

		Destroy(GetComponent<StraightAtPlayer>());

		Invoke("DestroyEnemy", waitTime);
	}

	void DestroyEnemy(){
		// can have a death effect to if we want
		Destroy(gameObject);

		if(AchievementCollection.killStreak > 4) {
			int coins = Random.Range(2, 5);

			for(int i = 0; i < coins; i++) {
				Instantiate(items[0], transform.position + new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), 0), Quaternion.identity);
			}

			Instantiate(items[Random.Range(1, items.Count-1)], transform.position, Quaternion.identity);

		} else {
			Instantiate(items[Random.Range(0, items.Count-1)], transform.position, Quaternion.identity);
		}

		
	
	}

	public void Attack(){
		myAnim.SetTrigger("Attack");
		Player p = FindObjectOfType<Player>();
		p.TakeDamage(attackDamage);
	}

}