using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "inventory/Items", order = 1)]
public class Items : ScriptableObject {

	public string itemName;
	public string itemTag;
	public int buyValue;
	public int sellValue;
	public Image uiSprite;       // For the Inventory screen;

	[Header("Stat Stuff")]
	public Image damageTypeSprite;
	public string damageType;
	public int minDamage;
	public int maxDamage;
	public int attackPower;
	public int speed; // not used right now?
	public int crit; // not used right now?
	public int health; 
	public int ct;
	public int guts;
	public int spirit;

}
