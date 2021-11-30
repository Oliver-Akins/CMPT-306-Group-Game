using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour {

	public static SoundAssets Instance {get; private set;}

	// Start is called before the first frame update
	private void Awake(){
		Instance = this;
	}

	public void playPickupSound(ItemTypes.ItemType type){
		switch(type){
			case ItemTypes.ItemType.COIN:
				source.PlayOneShot(coinPickupSound);
				return;
			case ItemTypes.ItemType.POTION:
				source.PlayOneShot(potionPickupSound);
				return;
		}
	}
	
	public void playUseSound(ItemTypes.ItemType type){
		switch(type){
			case ItemTypes.ItemType.POTION:
				source.PlayOneShot(potionUseSound);
				return;
		}
	}


	public AudioSource source;

	public AudioClip coinPickupSound;
	public AudioClip potionPickupSound;
	public AudioClip potionUseSound;

};