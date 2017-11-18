using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
	public static ShopController instance;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public int itemCost;

	[Header("Menus")]
	public Transform shopButton;
	public Transform shopMenu;
	public Transform shopSelect;
	public Transform buyMenu;
	public Transform sellMenu;

	[Header("Nav Bools")]
	public bool nearShop;
	public bool inShopMenu;
	public bool inBuyMenu;
	public bool inSellMenu;

	public Items[] shopItems;

	public List<GameObject[]> itemSets = new List<GameObject[]>();

	void Start () 
	{
		
	}

	void Update () 
	{
		DisplayShopButton();
	}


	// ------- Forward Navigation -------


	public void DisplayShopButton ()
	{
		if (nearShop)
		{
			shopButton.gameObject.SetActive(true);
		}
		else
		{
			shopButton.gameObject.SetActive(false);
		}
	}

	public void DisplayShop ()
	{
		inShopMenu = true;
		shopMenu.gameObject.SetActive(true);
	}

	public void DisplaySellMenu ()   // This is the Player Inventory Display Function
	{
		inBuyMenu = true;
		shopSelect.gameObject.SetActive(false);
		sellMenu.gameObject.SetActive(true);
	}

	public void DisplayBuyMenu ()
	{
		inSellMenu = true;
		shopSelect.gameObject.SetActive(false);
		buyMenu.gameObject.SetActive(true);
	}


	// ------- Backward Navigation -------

	public void CloseShop ()
	{
		inShopMenu = false;
		shopMenu.gameObject.SetActive(false);
	}

	public void ClosePlayerInv ()   // This is the Player Inventory Display Function
	{
		inBuyMenu = false;
		shopSelect.gameObject.SetActive(true);
		sellMenu.gameObject.SetActive(false);
	}

	public void CloseShopInv ()
	{
		inSellMenu = false;
		shopSelect.gameObject.SetActive(true);
		buyMenu.gameObject.SetActive(false);
	}


	// ------- Functions -------



	// Directly Code BuyItem with a scriptable object as a perameter like the DisplayInventoryStats(Items item) from the DisplayInventoryScript;

	public void BuyItem (Items item) 
	{
		// Subtract gold amount
		if (PlayerInventory.instance.gold >= itemCost)
		{
			PlayerInventory.instance.gold -= item.buyValue;
			PlayerInventory.instance.AddItem(item); // add item to the player inventory;
		}
		else if (PlayerInventory.instance.gold < itemCost)
		{
			// gray out the buy button
			// display: "You don't have enough gold."
			Debug.Log("You don't have enough gold!");
		}
		else
		{
			Debug.Log("Something went wrong.");
		}
	}

	public void SellItem (Items item) 
	{
		// display: "Are you sure?" YES || NO 
		if (true)
		{
			// remove item from the player inventory
			PlayerInventory.instance.gold += item.sellValue;
		}
		else
		{
			// nothing
		}
	}

	void ChangeItemSet()
	{
		// Based on character progression load a different set of items in the shop;
	}
}
