using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
	private List<InventoryItem> itemList;

	public Inventory(){
		itemList = new List<InventoryItem>();
		// AddItem( ItemTypes.ItemType.COIN, 1);
		// AddItem( ItemTypes.ItemType.POTION, 1);
		// AddItem (ItemTypes.ItemType.KEY, 1);

		Debug.Log(itemList.Count);	

	}

	public void AddItem( ItemTypes.ItemType itemType, int value){
		itemList.Add( new InventoryItem { type = itemType, amount = value} );
	}

	public List<InventoryItem> GetItemList(){
		return itemList;
	}
};
