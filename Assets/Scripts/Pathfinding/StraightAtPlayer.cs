using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAtPlayer : MonoBehaviour {

	private Animator myAnim;
	private Transform target;
	private EnemyController controller;

	private bool startedMoving;
	private bool hasToDoTransformAnim;

	// Start is called before the first frame update
	void Start() {
		this.controller = this.GetComponent<EnemyController>();
		this.myAnim = this.GetComponent<Animator>();
		this.target = FindObjectOfType<Player>().transform; 
		foreach( AnimatorControllerParameter param in myAnim.parameters ){
			if( param.name == "DoTransform" ){
				Debug.Log(true);
				this.hasToDoTransformAnim = true;
			}		
		}
	}

	// Update is called once per frame
	void Update() {

		var distance = Vector3.Distance(
			this.target.position,
			transform.position
		);
		// Ensure that the target is within range of the enemy
		if (
			distance <= this.controller.maxRange
			&& distance >= this.controller.minRange
		) {
			if (this.startedMoving == false){
				if( this.hasToDoTransformAnim){
					this.myAnim.SetTrigger("DoTransform");
				}
				this.startedMoving = true;
			}
			this.pathfind();
		} else {
			this.startedMoving = false;
			if( this.hasToDoTransformAnim){
				this.myAnim.SetTrigger("DoTransform");
			}
		}
		if (distance <= this.controller.attackRange){
			if (this.controller.timeBetweenAttacks <= 0){
				this.controller.Attack();
				this.controller.timeBetweenAttacks = this.controller.startTimeBetweenAttacks;
			} else {
				this.controller.timeBetweenAttacks -= Time.deltaTime;
			}
		}
	}

	private void pathfind() {
		// myAnim.SetBool("WithinRange", true);

		// myAnim.SetFloat(
		// 	"Horizontal",
		// 	( this.target.position.x - this.transform.position.x )
		// );
		// myAnim.SetFloat(
		// 	"Vertical",
		// 	( this.target.position.y - this.transform.position.y )
		// );

		Vector3 moveDirection = Vector3.MoveTowards(
			transform.position,
			this.target.transform.position,
			this.controller.speed * Time.fixedDeltaTime
		);
		
		myAnim.SetFloat("Horizontal", this.target.position.x - this.transform.position.x);
		transform.position = moveDirection;

	}
};