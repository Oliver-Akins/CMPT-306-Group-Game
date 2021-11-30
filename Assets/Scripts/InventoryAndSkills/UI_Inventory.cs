using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour {
	private Inventory inventory;

	private Transform itemSlotContainer;
	private Transform itemSlotTemplate;

	private Transform meleeWeapSlot;

	private Transform rangeWeapSlot;

	private void Awake() {
		itemSlotContainer = transform.Find("ItemSlotContainer");
		meleeWeapSlot = transform.Find("MeleeWeap");
		rangeWeapSlot = transform.Find("RangeWeap");
		itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
	}

	public void SetInventory(Inventory inventory){
		this.inventory = inventory;
		if (!this.inventory.IsEmpty()){
			RefreshInventoryItems();
			RefreshEquippedItems();
		}
	}

	public void RefreshInventoryItems(){
		/**
			cleans up everything in the inventory leaving the template
			this allows the items to be flush against the origin point in the
			container, it also cleans it up when an item is removed (cuz its
			consumable). It keeps the complexity low as we never have to check
			where an item already is in the container.
		*/
		// if (itemSlotContainer == null){
		// 	itemSlotContainer = transform.Find("ItemSlotContainer");
		// }
		foreach (Transform child in itemSlotContainer){
			if (child == itemSlotTemplate) continue;
			else Destroy(child.gameObject);
		}
		// then put everything back into the inventory
		int x = 0;
		int y = 0;
		// this is whack but it is the correct size for 15 slots to fit nicely
		float itemSlotCellSize = 62f; 
		foreach(InventoryItem item in inventory.GetItemList()){
			// use the template to create a slot item; the template is always there
			// just hidden/inactive
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate,
				itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			// if the item is equipable, equip with left click
			if (item.IsEquipable()){
				// if melee weap equip in melee slot
				if (item.isMeleeWeap()){
					itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
						inventory.UseItem(item);
						RefreshEquippedItems();
					};
				}

				// if ranged weap equip in range slot
				if (item.isRangeWeap()){
					itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
						inventory.UseItem(item);
						RefreshEquippedItems();
					};
				}
			
			} else if (item.IsConsumable()){ // If the item is consumable, use on left click
				itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
					SoundAssets.Instance.playUseSound(item.type);
					InventoryItem dupitem = new InventoryItem{type = item.type, amount = item.amount};
					inventory.UseItem(dupitem);
				};
			}
			itemSlotRectTransform.GetComponent<Button_UI>().MouseOverOnceFunc = () =>{
				Tooltip.ShowTooltip_Static(item.GetTooltipText());	
			};
			itemSlotRectTransform.GetComponent<Button_UI>().MouseOutOnceFunc = () => {
				Tooltip.HideTooltip_Static();
			};
			// otherwise do nothing with button ui stuffs

			// whacky x and y coords, reminds me of cmpt 140
			itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize,
				 -y * itemSlotCellSize);
			Image itemImage = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
			itemImage.sprite = item.GetSprite();
			Text uiText = itemSlotRectTransform.Find("AmountText").GetComponent<Text>();
			uiText.text = item.amount.ToString();
			// :)
			x++;
			// if the row is for columns (slots) wide, start on a new row
			if (x > 4){
				x = 0;
				y++;
			}
		}
	}

	// Instead of checking the equipment every time the user picks something up
	// this lets it be called purposefully; like when the user equips something
	public void RefreshEquippedItems(){
		Dictionary<string, InventoryItem> equippedItems = inventory.GetEquipped();

		Image meleeWeapImg = meleeWeapSlot.Find("ItemImage").GetComponent<Image>();
		meleeWeapImg.sprite = equippedItems["equippedMelee"].GetSprite();

		Image rangeWeapImg = rangeWeapSlot.Find("ItemImage").GetComponent<Image>();
		rangeWeapImg.sprite = equippedItems["equippedRange"].GetSprite();
	}

}