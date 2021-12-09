using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	
	public List<int> burnTickTimers = new List<int>();
	private int burnTickDamage;

	public List<int> bleedTickTimers = new List<int>();
	private int bleedTickDamage;

	private float StunTime;
	private float immuneToStunTime = 3f;
	private bool isStunned = false;
	private EnemyController controller;
	private SpriteRenderer sprite;

	void Start(){
		controller = GetComponent<EnemyController>();
		sprite = GetComponent<SpriteRenderer>();
	}

	/**
		this takes in ticks, which are added to the list of current ticks and
		applications of ticks, but does not start the coroutine more than once
		this allows for damage to be linear but the effective stacks to increase
		so if something special needs to happen at a certain stack number aka
		the length of the ticktimers then we can do that

		we can also have enemies be weak to certain statuses we want! 
	*/	
	public void ApplyBurn(int ticks, int burnTickDamage){
		this.burnTickDamage = burnTickDamage;
		if (burnTickTimers.Count <= 0){
			burnTickTimers.Add(ticks);
			StartCoroutine(Burn());
		} else {
			burnTickTimers.Add(ticks);
		}
	}

	IEnumerator Burn(){
		while(burnTickTimers.Count > 0){
			for(int i = 0; i < burnTickTimers.Count; i++){
				burnTickTimers[i]--;
			}
			sprite.color = Color.yellow;
			controller.TakeDamage(burnTickDamage);
			// remove all zero numbers via predicate passed in :)
			burnTickTimers.RemoveAll(i => i == 0);
			yield return new WaitForSeconds(0.75f);
			sprite.color = Color.white;
			yield return new WaitForSeconds(0.2f);
		}
	}


	public void ApplyBleed(int ticks, int bleedTickDamage){
		this.bleedTickDamage = bleedTickDamage;
		if (bleedTickTimers.Count <= 0){
			bleedTickTimers.Add(ticks);
			StartCoroutine(Bleed());
		} else {
			bleedTickTimers.Add(ticks);
		}
	}

	IEnumerator Bleed(){
		while(bleedTickTimers.Count > 0){
			for(int i = 0; i < bleedTickTimers.Count; i++){
				bleedTickTimers[i]--;
			}
			sprite.color = Color.red;
			controller.TakeDamage(bleedTickDamage);
			// remove all zero numbers via predicate passed in :)
			bleedTickTimers.RemoveAll(i => i == 0);
			yield return new WaitForSeconds(0.5f);
			sprite.color = Color.white;
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void ApplyStun(float time){
		StunTime = time;
		if (!isStunned){
			isStunned = true;
			StartCoroutine(Stun());
		}
	}

	IEnumerator Stun(){
		GetComponent<PolarithMovement>().enabled = false;
		yield return new WaitForSeconds(StunTime);
		GetComponent<PolarithMovement>().enabled = true;
		yield return new WaitForSeconds(immuneToStunTime);
		isStunned = false;
	}
};