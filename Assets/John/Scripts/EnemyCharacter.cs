using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Enemy", menuName = "RPG/Enemy") ]
public class EnemyCharacter : ScriptableObject {

	//Base
	public string characterName = "";
	public int LVL = 1;
	public int baseHP = 0;
	public int currHP = 0;
	public int maxHP = 0;
	public int baseMP = 0;
	public int currMP = 0;
	public int maxMP = 0;
	public int baseGuts = 0;
	public int currGuts = 0;
	public int maxGuts = 0;
	public int baseSpirit = 0;
	public int currSpirit = 0;
	public int maxSpirit = 0;
	public int baseCT = 0;
	public int currCT = 0;
	public int maxCT = 0;
	
	public Sprite enemySprite;
	
	//Combat
	public int pAttackStrength = 5;

	//Status
	public bool canAct = false; 
	public bool isKO = false;
}
