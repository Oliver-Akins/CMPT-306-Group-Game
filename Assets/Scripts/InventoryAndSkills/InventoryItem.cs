using UnityEngine;

/**
	This is to use with the inventory and the inventory UI, objects cannot
	be created (via new keyword) as object is mono behaviour thus illegal to
	create like that. This fixes that problem
*/
public class InventoryItem {

	public ItemTypes.ItemType type;
	public int amount;
	
	public string GetTooltipText(){
		string weapText = "\nLeft click to equip";
		switch(type){
			default:
			case ItemTypes.ItemType.COIN:
				return "Coins are used to buy stat upgrades and skills";
			case ItemTypes.ItemType.POTION:
				return "Potions, heal you can be used by clicking the potion or hitting H key";
			case ItemTypes.ItemType.KEY:
				return "Keys are used to automatically open chests";
			case ItemTypes.ItemType.SWORD:
				return "Sword, slash multiple enemies" + weapText;
			case ItemTypes.ItemType.FLAIL:
				return "Flail, crush your enemy from outside their reach" + weapText;
			case ItemTypes.ItemType.SCYTHE:
				return "Scythe, reap your enemies within a large area" + weapText;
			case ItemTypes.ItemType.ROCK:
				return "Rock, throw dirty snowballs at your enemies" + weapText;
			case ItemTypes.ItemType.ARROW:
				return "Arrow, leave your enemies bleeding" + weapText;
			case ItemTypes.ItemType.FIREBALL:
				return "Fireball, essentially a smol projectile sun to burn enemies" + weapText;
		}
	}

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