using UnityEngine;

/**
	This is to use with the inventory and the inventory UI, objects cannot
	be created (via new keyword) as object is mono behaviour thus illegal to
	create like that. This fixes that problem
*/
public class InventoryItem {

	public ItemTypes.ItemType type;
	public int amount;
	
	public Sprite GetSprite(){
		switch (type){
			default:
			case ItemTypes.ItemType.COIN: return ItemAssets.Instance.coinSprite;
			case ItemTypes.ItemType.KEY: return ItemAssets.Instance.keySprite;
			case ItemTypes.ItemType.POTION: return ItemAssets.Instance.healthPotionSprite;
			case ItemTypes.ItemType.ARROW: return ItemAssets.Instance.arrow;
			case ItemTypes.ItemType.ROCK: return ItemAssets.Instance.rock;
			case ItemTypes.ItemType.FIREBALL: return ItemAssets.Instance.fireball;
			case ItemTypes.ItemType.SWORD: return ItemAssets.Instance.sword;
			case ItemTypes.ItemType.FLAIL: return ItemAssets.Instance.flail;
			case ItemTypes.ItemType.SCYTHE: return ItemAssets.Instance.scythe;
		}
	}

	public bool IsStackable(){
		switch(type){
			default:
			case ItemTypes.ItemType.COIN:
			case ItemTypes.ItemType.POTION:
			case ItemTypes.ItemType.KEY:
				return true;
			case ItemTypes.ItemType.SWORD:
			case ItemTypes.ItemType.FLAIL:
			case ItemTypes.ItemType.SCYTHE:
			case ItemTypes.ItemType.ROCK:
			case ItemTypes.ItemType.ARROW:
			case ItemTypes.ItemType.FIREBALL:
				return false;
		}
	}

	public bool IsEquipable(){
		switch(type){
			default:
			case ItemTypes.ItemType.COIN:
			case ItemTypes.ItemType.POTION:
			case ItemTypes.ItemType.KEY:
				return false;
			case ItemTypes.ItemType.SWORD:
			case ItemTypes.ItemType.FLAIL:
			case ItemTypes.ItemType.SCYTHE:
			case ItemTypes.ItemType.ROCK:
			case ItemTypes.ItemType.ARROW:
			case ItemTypes.ItemType.FIREBALL:
				return true;
		}
	}

	public bool isMeleeWeap(){
		switch(type){
			default:
			case ItemTypes.ItemType.COIN:
			case ItemTypes.ItemType.POTION:
			case ItemTypes.ItemType.KEY:
			case ItemTypes.ItemType.ROCK:
			case ItemTypes.ItemType.ARROW:
			case ItemTypes.ItemType.FIREBALL:
				return false;
			case ItemTypes.ItemType.SWORD:
			case ItemTypes.ItemType.FLAIL:
			case ItemTypes.ItemType.SCYTHE:
				return true;
		}
	}
	
	public bool isRangeWeap(){
			switch(type){
			default:
			case ItemTypes.ItemType.COIN:
			case ItemTypes.ItemType.POTION:
			case ItemTypes.ItemType.KEY:
			case ItemTypes.ItemType.SWORD:
			case ItemTypes.ItemType.FLAIL:
			case ItemTypes.ItemType.SCYTHE:
				return false;
			case ItemTypes.ItemType.ROCK:
			case ItemTypes.ItemType.ARROW:
			case ItemTypes.ItemType.FIREBALL:
				return true;
		}
	}

	/** 
		checks if the item is consumable by the user, like a health pot
		currently keys and coins aren't considered comsumable
		think of this as the user opens up the inventory to heal up by clicking 
		potions
	*/
	public bool IsConsumable(){
		switch(type){
			default:
			case ItemTypes.ItemType.POTION:
				return true;
			case ItemTypes.ItemType.COIN:
			case ItemTypes.ItemType.KEY:
			case ItemTypes.ItemType.SWORD:
			case ItemTypes.ItemType.FLAIL:
			case ItemTypes.ItemType.SCYTHE:
			case ItemTypes.ItemType.ROCK:
			case ItemTypes.ItemType.ARROW:
			case ItemTypes.ItemType.FIREBALL:
				return false;
		}
	}
};