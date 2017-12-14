using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "RPG/Player")]
public class PlayerCharacter : ScriptableObject {

	//Base
	public string characterName = "";
	public Job job;
	public int LVL = 1;
	public int baseHP = 1;
	public int currHP = 1;
	public int maxHP = 1;
	public int baseMP = 1;
	public int currMP = 1;
	public int maxMP = 1;
	public int baseGuts = 1;
	public int currGuts = 1;
	public int maxGuts = 1;
	public int baseSpirit = 1;
	public int currSpirit = 1;
	public int maxSpirit = 1;
	public int baseCT = 1;
	public int currCT = 1;
	public int maxCT = 1;

	public int XP = 0;

	//Combat
	public int pAttackStrength = 5;

	//Status
	public bool canAct = false;
	public bool isKO = false;

	//Items
	public Items Weapon;
	public Items Armor;
	public Items Accessory;
	

}
