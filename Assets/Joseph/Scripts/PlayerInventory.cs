using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject[] armor;
	public GameObject[] accessories;
	public GameObject[] consumables;

	void Start () 
	{

	}
	
	void Update () 
	{

		if (Input.GetButton("Jump"))
		{
			// Disable the menu
			// Display sub menu with Equip / Move / Drop
			if (Input.GetButton("Jump"))
			{
				// Use the event system to call one of the functions
				// Hide the sub menu
				//Enable the menu
			}
			else if (Input.GetButton("Fire1"))
			{
				// Hide the sub menu
				// Enable the menu
			}
		}
		else if (Input.GetButton("Fire1"))
		{
			// Close Inventory
		}
	}

	void EquipItem ()
	{
		// Move to a specified character inventory;
	}

	void MoveItem ()
	{
		// Move from one sell to another;
	}

	void DropItem ()
	{
		// Delete item from the GameObject Array;
	}
}
