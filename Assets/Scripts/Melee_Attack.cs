using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Attack : MonoBehaviour {

	public Animator animator;
	// using a circluar attack point to allow for multiple enemies to be hit
	public Transform meleeAttackPoint;
	public Camera cam;
	public float attackRange = 0.4f;
	// limit player attack time, increase with agility!
	private float timeBetweenAttacks;
	public float startTimeBetweenAttacks;
	// The enemy layer used to check hits
	public LayerMask enemyLayers;
	// attack damage, will change based on weap and strength
	public int attackDamage;
	// Update is called once per frame

	public Player player;
	void Update() {
		if (startTimeBetweenAttacks > 0){
			float agiMod = startTimeBetweenAttacks * (( (float)player.agility /2)/ 10);
			if ( timeBetweenAttacks <= 0){
				if (Input.GetButtonDown("Fire1")){
					Attack();
					timeBetweenAttacks = startTimeBetweenAttacks - agiMod;
					if (agiMod > startTimeBetweenAttacks){
						startTimeBetweenAttacks = 0;
					}
				}
			} else {
				timeBetweenAttacks -= Time.deltaTime;
			}
		} else if (Input.GetButtonDown("Fire1") && startTimeBetweenAttacks <= 0) {
			Attack();
		}
	}

	void Attack(){
		// a boat load of math to move the melee attack point near the mouse position
		// the current mouse position in world coordinates
		Vector3 mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
		// the direction the mouse is relative to the player
		Vector3 mouseDirection = (mouseposition - transform.position).normalized;
		// the offset to move the the attack position, this moves the attack point outwards
		// can be tweaked as needed, 1f may be enough.
		float attackOffset = 1.5f;
		Vector3 attackPosition = transform.position + mouseDirection * attackOffset;
		// attack animation trigger (in animator this is the trigger param)
		// wondering how we can set this to be more fluid and play other animations
		animator.SetTrigger("Attack");

		meleeAttackPoint.SetPositionAndRotation(attackPosition, meleeAttackPoint.rotation);
		// detect enemies in range/hit, they need to be on the enemy layer btw
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
			meleeAttackPoint.position, attackRange, enemyLayers);

		// base attack damage is modified by strength
		// each point of strength is a 10 percent increase in base damage
		float attackMod = attackDamage * ( ((float)player.strength)/10);

		// detect enemies hit, this allows for clustered enemies to all get hit
		// with a wider range like a sweeping sword attack
		foreach(Collider2D enemy in hitEnemies){
			// get access to the controller script and access the public methods
			enemy.GetComponent<EnemyController>().TakeDamage(attackDamage + Mathf.RoundToInt(attackMod));
		}
	}

	// used for testing and visually seeing the melee attack point. 
	void OnDrawGizmosSelected(){
		if (meleeAttackPoint == null){
			return;
		}
		Gizmos.DrawWireSphere(meleeAttackPoint.position, attackRange);
	}
};