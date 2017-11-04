using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvasController : MonoBehaviour {

	public GameObject pointer;

	[HideInInspector]
	public enum Selection {none, pc, action, enemy}
	Selection selection = Selection.none;

	GameObject actionPanel;
	GameObject pcPanels;
	GameObject enemyPanels;
	GameObject enemySprites;
	

	void OnEnable(){
		actionPanel = GameObject.Find("ActionPanel");
		actionPanel.SetActive(false);
	}

	public void ButtonClicked(string s){
		Debug.Log(s);
	}

	public void PCClick(){
		if(selection == Selection.none){
			actionPanel.SetActive(true);
			selection = Selection.pc;
			Debug.Log("Player selected, choose action");
		}
		else if(selection == Selection.action){
			selection = Selection.none;
			actionPanel.SetActive(false);
			Debug.Log("Performing actiion on target pc");
		}
		
	}

	public void ActionClick(){
		if(selection == Selection.pc){
			selection = Selection.action;
			Debug.Log("Action Selected, choose target");
		}	
			
	}

	public void EnemyClick(){
		if(selection == Selection.action){
			selection = Selection.none;
			actionPanel.SetActive(false);
			Debug.Log("Performing action on target enemy");
		}
	}


}
