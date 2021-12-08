using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevels {

	Dictionary<string, int> skillLevels;

	Inventory inventory;

	public SkillLevels(){
		skillLevels = new Dictionary<string, int>();
		skillLevels.Add("Stun", 0);
		skillLevels.Add("Piercing", 0);
		skillLevels.Add("Dash", 0);
		skillLevels.Add("Multiply", 0);
	}

	public SkillLevels(Dictionary<string, int> existingSkills){
		skillLevels = existingSkills;
	}

	public Dictionary<string, int> getSkills(){
		return skillLevels;
	}

	public void setSkills(Dictionary<string, int> skills){
		skillLevels = skills;
	}

	public void SetInventory(Inventory inventoryItems){
		inventory = inventoryItems;
	}

	public void BuyStat(string statName){
		InventoryItem item = inventory.FindItem(ItemTypes.ItemType.COIN);
		if ( item != null && item.amount >= 25){
			inventory.UseItem(new InventoryItem{type = item.type, 
				amount = 25});
			skillLevels[statName]++;
		}
	}
};