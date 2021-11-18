using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAtPlayer : MonoBehaviour {

	private Animator myAnim;
	private Transform target;
	private EnemyController controller;

	// Start is called before the first frame update
	void Start() {
		this.controller = this.GetComponent<EnemyController>();
		this.myAnim = this.GetComponent<Animator>();
		this.target = FindObjectOfType<Player>().transform;
	}

	// Update is called once per frame
	void Update() {

		var distance = Vector3.Distance(
			this.target.position,
			this.transform.position
		);

		// Ensure that the target is within range of the enemy
		if (
			distance <= this.controller.maxRange
			&& distance >= this.controller.minRange
		) {
			this.pathfind();
		};
	}

	private void pathfind() {
		myAnim.SetBool("WithinRange", true);

		// myAnim.SetFloat(
		// 	"Horizontal",
		// 	( this.target.position.x - this.transform.position.x )
		// );
		// myAnim.SetFloat(
		// 	"Vertical",
		// 	( this.target.position.y - this.transform.position.y )
		// );

		transform.position = Vector3.MoveTowards(
			this.transform.position,
			this.target.transform.position,
			this.controller.speed * Time.fixedDeltaTime
		);
	}
};