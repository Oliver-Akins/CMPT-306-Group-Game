using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	/** This contains code that can create an effect when the rock hits something
	 I do not have the animation for hit in the game so it will need to be done
	 But it will help when we have a skill tree if we wanna add in special
	 effects per upgrade. 
	*/
	// public GameObject hitEffect;

	public Rigidbody2D rb; 
	public LayerMask enemyLayers;
	private int damageAmount;
	
	// Burn from fireball projectiles
	private int burnTicks = 0;
	private int burnTickDamage = 0;

	// bleed from arrows
	private int bleedTicks = 0;
	private int bleedTickDamage = 0;

	// bouncy from player skills
	private bool isPiercing = false;
	private int maxPeirces = 0;
	// track how many bounces have happened
	private int howManyPeirces = 0;

	// AOE DOESN'T WORK; maybe one day it will be solvable.

	// if the projectile is explody 
	// private bool isAoE = false;
	// private int AoEDamage = 0;	

	// [SerializeField]
	// private GameObject particleEffect;

	StatusManager manager;

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
			if (hitLayer == 7){
				destroyThis();
			}

			// we hit an enemy!
			if (hitLayer == 8){
				EnemyController controller = collisionInfo.gameObject.GetComponent<EnemyController>();
				StatusManager manager = controller.GetComponent<StatusManager>();
				controller.TakeDamage( damageAmount);
				if (burnTicks > 0 && burnTickDamage > 0){
					manager.ApplyBurn(burnTicks, burnTickDamage);
				}
				if (bleedTicks > 0 && bleedTickDamage > 0){
					manager.ApplyBleed(bleedTicks, bleedTickDamage);
				}
				// if (isAoE){
				// 	Instantiate(particleEffect, controller.GetComponent<Transform>());
				// }
				if (isPiercing){
					howManyPeirces++;
					if (howManyPeirces > maxPeirces){
						destroyThis();
					}
				} else {
					destroyThis();
				}
			}
		}
	}

	private void destroyThis(){
		Destroy(gameObject);
	}

	public void setQualities(Hashtable qualities){
		this.damageAmount = (int) qualities["damageAmount"];
		if (qualities.Contains("burnTicks")){
			this.burnTicks = (int) qualities["burnTicks"];
			this.burnTickDamage = (int) qualities["burnTickDamage"];
		}
		else if (qualities.Contains("bleedTicks")){
			this.bleedTicks = (int) qualities["bleedTicks"];
			this.bleedTickDamage = (int) qualities["bleedTickDamage"];
		}
		if (qualities.Contains("maxPeirces")){
			this.isPiercing = true;
			this.maxPeirces = (int) qualities["maxPeirces"];
		}
		// if (qualities.Contains("AoEDamage")){
		// 	this.isAoE = true;
		// 	this.AoEDamage = (int) qualities["AoEDamage"];
		// }
	}
};