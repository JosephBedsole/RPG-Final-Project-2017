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

	public Items item;




	[Header("Item Visualization")]
	public Transform[] inventorySlots; 
	// List of characterInventorySlots Arrays

	void Start () 
	{
		item = items[1];
	}
	
	void Update () 
	{

		// if (Input.GetButton("Jump"))
		// {
		// 	TempCharacter.instance.mainHand = weapons[0];
		// 	// Disable the menu
		// 	// Display sub menu with Equip / Move / Drop
		// 	if (Input.GetButton("Jump"))
		// 	{
		// 		// Use the event system to call one of the functions
		// 		// Hide the sub menu
		// 		//Enable the menu
		// 	}
		// 	else if (Input.GetButton("Fire1"))
		// 	{
		// 		// Hide the sub menu
		// 		// Enable the menu
		// 	}
		// }
		// else if (Input.GetButton("Fire1"))
		// {
		// 	// Close Inventory
		// }
	}

	void AddItem ()   // This will Add an Item from other sources to the PlayerInventory
	{
		// Call this when buying an item from the shop, opening a chest, or looting an item from battle

		// if (isInShop)    then you should have some sort of exchange of gold
	}

	public void EquipItem () // This will equip an item to the selected character
	{
		// if (item class == character class)
		// Move to a specified character inventory;
		if (true) // item tag == weapon
		{
			// Move the currently equipped item to the inventory
			// Move the Item to the character's mainHand slot
		}
		else if (true) // item tag == armor
		{

		}
		else if (true) // item tag == accessory
		{

		}
		else
		{
			// Display: "You can't equip that dingus."
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
