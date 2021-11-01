using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Attack : MonoBehaviour {

	public Animator animator;
	public Transform meleeAttackPoint;
	public float attackRange = 0.5f;
	
	public LayerMask enemyLayers;
	// Update is called once per frame
	void Update() {
		if (Input.GetButtonDown("Fire1")){
			Attack();
		}
	}

	void Attack(){
		// attack animation trigger (in animator is the trigger param )
		animator.SetTrigger("Attack");
		// detect enemies in range
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeAttackPoint.position, attackRange, enemyLayers);

		// damage the enemies the player hits, obviously we need enemies to have 
		// health and colliders first
		foreach(Collider2D enemy in hitEnemies){
			Debug.Log("We hit" + enemy.name);
		}
	}

	// used for testing and visually seeing the attack range. 
	void OnDrawGizmosSelected(){
		if (meleeAttackPoint == null){
			return;
		}
		Gizmos.DrawWireSphere(meleeAttackPoint.position, attackRange);
	}
};