using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
	private List<InventoryItem> itemList;

	public Inventory(){
		itemList = new List<InventoryItem>();
	}

	public void AddItem( ItemTypes.ItemType itemType, int value){
		// create the item
		InventoryItem item = new InventoryItem { type = itemType, amount = value}; 
		if (item.IsStackable()){
			bool itemAlreadyAdded = false;
			// find the matching item. Should be fine with smol inventory
			// but maybe a dictionary would be better? 
			foreach (InventoryItem inventoryitem in itemList){
				if (item.type == inventoryitem.type){
					inventoryitem.amount += item.amount;
					itemAlreadyAdded = true;
				}
			} if (!itemAlreadyAdded){ // adds the first instance of stackable items
				itemList.Add(item);
			}
		} else {
			itemList.Add(item);
		}
	}

	public List<InventoryItem> GetItemList(){
		return itemList;
	}

	public bool IsEmpty(){
		return itemList.Count <= 0;
	}
};
