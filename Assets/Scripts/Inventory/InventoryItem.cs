using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {

	public ItemTypes.ItemType type;
	public int amount;
	
	public Sprite GetSprite(){
		switch (type){
			default:
			case ItemTypes.ItemType.COIN: return ItemAssets.Instance.coinSprite;
			case ItemTypes.ItemType.KEY: return ItemAssets.Instance.keySprite;
			case ItemTypes.ItemType.POTION: return ItemAssets.Instance.healthPotionSprite;
		}
	}
};