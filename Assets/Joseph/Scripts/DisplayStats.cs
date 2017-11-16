using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour {

	// Alternative of the DisplayInventoryStats in DisplayInventory
	// Put on Button and use it in an onClick event;

	public Items item;

	[Header("Inventory Item Stats")]
	public Image iImage;
	public Text iEquipName;
	public Text iDamage;
	public Text iSpeed;
	public Text iCrit;
	public Text iHealth;


	public void DisplayInventoryStats ()
	{
		iImage.sprite = item.uiSprite.sprite;
		iEquipName.text = item.name;
		iDamage.text = "Damage: " + item.minDamage + " - " + item.maxDamage;
		iSpeed.text = "Speed: " + item.speed;
		iCrit.text = "Crit: " + item.crit;
		iHealth.text = "Health: " + item.health;
	}



}
