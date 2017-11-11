﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "RPG/Player")]
public class PlayerCharacter : ScriptableObject {

	public string characterName = "";
	public int LVL = 1;
	public int HP = 0;
	public int MP = 0;
	public int Guts = 0;
	public int Spirit = 0;
	public int CT = 10;
	public bool canAct = false;



	public int pAttackStrength = 5;



}
