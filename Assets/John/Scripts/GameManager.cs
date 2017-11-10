using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public List<PlayerCharacter> pcList = new List<PlayerCharacter>();

	void Awake(){
		if (instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}
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
}
