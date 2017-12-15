using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public static MenuController instance;


	[Header("Menus")]
	public Transform taskMenu;
	public Transform menu;
	public Transform menuSelect;
	public Transform inventoryMenu;
	public Transform optionsMenu;

	[Header("Party Menus")]
	public Transform partyMenu;
	public Transform equipmentMenu;
	public Transform statsMenu;
	public Transform equipItemMenu;

	[Header("Prompts")]
	public Transform quitPrompt;
	public Transform chestPrompt;

    public TempCharacter characterSelected; // How will this be set to null again?

    [Header("Menu bools")]
	public bool waitTime;
	public bool inMenuSelect;
	public bool inSecondTierMenus;
	public bool inEquipmentMenu;
	public bool inEquipItemMenu;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void Update ()
	{
		// View menu after a key is pressed
		if (Input.GetKey(KeyCode.E) && (!ShopController.instance.inShopMenu && !inMenuSelect && !inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu) && !waitTime)
		{
			OpenMenu();
			StartCoroutine("BufferTime");
		}



		if (Input.GetKey(KeyCode.Escape) && (inMenuSelect && !inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu) && !waitTime) // Exit during equipping stage?
		{
			CloseMenu();
			StartCoroutine("BufferTime");
		}
        else if (Input.GetKey(KeyCode.Escape) && (inSecondTierMenus && !inEquipmentMenu && !inEquipItemMenu) && !waitTime)
		{
			ReturnToMenuSelect();
			StartCoroutine("BufferTime");
		}
		else if (Input.GetKey(KeyCode.Escape) && (inEquipmentMenu && !inEquipItemMenu) && !waitTime)
		{
			ReturnToPartyMenu();
			StartCoroutine("BufferTime");
		}
		else if (Input.GetKey(KeyCode.Escape) && inEquipItemMenu && !waitTime)
		{
			ReturnToEquipmentMenu();
			StartCoroutine("BufferTime");
		}

	}


	// ------- Forward Navigation -------

	public void OpenMenu ()
	{
		inMenuSelect = true;
		
		taskMenu.gameObject.SetActive(false);
		menu.gameObject.SetActive(true);
	}


	public void ViewInventory ()
	{
		inSecondTierMenus = true;

		inventoryMenu.gameObject.SetActive(true);
		menuSelect.gameObject.SetActive(false);
	}

	public void ViewOptions ()
	{
		inSecondTierMenus = true;

		optionsMenu.gameObject.SetActive(true);
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

	public void DisplayInventoryToEquip ()
	{
		inEquipItemMenu = true;

		equipItemMenu.gameObject.SetActive(true);
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

		taskMenu.gameObject.SetActive(true);
		menu.gameObject.SetActive(false);
	}

	public void ReturnToMenuSelect ()
	{
		inSecondTierMenus = false;

		inventoryMenu.gameObject.SetActive(false);
		partyMenu.gameObject.SetActive(false);
		optionsMenu.gameObject.SetActive(false);
		menuSelect.gameObject.SetActive(true);
	}

	public void ReturnToPartyMenu ()
	{
		inEquipmentMenu = false;

		partyMenu.gameObject.SetActive(true);
		equipmentMenu.gameObject.SetActive(false);
		statsMenu.gameObject.SetActive(false);
		equipItemMenu.gameObject.SetActive(false);
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

	IEnumerator BufferTime ()
	{
		waitTime = true;
		yield return new WaitForSeconds(0.1f);
		waitTime = false;
	}



}
