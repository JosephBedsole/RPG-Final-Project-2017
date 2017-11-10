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
	public Transform shopMenu;
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
		
	}


	// ------- Forward Navigation -------

	void DisplayShop ()
	{
		inShopMenu = true;
		shopMenu.gameObject.SetActive(true);
	}

	void DisplayPInv ()   // This is the Player Inventory Display Function
	{
		inBuyMenu = true;
		shopMenu.gameObject.SetActive(false);
		sellMenu.gameObject.SetActive(true);
	}

	void DisplayShopInv ()
	{
		inSellMenu = true;
		shopMenu.gameObject.SetActive(false);
		buyMenu.gameObject.SetActive(true);
	}


	// ------- Backward Navigation -------

	void CloseShop ()
	{
		inShopMenu = false;
		shopMenu.gameObject.SetActive(false);
	}

	void ClosePInv ()   // This is the Player Inventory Display Function
	{
		inBuyMenu = false;
		sellMenu.gameObject.SetActive(false);
	}

	void CloseShopInv ()
	{
		inSellMenu = false;
		buyMenu.gameObject.SetActive(false);
	}


	// ------- Functions -------

	void BuyItem ()
	{
		// Subtract gold amount
		if (PlayerInventory.instance.gold >= itemCost)
		{
			// subtract gold
			// add item to the player inventory
		}
		else if (PlayerInventory.instance.gold < itemCost)
		{
			// gray out the buy button
			// display: "You don't have enough gold."
		}
		else
		{
			Debug.Log("Something went wrong.");
		}
	}

	void SellItem ()
	{
		// display: "Are you sure?" YES || NO 
		if (true)
		{
			// remove item from the player inventory
			// add the sell gold to the player inventory
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
