using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	/** This contains code that can create an effect when the rock hits something
	 I do not have the animation for hit in the game so it will need to be done
	 But it will help when we have a skill tree if we wanna add in special
	 effects per upgrade. 
	*/
	// public GameObject hitEffect;
	
	public int damageAmount;
	public LayerMask enemyLayers;

	/** only hell this is the ONLY way ive found so far to ensure that the
		player's collider doesn't interfere with the projectiles.
		1. make sure the player sprite cannot rotate -.-
		2. make sure the firepoint DOES and CAN rotate (and follow player position)
		3. make sure the collider is a trigger
		4. do things in trigger and check the layers even though its set
		TO NOT INTERACT but really the rock doesn't know what its hitting... unless it checks :)
	*/
	void OnTriggerEnter2D(Collider2D collisionInfo){
		// GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		// Destroy(effect, 5f);	
		int hitLayer = collisionInfo.gameObject.layer;
		if (hitLayer == 7  || hitLayer == 8){
			// we hit an enemy!
			if (hitLayer == 8){
				collisionInfo.GetComponent<EnemyController>().TakeDamage(damageAmount);
			}
			Destroy(gameObject);
		}
	}
};