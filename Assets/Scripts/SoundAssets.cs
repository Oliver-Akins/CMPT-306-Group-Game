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
			case ItemTypes.ItemType.ARROW:
				source.PlayOneShot(arrowUseSound);
				return;
			case ItemTypes.ItemType.FIREBALL:
				source.PlayOneShot(fireballUseSound);
				return;
		}
	}

	public void playHitSound(ItemTypes.ItemType type){
		switch(type){
			case ItemTypes.ItemType.SWORD:
				source.PlayOneShot(swordHitSound);
				return;
			case ItemTypes.ItemType.SCYTHE:
				source.PlayOneShot(swordHitSound);
				return;
			case ItemTypes.ItemType.FLAIL:
				source.PlayOneShot(swordHitSound);
				return;
			case ItemTypes.ItemType.ROCK:
				source.PlayOneShot(rockHitSound);
				return;
			case ItemTypes.ItemType.ARROW:
				source.PlayOneShot(arrowHitSound);
				return;
			case ItemTypes.ItemType.FIREBALL:
				source.PlayOneShot(fireballHitSound);
				return;
		}
	}

	public void playWalkSound(){

		source.PlayOneShot(footStepSound, Random.Range(0.35f,.75f));
		// source.PlayOneShot(footStepSound, 0.75f);
		return;
	}

	public void playDeathSound(){

		source.PlayOneShot(deathSound);
		return;
	}

	public void playEnemeyAttackSound(){

		source.PlayOneShot(enemyAttack);
		return;
	}

	public void playEnemeyDeathSound(){

		source.PlayOneShot(enemyDeath);
		return;
	}

	public void playChestOpenSound(){
		source.PlayOneShot(chestOpen);
		return;
	}

	public void playChestLockedSound(){
		source.PlayOneShot(chestLocked);
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
	public AudioClip deathSound;
	public AudioClip arrowUseSound;
	public AudioClip fireballUseSound;
	public AudioClip enemyAttack;
	public AudioClip enemyDeath;
	public AudioClip swordHitSound;
	public AudioClip rockHitSound;
	public AudioClip arrowHitSound;
	public AudioClip fireballHitSound;

	public AudioClip chestOpen;
	public AudioClip chestLocked;
};