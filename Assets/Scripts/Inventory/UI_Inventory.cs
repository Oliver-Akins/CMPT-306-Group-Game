using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour {
	private Inventory inventory;

	private Transform itemSlotContainer;
	private Transform itemSlotTemplate;

	private void Awake() {
		itemSlotContainer = transform.Find("ItemSlotContainer");
		itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
	}
	public void SetInventory(Inventory inventory){
		this.inventory = inventory;
		if (!this.inventory.IsEmpty()){
			RefreshInventoryItems();
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
			// just hidden
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate,
				itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			// if the item is equipable, equip with left click
			if (item.IsEquipable()){
				itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
					// equip things!
				};
			} else if (item.IsConsumable()){ // If the item is consumable, use on left click
				itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
					SoundAssets.Instance.playUseSound(item.type);
					InventoryItem dupitem = new InventoryItem{type = item.type, amount = item.amount};
					inventory.UseItem(dupitem);
				};
			}
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
			if (x > 4){
				x = 0;
				y++;
			}
		}
	}
};