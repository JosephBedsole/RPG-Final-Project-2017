using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName = "inventory/Items", order = 1)]
public class Items : ScriptableObject {

	public string itemName;

	public string itemTag;

	public Sprite combatSprite;   // For the fighting scenes;

	public Sprite uiSprite;       // For the Inventory screen;

	[Header("Nerd Stuff")]
	public Sprite damageTypeSprite;
	public string damageType;
	public int minDamage;
	public int maxDamage;
	public int speed;
	public int critChance;
	public int health;
	public int armor;
	public int magicResist;

}
