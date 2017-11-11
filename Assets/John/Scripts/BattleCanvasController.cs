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
	public enum Action {none, attack, skill, item}
	Action action = Action.none;

	GameObject actionPanel;
	GameObject enemyPanels;
	GameObject enemySprites;	

	int actingPlayer;

	public List<GameObject> pcPanelList = new List<GameObject>();
	public List<GameObject> enemyPanelList = new List<GameObject>();
	public List<GameObject> actionPanelList = new List<GameObject>();
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

		enemyPanelList.Add(GameObject.Find("EnemyPanel1"));
		enemyPanelList.Add(GameObject.Find("EnemyPanel2"));
		enemyPanelList.Add(GameObject.Find("EnemyPanel3"));
		enemyPanelList.Add(GameObject.Find("EnemyPanel4"));

		actionPanelList.Add(GameObject.Find("Attack"));
		actionPanelList.Add(GameObject.Find("Skill"));
		actionPanelList.Add(GameObject.Find("Item"));
	}

	void Start(){
		SetPlayerStatsUI();
		SetEnemyStatsUI();
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
		if(BattleManager.instance.CanPCAct(playerNum) && selection == Selection.none){
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
			actingPlayer = -1;
		}
	}

	public void ActionClick(int actionNum){
		if(selection == Selection.pc){
			switch(actionNum){
				case(1):
					selection = Selection.action;
					action = Action.attack;
					Debug.Log("Action Selected, choose target");
				break;
				case(2):
					selection = Selection.action;
					action = Action.skill;
					Debug.Log("Action Selected, choose target");
				break;
				case(3):
					selection = Selection.action;
					action = Action.item;
					Debug.Log("Action Selected, choose target");			
				break;
				default:
					Debug.Log("Action Error");
				break;
			}
		}	
			
	}

	public void EnemyClick(int enemyNum){
		if(selection == Selection.action){
			switch(action){
				case(Action.attack):
					AttackEnemy(enemyNum, actingPlayer);
				
					actingPlayer = -1;
				break;
				case(Action.skill):
				break;
				case(Action.item):
				break;
			}

			selection = Selection.none;
			actionPanel.SetActive(false);
			Debug.Log("Performing action on target enemy");
			playerActed(actingPlayer);
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
		   tempLevel.GetComponent<Text>().text = "LVL: " + GameManager.instance.pcList[i].LVL.ToString();
		   GameObject tempHP = GetPlayerAttributeUI(currentPanel, "HP");
		   tempHP.GetComponent<Text>().text = "HP" + GameManager.instance.pcList[i].HP.ToString();
		   GameObject tempMP = GetPlayerAttributeUI(currentPanel, "MP");
		   tempMP.GetComponent<Text>().text = "MP" + GameManager.instance.pcList[i].MP.ToString();
       }
    }

	GameObject GetPlayerAttributeUI(GameObject playerPanel, string attr){
		return playerPanel.transform.Find(attr).gameObject;
	}

	void SetEnemyStatsUI(){
		for(int i = 0; i < enemyPanelList.Count; i++){
			GameObject currentPanel = enemyPanelList[i];

			GameObject tempName = GetEnemyAttributeUI(currentPanel, "Name");
			tempName.GetComponent<Text>().text = GameManager.instance.enemyList[i].characterName;
			GameObject tempLevel = GetEnemyAttributeUI(currentPanel, "Level");
			tempLevel.GetComponent<Text>().text = "Level: " + GameManager.instance.enemyList[i].LVL.ToString();
			GameObject tempHP = GetEnemyAttributeUI(currentPanel, "HP");
			tempHP.GetComponent<Text>().text = "HP: " + GameManager.instance.enemyList[i].HP.ToString();
			GameObject tempMP = GetEnemyAttributeUI(currentPanel, "MP");
			tempMP.GetComponent<Text>().text = "MP: " + GameManager.instance.enemyList[i].MP.ToString();
		}
	}

	GameObject GetEnemyAttributeUI(GameObject enemyPanel, string attr){
		return enemyPanel.transform.Find(attr).gameObject;
	}

	void AttackEnemy(int target, int pc){
		GameManager.instance.enemyList[target].HP -= GameManager.instance.pcList[pc].pAttackStrength;
		SetEnemyStatsUI();
	}

}
