using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAoE : MonoBehaviour{

    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start(){
        particle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other){
        int numCollisionEvents = particle.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents){
            if (other.layer == 8){
            }
        }
    }
    public void AoE(){
        Player player = FindObjectOfType<Player>();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
			transform.position, 4f, 8);
        foreach(Collider2D enemy in hitEnemies){
			// get access to the controller script and access the public methods
			enemy.GetComponent<EnemyController>().TakeDamage(10 + player.strength);
	    }
    }

    // used for testing and visually seeing the melee attack point. 
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, 2.5f);
	}
}
