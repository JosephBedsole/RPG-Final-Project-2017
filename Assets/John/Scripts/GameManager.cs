using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[HideInInspector]
	public float battleChance = 0.0f;
	public float battleRollCheck = 70.0f;

	public List<PlayerCharacter> pcList = new List<PlayerCharacter>();
	public List<EnemyCharacter> enemyList = new List<EnemyCharacter>();

	bool battleCheck = false;

	void Awake(){
		if (instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}
	}

	void Start(){
		InitiatePlayerAttributes();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.B)){
			StartBattle();
		}
		Mathf.Clamp(battleChance, 0.0f, 50.0f);
	}


	public PlayerCharacter GetPC(string name){
		PlayerCharacter tempPC = null;

		for (int i = 0; i < pcList.Count; i++){
			if (pcList[i].name == name){
				tempPC = pcList[i];
				return tempPC;
			}
		}

		Debug.Log("Did not find PC");
		return tempPC;
	}

	public void StartBattle(){
		SceneManager.LoadScene("BattleScene");
	}

	public void RandomEncounterRoll(){
		battleCheck = true;
		float battleRoll = Random.Range(0.0f, 50.0f);
		if(battleRoll + battleChance > battleRollCheck){
			StartBattle();
		}
		battleCheck = false;
	}

	void InitiatePlayerAttributes(){
		for(int i = 0; i < 4; i++){
			PlayerCharacter tPC = pcList[i];
			tPC.maxHP = tPC.baseHP + tPC.Weapon.health + tPC.Armor.health + tPC.Accessory.health;	
			tPC.maxGuts = tPC.baseGuts;
			tPC.pAttackStrength = tPC.pAttackStrength + tPC.Weapon.maxDamage + tPC.Armor.maxDamage + tPC.Accessory.maxDamage;
		}
	}
}
