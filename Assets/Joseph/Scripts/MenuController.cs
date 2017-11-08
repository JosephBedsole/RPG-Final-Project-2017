using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	[Header("Menus")]
	public Transform menu;
	public Transform menuSelect;
	public Transform inventoryMenu;
	
	[Header("Party Menus")]
	public Transform partyMenu;
	public Transform equipMenu;


	void Update ()
	{
		// View menu after a key is pressed
		if (Input.GetKey(KeyCode.Escape))
		{
			OpenMenu();
		}
		else if (Input.GetKey(KeyCode.Escape)) // Exit during equipping stage?
		{
			CloseMenu();
		}
	}

	public void OpenMenu ()
	{
		menu.gameObject.SetActive(true);
	}

	public void CloseMenu ()
	{
		menu.gameObject.SetActive(false);
	}

	public void ViewInventory ()
	{
		inventoryMenu.gameObject.SetActive(true);
		menuSelect.gameObject.SetActive(false);
	}

	public void ViewParty ()
	{
		partyMenu.gameObject.SetActive(true);
		menuSelect.gameObject.SetActive(false);
	}

	public void Quit ()
	{
		// Prompt: "Are you sure?" Display: YES || NO
		// Go back to the main menu
	}

	public void ReturnToMenuSelect ()
	{
		inventoryMenu.gameObject.SetActive(false);
		partyMenu.gameObject.SetActive(false);
		menuSelect.gameObject.SetActive(true);
	}


	// ------- Party Menu -------


	public void DisplayEquipment ()
	{
		// Display equipment and stats
		// Sets the scriptable object's stuff to the menu's stuff...  stuuuuuuuuuff
	}

	public void EquipItemMenu ()
	{
		// Current Item Stats from current scriptable object
		// Player Inventory
		// Selected Item Stats from selected scriptable object
		// Runs The EquipItem() function from the PlayerInventory script
	}



}
