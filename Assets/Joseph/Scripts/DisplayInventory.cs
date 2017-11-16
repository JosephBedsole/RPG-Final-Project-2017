using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour {


	[Header("Inventory Slots")]
	public Transform[] slots;
	public Transform slot;
	public Transform slotDefault;
	public RectTransform parent;

	[Header("Inventory Item Stats")]
	public Image iImage;
	public Text iEquipName;
	public Text iDamage;
	public Text iSpeed;
	public Text iCrit;
	public Text iHealth;


	public float yOffset = 1;

	Items tempItem;

	private UnityAction actionToTake;


	void DisplayInventoryStats (Items item) // Items item
	{
		iImage.sprite = item.uiSprite.sprite;
		iEquipName.text = item.name;
		iDamage.text = "Damage: " + item.minDamage + " - " + item.maxDamage;
		iSpeed.text = "Speed: " + item.speed;
		iCrit.text = "Crit: " + item.crit;
		iHealth.text = "Health: " + item.health;
	}

	public void Display ()
	{
		// Figure out how to set the button positions to the correct spots
		
		Transform prevSlot = slotDefault;
		Vector3 offset = new Vector3(0 , yOffset, 0);

		for (int i = 0; i < PlayerInventory.instance.itemz.Count; ++i)
		{
			Transform newSlot = Instantiate(slot);
			newSlot.gameObject.SetActive(true);
			newSlot.SetParent(parent);
			newSlot.localScale = new Vector3(1, 1, 1);
			newSlot.transform.position = prevSlot.transform.position - offset;

			Items item = PlayerInventory.instance.itemz[i];
			Button newItem = newSlot.GetComponent<Button>();

			actionToTake += delegate{DisplayInventoryStats(item);};
			newItem.onClick.AddListener(actionToTake);

			Text itemText = newSlot.GetComponentInChildren<Text>();
			itemText.text = item.itemName;

			Image sprite = newSlot.transform.Find("Item Sprite").GetComponent<Image>();
			sprite.sprite = item.uiSprite.sprite;

			// set height of parent;
			prevSlot = newSlot;

		}
	}

	// This is an alternate to the above function that uses the DisplayStats script rather than keeping everything within this script;

	// public void Display ()
	// {
	// 	Transform prevSlot = slotDefault;
	// 	Vector3 offset = new Vector3(0 , yOffset, 0);

	// 	for (int i = 0; i < PlayerInventory.instance.itemz.Count; ++i)
	// 	{
	// 		Transform newSlot = Instantiate(slot);
	// 		newSlot.gameObject.SetActive(true);
	// 		newSlot.SetParent(parent);
	// 		newSlot.localScale = new Vector3(1, 1, 1);
	// 		newSlot.transform.position = prevSlot.transform.position - offset;

	// 		Items item = PlayerInventory.instance.itemz[i];
	// 		DisplayStats thisItem = newSlot.GetComponent<DisplayStats>();
	// 		thisItem.item = item;

	// 		Text itemText = newSlot.GetComponentInChildren<Text>();
	// 		itemText.text = item.itemName;

	// 		Image sprite = newSlot.transform.Find("Item Sprite").GetComponent<Image>();
	// 		sprite.sprite = item.uiSprite.sprite;

			

	// 		// Set the scriptable object
	// 		// Set the image
	// 		// Set the text

	// 		// set height of parent;
	// 		prevSlot = newSlot;

	// 	}
	// }
	
		
}
