using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public static BattleManager instance = null;

    public float startCT = 0.0f;
    public float debugCTRate = 0.05f;

    float MAXCT = 1.0f;
    float MINCT = 0.0f;
    public float BASE_CT_CHARGE = 0.00001f;

    List<GameObject> pcPanelList = new List<GameObject>();
    List<GameObject> enemyPanelList = new List<GameObject>();
    List<PlayerCharacter> _pcSheets = new List<PlayerCharacter>();
    public List<PlayerCharacter> pcSheets {
        get{return _pcSheets;}
    }
    List<EnemyCharacter> _enemySheets = new List<EnemyCharacter>();
    public List<EnemyCharacter> enemySheets {
        get{return _enemySheets;}
    }
    
    void Awake(){
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    void OnEnable(){
        BattleCanvasController.playerActed += ResetChargeTime;
    }

    void OnDisable(){
        BattleCanvasController.playerActed -= ResetChargeTime;
    }

    void Start(){
        pcPanelList.AddRange(BattleCanvasController.instance.pcPanelList);
        enemyPanelList.AddRange(BattleCanvasController.instance.enemyPanelList);
        pcSheets.AddRange(GameManager.instance.pcList);
        enemySheets.AddRange(GameManager.instance.enemyList);
        SetPartyAct(false);
        SetStartChargeTime(0.0f);

    }

    void Update(){
        UpdateCT();
    }


    public void SetStartChargeTime(float startCT){
        for (int i = 0; i < pcPanelList.Count; i++){
            GameObject ctTemp = pcPanelList[i].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = startCT;
        }
    }

    public void UpdateCT(){
        for (int i = 0; i < pcPanelList.Count; i++){
            GameObject ctTemp = pcPanelList[i].transform.Find("CT").gameObject;
            if(ctTemp.GetComponent<Image>().fillAmount < 1.0f){
                ctTemp.GetComponent<Image>().fillAmount += BASE_CT_CHARGE + (float)pcSheets[i].CT/1000;
            }
            else{
                pcSheets[i].canAct = true;
            }
        }
    }

    public void ResetChargeTime(int playerNum){
        Debug.Log("RESETCHARGE");
        if(playerNum == 0){
            GameObject ctTemp = pcPanelList[0].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcSheets[0].canAct = false;
        }
        else if(playerNum == 1){
            GameObject ctTemp = pcPanelList[1].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcSheets[1].canAct = false;    
        }
        else if(playerNum == 2){
            GameObject ctTemp = pcPanelList[2].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcSheets[2].canAct = false; 
         }
        else if(playerNum == 3){
            GameObject ctTemp = pcPanelList[3].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcSheets[3].canAct = false;        
         }
    }

    public void SetPartyAct(bool b){
        for (int i = 0; i < pcSheets.Count; i++){
            pcSheets[i].canAct = b;
        }
    }

    public bool CanPCAct(int pcSheet){
        return pcSheets[pcSheet].canAct;
        
    }
}
