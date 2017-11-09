using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	[Header("Menus")]
	public Transform menu;
	public Transform menuSelect;
	public Transform inventoryMenu;

	[Header("Party Menus")]
	public Transform partyMenu;
	public Transform equipmentMenu;
	public Transform statsMenu;
	public Transform equipItemMenu;

	[Header("Prompts")]
	public Transform quitPrompt;

    public TempCharacter characterSelected; // How will this be set to null again?

    [Header("Menu bools")]
	public bool inMenuSelect;
	public bool inSecondTierMenus;
	public bool inEquipmentMenu;
	public bool inEquipItemMenu;



	void Update ()
	{
		// View menu after a key is pressed
		if (Input.GetKey(KeyCode.Escape) && (!inMenuSelect && !inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu))
		{
			OpenMenu();
		}
		else if (Input.GetKey(KeyCode.Escape) && (inMenuSelect && !inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu)) // Exit during equipping stage?
		{
			CloseMenu();
		}
        else if (Input.GetKey(KeyCode.Escape) && (inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu))
		{
			ReturnToMenuSelect();
		}
		else if (Input.GetKey(KeyCode.Escape) && (inEquipmentMenu && !inEquipItemMenu))
		{
			ReturnToPartyMenu();
		}
		else if (Input.GetKey(KeyCode.Escape) && inEquipItemMenu)
		{
			ReturnToEquipmentMenu();
		}

	}


	// ------- Forward Navigation -------

	public void OpenMenu ()
	{
		inMenuSelect = true;
		
		menu.gameObject.SetActive(true);
	}


	public void ViewInventory ()
	{
		inSecondTierMenus = true;

		inventoryMenu.gameObject.SetActive(true);
		menuSelect.gameObject.SetActive(false);
	}

	public void ViewParty ()
	{
		inSecondTierMenus = true;

		partyMenu.gameObject.SetActive(true);
		menuSelect.gameObject.SetActive(false);
	}

	public void DisplayEquipment ()
	{
		inEquipmentMenu = true;

		equipmentMenu.gameObject.SetActive(true);
		statsMenu.gameObject.SetActive(true);		
	}

	public void DisplayEquipItemMenu ()
	{
		inEquipItemMenu = true;

		equipItemMenu.gameObject.SetActive(true);
		equipmentMenu.gameObject.SetActive(false);
		statsMenu.gameObject.SetActive(false);		
	}
	

	// ------- Backward Navigation -------

	public void Quit ()
	{
		// Prompt: "Are you sure?" Display: YES || NO
		// Go back to the main menu
	}

	public void CloseMenu ()
	{
		inMenuSelect = false;

		menu.gameObject.SetActive(false);
	}

	public void ReturnToMenuSelect ()
	{
		inSecondTierMenus = false;

		inventoryMenu.gameObject.SetActive(false);
		partyMenu.gameObject.SetActive(false);
		menuSelect.gameObject.SetActive(true);
	}

	public void ReturnToPartyMenu ()
	{
		inEquipmentMenu = false;

		partyMenu.gameObject.SetActive(true);
		equipmentMenu.gameObject.SetActive(false);
		statsMenu.gameObject.SetActive(false);
	}

	public void ReturnToEquipmentMenu ()
	{
		inEquipItemMenu = true;

		equipItemMenu.gameObject.SetActive(false);
		equipmentMenu.gameObject.SetActive(true);
		statsMenu.gameObject.SetActive(true);
	}


	// ------- Party Menu -----------------------------------------------------------------------------------------------


	[Header("Character Equipment")]
	public Items mainHand;
	public Items armor;
	public Items acc;



	[Header("Current Equipment Stats")]
	public Image cImage;
	public Text cEquipName;
	public Text cDamage;
	public Text cSpeed;
	public Text cCrit;
	public Text cHealth;

	[Header("Selected Equipment Stats")]
	public Image sImage;
	public Text sEquipName;
	public Text sDamage;
	public Text sSpeed;
	public Text sCrit;
	public Text sHealth;

    
	public void SelectCharacter (TempCharacter character)   // This will get the character's name and class (Lvl later)
	{
		characterSelected = character;

        mainHand = characterSelected.mainHand;
		armor = characterSelected.armor;
		acc = characterSelected.accessory;
	}


	public void DisplayStats (string itemType) // Items item
	{
		// Rmv This later
		// cImage.sprite = PlayerInventory.instance.item.uiSprite.sprite;
		// cEquipName.text = PlayerInventory.instance.item.name;
		// cDamage.text = "Damage: " + PlayerInventory.instance.item.minDamage + " - " + PlayerInventory.instance.item.maxDamage;
		// cSpeed.text = "Speed: " + PlayerInventory.instance.item.speed;
		// cCrit.text = "Crit: " + PlayerInventory.instance.item.crit;
		// cHealth.text = "Health: " + PlayerInventory.instance.item.health;

		if (itemType == "weapon")
		{
			cImage.sprite = mainHand.uiSprite.sprite;
			cEquipName.text = mainHand.name;
			cDamage.text = "Damage: " + mainHand.minDamage + " - " + mainHand.maxDamage;
			cSpeed.text = "Speed: " + mainHand.speed;
			cCrit.text = "Crit: " + mainHand.crit;
			cHealth.text = "Health: " + mainHand.health;
		}

		else if (itemType == "armor")
		{
			cImage.sprite = armor.uiSprite.sprite;
			cEquipName.text = armor.name;
			cDamage.text = "Damage: " + armor.minDamage + " - " + armor.maxDamage;
			cSpeed.text = "Speed: " + armor.speed;
			cCrit.text = "Crit: " + armor.crit;
			cHealth.text = "Health: " + armor.health;
		}

		else if (itemType == "acc")
		{
			cImage.sprite = acc.uiSprite.sprite;
			cEquipName.text = acc.name;
			cDamage.text = "Damage: " + acc.minDamage + " - " + acc.maxDamage;
			cSpeed.text = "Speed: " + acc.speed;
			cCrit.text = "Crit: " + acc.crit;
			cHealth.text = "Health: " + acc.health;
		}

		else
		{
			Debug.Log("You can't do that.");
		}

		// Sets the scriptable object's stuff to the menu's stuff...  stuuuuuuuuuff
	}

	public void EquipItemMenu ()
	{
		// Current Item Stats from current scriptable object
		// Player Inventory
		// Selected Item Stats from selected scriptable object
		// Asks if you are certain about your choice
		// Runs The EquipItem() function from the PlayerInventory script
		// Disables the sanity check function and displays "Item Equipped" || "You Can't Equip That"
	}



}
