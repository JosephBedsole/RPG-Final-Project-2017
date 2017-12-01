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

    [HideInInspector]
    public float[] pcCT = {0.0f,0.0f,0.0f,0.0f};
    [HideInInspector]
    public float[] enemyCT = {0.0f, 0.0f, 0.0f, 0.0f};

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

    IEnumerator Start(){
        pcPanelList.AddRange(BattleCanvasController.instance.pcPanelList);
        enemyPanelList.AddRange(BattleCanvasController.instance.enemyPanelList);
        pcSheets.AddRange(GameManager.instance.pcList);
        enemySheets.AddRange(GameManager.instance.enemyList);
        SetPartyAct(false);
        SetStartChargeTime(0.0f);

        yield return new WaitForEndOfFrame();
        for(int i = 0; i < GameManager.instance.enemyList.Count; i++){
            GameManager.instance.enemyList[i].isWaiting = true;
        }

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
                ctTemp.GetComponent<Image>().fillAmount += BASE_CT_CHARGE + (float)pcSheets[i].currCT/1000;
                pcCT[i] += BASE_CT_CHARGE + (float)pcSheets[i].currCT/1000; // TODO, replace image scale stuff with this
            }
            else{
                pcSheets[i].canAct = true;
            }
        }

        for(int i = 0; i < GameManager.instance.enemyList.Count; i++){
            if(enemyCT[i] < 1.0f && GameManager.instance.enemyList[i].isWaiting){
                enemyCT[i] += BASE_CT_CHARGE + (float)GameManager.instance.enemyList[i].currCT / 1000f;
                if (i == 0) Debug.Log("updating enemy CT: " + enemyCT[i]);
            }
            else if(enemyCT[i] >= 1.0f && GameManager.instance.enemyList[i].isWaiting){
                GameManager.instance.enemyList[i].isWaiting = false;
                GameManager.instance.enemyList[i].canAct = true;
                Debug.Log(GameManager.instance.enemyList[i].characterName + " can act!");
                BattleCanvasController.instance.actionQueue.Enqueue(BattleCanvasController.instance.EnemyAttackPCs(i));
            }
        }
    }

    public void ResetChargeTime(int playerNum){
        Debug.Log("RESETCHARGE");
        if(playerNum == 0){
            GameObject ctTemp = pcPanelList[0].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcCT[0] = 0.0f;
            pcSheets[0].canAct = false;
        }
        else if(playerNum == 1){
            GameObject ctTemp = pcPanelList[1].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcCT[0] = 0.0f;
            pcSheets[1].canAct = false;    
        }
        else if(playerNum == 2){
            GameObject ctTemp = pcPanelList[2].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcCT[0] = 0.0f;            
            pcSheets[2].canAct = false; 
         }
        else if(playerNum == 3){
            GameObject ctTemp = pcPanelList[3].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
            pcCT[0] = 0.0f;            
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