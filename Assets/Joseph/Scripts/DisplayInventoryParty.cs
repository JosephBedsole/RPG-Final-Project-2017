using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayInventoryParty : MonoBehaviour {


	[Header("Inventory Slots")]
	public Transform[] slots;
	public Transform slot;
	public Transform slotDefault;
	public RectTransform parent;
	float parentSize = 60;

	[Header("Inventory Item Stats")]
	public Image iImage;
	public Text iEquipName;
	public Text iDamage;
	public Text iSpeed;
	public Text iCrit;
	public Text iHealth;


	public float yOffset = 1;

	Items tempItem;

	private UnityAction firstAction;
	private UnityAction secondAction;


	void DisplayInventoryStats (Items item) // Items item
	{
		iImage.sprite = item.uiSprite.sprite;
		iEquipName.text = item.name;
		iDamage.text = "Damage: " + item.minDamage + " - " + item.maxDamage;
		iSpeed.text = "Speed: " + item.speed;
		iCrit.text = "Crit: " + item.crit;
		iHealth.text = "Health: " + item.health;
	}

	MenuController menuCon = MenuController.instance;

	public void EquipItem (Items itemSelected) // This will equip an item to the selected character
	{
		Debug.Log("YeeeeeeeeeeeeEEEEEESSSSSSSSssssssssssss");
		// if (player class == weapon class);
		if (menuCon.characterSelected.mainHand.itemTag == "weapon") // item tag == weapon
		{
			//   Move the currently equipped item to the inventory
			menuCon.characterSelected.mainHand = itemSelected;
		}
		else if (menuCon.characterSelected.armor.itemTag == "armor") // item tag == armor
		{
			menuCon.characterSelected.armor = itemSelected;
		}
		else if (menuCon.characterSelected.accessory.itemTag == "accessory") // item tag == accessory
		{
			menuCon.characterSelected.accessory = itemSelected;
		}
		else
		{
			Debug.Log("You can't equip that item dingus!");
		}
		// else
		// Display: "You can't equip that class of weapon."
	}

	public void Display ()
	{
		// Figure out how to set the button positions to the correct spots (Done: now do it better);

		// NEED A INVENTORY CLEAR FUNCTION;
		// everytime the player exits an inventory screen;
		// Should put all of the buttons into a List;
		// Then clear the list and reset the parentSize to 60;
		// Could just set the parentSize to 60 and not clear the List;
		
		Transform prevSlot = slotDefault;
		Vector3 offset = new Vector3(0 , yOffset, 0);

		for (int i = 0; i < PlayerInventory.instance.itemz.Count; ++i)
		{
			Transform newSlot = Instantiate(slot);
			newSlot.gameObject.SetActive(true);
			newSlot.SetParent(parent);
			newSlot.localScale = new Vector3(1, 1, 1);

			if (i == 0)
			{
				newSlot.transform.position = prevSlot.transform.position;
			}
			else
			{
				newSlot.transform.position = prevSlot.transform.position - offset;
			}

			//   For second action get a second button that is on the displayed inventory stats screen;

			Items item = PlayerInventory.instance.itemz[i];
			PlayerInventory slotitem = newSlot.GetComponent<PlayerInventory>();
			Button newItem = newSlot.GetComponent<Button>();
			Button equipItemButton = newSlot.transform.Find("Equip Button").GetComponent<Button>();   //   Editing Starts Here

			firstAction += delegate{DisplayInventoryStats(item);};  
			secondAction += delegate{EquipItem(item);};                           //   This is where I'm giving the button an onClick() event;
			newItem.onClick.AddListener(firstAction);
			equipItemButton.onClick.AddListener(secondAction);

			Text itemText = newSlot.GetComponentInChildren<Text>();
			itemText.text = item.itemName;

			Image sprite = newSlot.transform.Find("Item Sprite").GetComponent<Image>();
			sprite.sprite = item.uiSprite.sprite;

			parentSize += 60.0f;

			RectTransform parentRect = parent.GetComponent<RectTransform>();
			parentRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0.0f, parentSize);

			// set height of parent;
			prevSlot = newSlot;

		}

	}

	public void ResizeParent ()
	{
		parentSize = 60;
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
