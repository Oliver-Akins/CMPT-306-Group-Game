using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
	
	// set object type
	public ItemTypes.ItemType type;
	// object value to be added or subtracted
	public int value;
	
	public List<GameObject> chestLoot;	
	public Player player;

	void Awake() {
		player = FindObjectOfType<Player>();
	}

	// this works better to make sure the player doesn't weirdly run over the chest
	// i don't think anything else can trigger it but will check
	void OnCollisionEnter2D(Collision2D collisionInfo){
		player.openChest(gameObject);

	}
};