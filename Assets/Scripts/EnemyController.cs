using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
	// a animator variable
	private Animator myAnim; 
	// To keep track of the player
	private Transform target;

	[SerializeField]
	private float speed;

	// variables to restrict the range of enemies can be modified here.
	public float maxRange = 4f;

	public float minRange = 0.75f;

	// Start is called before the first frame update
	void Start() {
		// getting an animator and player object to operate onto.
		myAnim = GetComponent<Animator>();
		target = FindObjectOfType<Player>().transform;
	}

	// Update is called once per frame
	void Update() {
		// To use the follow mechanics to catch the player.
		if ((Vector3.Distance(target.position, transform.position) <= maxRange) && (Vector3.Distance(target.position, transform.position) >= minRange)) {
			FollowMechanics();
		}
	}
	// Follow mechanics to catch the player.
	void FollowMechanics(){
		myAnim.SetBool("WithinRange",true);
    
	    // some math equations to calculate the relative position of player and enemy.
		myAnim.SetFloat("Horizontal",(target.position.x - transform.position.x));
		myAnim.SetFloat("Vertical",(target.position.y - transform.position.y));

		// used to move towards the player
		transform.position = Vector3.MoveTowards(transform.position,target.transform.position,speed*Time.fixedDeltaTime);

	}
}