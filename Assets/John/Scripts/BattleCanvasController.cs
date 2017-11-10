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
	GameObject enemyPanels;
	GameObject enemySprites;	

	int actingPlayer;

	public List<GameObject> pcPanelList = new List<GameObject>();
	List<Image> ctList = new List<Image>(); // TODO: get cts onEnable instead of dragndrop
	List<float> ctListSpeed = new List<float>();

	public delegate void PlayerActed(int playerNum);
	public static event PlayerActed playerActed = delegate{};
	

	void OnEnable(){
		if (instance == null) instance = this; 
		else Destroy(gameObject); 

		actionPanel = GameObject.Find("ActionPanel");
		actionPanel.SetActive(false);
		ctList.Add(ct1);
		ctList.Add(ct2);
		ctList.Add(ct3);
		ctList.Add(ct4);

		pcPanelList.Add(GameObject.Find("pc1"));
		pcPanelList.Add(GameObject.Find("pc2"));
		pcPanelList.Add(GameObject.Find("pc3"));
		pcPanelList.Add(GameObject.Find("pc4"));
	}

	void Start(){
		SetPlayerStatsUI();
	}

	void Update(){
		for(int i = 0; i < 4; i++){
			if(BattleManager.instance.pcSheets[i].canAct == false)
				pcPanelList[i].GetComponent<Image>().color = new Color(1,1,1,0.1f);
			else
				pcPanelList[i].GetComponent<Image>().color = new Color(1,1,1,1.0f);
		}
	}

	public void ButtonClicked(string s){
		Debug.Log(s);
	}

	public void PCClick(int playerNum){
		if(selection == Selection.none){
			actionPanel.SetActive(true);
			selection = Selection.pc;
			actingPlayer = playerNum;
			Debug.Log("Player selected, choose action");
		}
		else if(selection == Selection.action){
			selection = Selection.none;
			actionPanel.SetActive(false);
			Debug.Log("Performing action on target pc");
			playerActed(actingPlayer);
			actingPlayer = 0;
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
			playerActed(actingPlayer);
			actingPlayer = 0;
		}
	}

	public Image GetCTImage(Image ct){
		return ctList[ctList.IndexOf(ct)];
	}

	public void SetCTImageFill(Image ct){
		ctList[ctList.IndexOf(ct)].fillAmount = 1;
	}

	 void SetPlayerStatsUI(){
       for (int i = 0; i < pcPanelList.Count; i++){
		   GameObject currentPanel = pcPanelList[i];

		   GameObject tempName = GetPlayerAttributeUI(currentPanel, "Name");
		   tempName.GetComponent<Text>().text = GameManager.instance.pcList[i].characterName;
           GameObject tempLevel = GetPlayerAttributeUI(currentPanel, "Level");
		   tempLevel.GetComponent<Text>().text = "LVL" + GameManager.instance.pcList[i].LVL.ToString();
		   GameObject tempHP = GetPlayerAttributeUI(currentPanel, "HP");
		   tempHP.GetComponent<Text>().text = "HP" + GameManager.instance.pcList[i].HP.ToString();
		   GameObject tempMP = GetPlayerAttributeUI(currentPanel, "MP");
		   tempMP.GetComponent<Text>().text = "MP" + GameManager.instance.pcList[i].MP.ToString();
       }
    }

	GameObject GetPlayerAttributeUI(GameObject playerPanel, string attr){
		return playerPanel.transform.Find(attr).gameObject;
	}

}
