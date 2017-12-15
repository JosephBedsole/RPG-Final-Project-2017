using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[HideInInspector]
	public float battleChance = 0.0f;
	public float battleRollCheck = 70.0f;
	public string townSceneName;
	public string dungeonSceneName;
	public float townBattleChance = 200;
	public float dungeonBattleChannge = 65;

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

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start(){
		InitiatePlayerAttributes();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.B)){
			StartBattle();
		}
		Mathf.Clamp(battleChance, 0.0f, 50.0f);
		CompareCurrandMaxAttributes();
		CompareCurrToZero();
		CompareCurrToZeroEnemy();
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
			tPC.maxGuts = tPC.baseGuts + tPC.Weapon.guts + tPC.Armor.health + tPC.Accessory.health;
			tPC.pAttackStrength = tPC.pAttackStrength + tPC.Weapon.attackPower + tPC.Armor.attackPower + tPC.Accessory.attackPower;
			tPC.currCT = tPC.currCT + tPC.Weapon.ct + tPC.Armor.ct + tPC.Accessory.ct;
		}
	}

	void CompareCurrandMaxAttributes(){
		for(int i = 0; i < 4; i++){
			PlayerCharacter tPC = pcList[i];
			if(tPC.currHP > tPC.maxHP){
				tPC.currHP = tPC.maxHP;
				BattleCanvasController.instance.SetPlayerStatsUI();
			}
			else if(tPC.currMP > tPC.maxMP){
				tPC.currMP = tPC.maxHP;
				BattleCanvasController.instance.SetPlayerStatsUI();
			}
		}

		
	}

	void CompareCurrToZero(){
		for(int i = 0; i < 4; i++){
			PlayerCharacter tPC = pcList[i];
			if(tPC.currHP < 0){
				tPC.currHP = 0;
				BattleCanvasController.instance.SetPlayerStatsUI();
			}
			else if(tPC.currMP < 0){
				tPC.currMP = 0;
				BattleCanvasController.instance.SetPlayerStatsUI();
			}
		}
	}

	void CompareCurrToZeroEnemy(){
		for(int i = 0; i < 4; i++){
			EnemyCharacter tEnemy = enemyList[i];
			if(tEnemy.currHP < 0){
				tEnemy.currHP = 0;
				BattleCanvasController.instance.SetEnemyStatsUI();
			}
			else if(tEnemy.currMP < 0){
				tEnemy.currMP = 0;
				BattleCanvasController.instance.SetEnemyStatsUI();
			}
		}	
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log("Scene Loaded");
		if(scene.name == dungeonSceneName){
			battleRollCheck = dungeonBattleChannge;
		}
		else if(scene.name == townSceneName){
			battleRollCheck = townBattleChance; //No encounters 
		}
	}


}
