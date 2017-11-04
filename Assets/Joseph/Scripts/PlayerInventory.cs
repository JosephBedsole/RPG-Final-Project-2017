using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {


	[Header("Inventory Items")]
	public Items[] weapons;
	public Items[] armor;
	public Items[] accessories;
	public Items[] consumables;


	[Header("Item Visualization")]
	public Transform[] inventorySlots; 
	// List of characterInventorySlots Arrays

	void Start () 
	{
		
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

	public void Action ()
	{
		// Do you want to Equip || Move || Cancel;
	}

	public void SelectCharacter ()
	{
		// Upon pressing something or doing something else 
		// Set the Character selected to the character selected
	}

	void AddItem ()
	{
		// Call this when buying an item from the shop, opening a chest, or looting an item from battle
	}

	public void EquipItem ()
	{
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
