﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "inventory/Items", order = 1)]
public class Items : ScriptableObject {

	public string itemName;

	public string itemTag;

	public Image uiSprite;       // For the Inventory screen;

	[Header("Nerd Stuff")]
	public Image damageTypeSprite;
	public string damageType;
	public int minDamage;
	public int maxDamage;
	public int speed;
	public int crit;
	public int health;
}
