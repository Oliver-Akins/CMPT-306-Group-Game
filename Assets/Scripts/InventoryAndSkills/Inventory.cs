using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
	// The item list!
	private List<InventoryItem> itemList;
	private Dictionary<string, InventoryItem> equippedItems;

	/**
		Action is just a void delegate; allows this to call the method the
		player object without a direct reference to the player
	*/
	private Action<InventoryItem> useInventoryItemAction;

	public Inventory(Action<InventoryItem> useInventoryItemAction){
		this.useInventoryItemAction = useInventoryItemAction;
		itemList = new List<InventoryItem>();
		equippedItems = new Dictionary<string, InventoryItem>();
	}

	/**
		Overloaded constructor to allow the inventory to instantiate with
		an already existing item list (aka changing scenes)
	*/
	public Inventory(Action<InventoryItem> useInventoryItemAction,
		List<InventoryItem> alreadyExistingItems,
		Dictionary<string, InventoryItem> prevEquippedItems){
			this.useInventoryItemAction = useInventoryItemAction;
			itemList = alreadyExistingItems;
			equippedItems = prevEquippedItems;
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

	public Dictionary<string, InventoryItem> GetEquipped(){
		return equippedItems;
	}

	public bool IsEmpty(){
		return itemList.Count <= 0;
	}

	// this uses the void delegate to use all consumable and equippable items
	public void UseItem(InventoryItem item){
		useInventoryItemAction(item);
	}

	public void RemoveItem( InventoryItem item){
		if (item.IsStackable()){
			InventoryItem itemInInventory = null;
			foreach (InventoryItem inventoryitem in itemList){
				if (item.type == inventoryitem.type){
					inventoryitem.amount -= item.amount;
					itemInInventory = inventoryitem;
				}
			} if (itemInInventory != null && itemInInventory.amount <= 0){ // adds the first instance of stackable items
				itemList.Remove(itemInInventory);
				Tooltip.HideTooltip_Static();
			}
		} else {
			itemList.Remove(item);
		}
	}

	public void EquipMeleeWeap( InventoryItem item){
		string key = "equippedMelee";
		if (equippedItems.ContainsKey(key)){
			equippedItems[key] = item;
		} else {
			equippedItems.Add(key, item);
		}
	}

	public void EquipRangeWeap( InventoryItem item){
		string key = "equippedRange";
		if (equippedItems.ContainsKey(key)){
			equippedItems[key] = item;
		} else {
			equippedItems.Add(key, item);
		}
	}

	public InventoryItem FindItem(ItemTypes.ItemType itemType){
		foreach(InventoryItem item in itemList){
			if ( item.type == itemType){
				return item;
			}
		}
		return null;
	}
};
