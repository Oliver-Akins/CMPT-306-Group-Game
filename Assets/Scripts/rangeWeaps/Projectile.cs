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
	public bool isBouncy = true;
	public int maxBounces = 30;
	// track how many bounces have happened
	public int howManyBounces = 0;

	// peircing from player skills
	public bool isPeircing = true;
	public int maxPeirces = 2;
	// track how many enemies the projectile has peirced
	public int howManyPeirces;

	StatusManager manager;

	/** only hell this is the ONLY way ive found so far to ensure that the
		player's collider doesn't interfere with the projectiles.
		1. make sure the player sprite cannot rotate -.-
		2. make sure the firepoint DOES and CAN rotate (and follow player position)
		3. make sure the collider is a trigger
		4. do things in trigger and check the layers even though its set
		TO NOT INTERACT but really the rock doesn't know what its hitting... unless it checks :)
	*/
	void OnCollisionEnter2D(Collision2D collisionInfo){
		// GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		// Destroy(effect, 5f);	
		int hitLayer = collisionInfo.gameObject.layer;
		if (hitLayer == 7  || hitLayer == 8){
			if (hitLayer == 7){
				Vector2 wallNormal = collisionInfo.contacts[0].normal;
				Vector2 moveDirection = Vector2.Reflect(rb.velocity, wallNormal).normalized;
				rb.velocity = moveDirection * 20f;
				this.howManyBounces++;
				if (this.howManyBounces > this.maxBounces){
					Destroy(gameObject);
				}
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
				this.howManyPeirces++;
				if (this.howManyPeirces > this.maxPeirces){
					Destroy(gameObject);
				}
			}
		}
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
	}
};