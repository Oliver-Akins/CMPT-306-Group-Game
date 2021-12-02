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
			case ItemTypes.ItemType.KEY:
				source.PlayOneShot(keyPickupSound);
				return;
			case ItemTypes.ItemType.POTION:
				source.PlayOneShot(potionPickupSound);
				return;
			case ItemTypes.ItemType.STRENGTHUP:
				source.PlayOneShot(statUpSound);
				return;
			case ItemTypes.ItemType.AGILITYUP:
				source.PlayOneShot(statUpSound);
				return;
			case ItemTypes.ItemType.STAMINAUP:
				source.PlayOneShot(statUpSound);
				return;
			case ItemTypes.ItemType.STATSUP:
				source.PlayOneShot(statUpSound);
				return;
			case ItemTypes.ItemType.POISON:
				source.PlayOneShot(poisinPickup);
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

	public void playWalkSound(){

		source.PlayOneShot(footStepSound, Random.Range(0.35f,.75f));
		// source.PlayOneShot(footStepSound, 0.75f);
		return;
		}

	public AudioSource source;
	public AudioClip coinPickupSound;
	public AudioClip keyPickupSound;
	public AudioClip potionPickupSound;
	public AudioClip potionUseSound;
	public AudioClip statUpSound;
	public AudioClip poisinPickup;
	public AudioClip footStepSound;



};