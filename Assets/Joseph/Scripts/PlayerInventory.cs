using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	public static PlayerInventory instance;
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}



	[Header("Inventory Items")]
	public Items[] items;
	public List<Items> itemz = new List<Items>();

	public Items item;
	public int gold = 0;

	MenuController menuCon = MenuController.instance;

	void Start () 
	{
		item = items[1];
	}
	
	void Update () 
	{

	}

	public void AddItem (Items newItem)   // This will Add an Item from other sources to the PlayerInventory
	{
		itemz.Add(newItem);
		// Call this when buying an item from the shop, opening a chest, or looting an item from battle

		// if (isInShop)    then you should have some sort of exchange of gold
	}

	public void EquipItem (Items itemSelected) // This will equip an item to the selected character
	{
		// if (player class == weapon class);
		if (menuCon.characterSelected.mainHand.itemTag == "weapon") // item tag == weapon
		{
			//   Move the currently equipped item to the inventory
			//   menuCon.characterSelected.mainHand = itemz[];
		}
		else if (menuCon.characterSelected.armor.itemTag == "armor") // item tag == armor
		{
			//   menuCon.characterSelected.armor = itemz[];
		}
		else if (menuCon.characterSelected.accessory.itemTag == "accessory") // item tag == accessory
		{
			//   menuCon.characterSelected.accessory = itemz[];
		}
		else
		{
			Debug.Log("You can't equip that item dingus!");
		}
		// else
		// Display: "You can't equip that class of weapon."
	}







	public void MoveItem () // Maybe wait off on this
	{
		// Move from one sell to another;
	}

	public void DropItem () // Maybe wait off on this
	{
		// Delete item from the GameObject Array;
	}
}
