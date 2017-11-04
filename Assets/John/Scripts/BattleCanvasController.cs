using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvasController : MonoBehaviour {

	public static BattleCanvasController instance = null;

	public GameObject pointer;
	public Image ct1;
	public Image ct2;
	public Image ct3;
	public Image ct4;
	[HideInInspector]
	public float ct1Speed;
	[HideInInspector]
	public float ct2Speed;
	[HideInInspector]
	public float ct3Speed;
	[HideInInspector]
	public float ct4Speed;


	[HideInInspector]
	public enum Selection {none, pc, action, enemy}
	Selection selection = Selection.none;

	GameObject actionPanel;
	GameObject pcPanels;
	GameObject enemyPanels;
	GameObject enemySprites;

	List<Image> ctList = new List<Image>(); // TODO: get cts onEnable instead of dragndrop
	List<float> ctListSpeed = new List<float>();
	

	void OnEnable(){
		if (instance == null) instance = this; 
		else Destroy(gameObject); 

		actionPanel = GameObject.Find("ActionPanel");
		actionPanel.SetActive(false);
		ctList.Add(ct1);
		ctList.Add(ct2);
		ctList.Add(ct3);
		ctList.Add(ct4);
		
		for (int i = 0; i < ctList.Count; i++){
			ctList[i].fillAmount = 0.3f;
		}

		SetCTImageFill(GetCTImage(ct1));
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

	public Image GetCTImage(Image ct){
		return ctList[ctList.IndexOf(ct)];
	}

	public void SetCTImageFill(Image ct){
		ctList[ctList.IndexOf(ct)].fillAmount = 1;
	}

}
