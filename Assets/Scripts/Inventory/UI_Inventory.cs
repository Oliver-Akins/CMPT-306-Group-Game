using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		RefreshInventoryItems();
	}

	public void RefreshInventoryItems(){
		int x = 0;
		int y = 0;
		float itemSlotCellSize = 40f;
		foreach(InventoryItem item in inventory.GetItemList()){
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate,
				itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize,
				 y * itemSlotCellSize);
			Image itemImage = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
			itemImage.sprite = item.GetSprite();
			x++;
			if (x > 6){
				x = 0;
				y++;
			}
		}
	}
};