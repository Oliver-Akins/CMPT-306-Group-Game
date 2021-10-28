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
	
	void OnCollisionEnter2D(Collision2D collisionInfo){
		// GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		// Destroy(effect, 5f);
		Destroy(gameObject);
	}
};