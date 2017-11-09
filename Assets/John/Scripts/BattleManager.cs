using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public GameObject pc1;
    public GameObject pc2;
    public GameObject pc3;
    public GameObject pc4;

    public float DebugCTRate = 0.05f;

    List<GameObject> pcList = new List<GameObject>();

    void OnEnable(){
        pc1 = GameObject.Find("pc1");
        pc2 = GameObject.Find("pc2");
        pc3 = GameObject.Find("pc3");
        pc4 = GameObject.Find("pc4");
    
        pcList.Add(pc1);
		pcList.Add(pc2);
		pcList.Add(pc3);
		pcList.Add(pc4);

        SetStartChargeTime(0.1f);

        BattleCanvasController.playerActed += ResetChargeTime;
    
    }

    void OnDisable(){
        BattleCanvasController.playerActed -= ResetChargeTime;
    }

    void Update(){
        UpdateCT();
    }


    public void SetStartChargeTime(float startCT){
        for (int i = 0; i < pcList.Count; i++){
            GameObject ctTemp = pcList[i].transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = startCT;
        }
    }

    public void UpdateCT(){

        for (int i = 0; i < pcList.Count; i++){
            GameObject ctTemp = pcList[i].transform.Find("CT").gameObject;
            if(ctTemp.GetComponent<Image>().fillAmount < 1.0f){
                ctTemp.GetComponent<Image>().fillAmount += DebugCTRate;
            }
        }
    }

    public void ResetChargeTime(int playerNum){
        Debug.Log("RESETCHARGE");
        if(playerNum == 1){
            GameObject ctTemp = pc1.transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;
        }
        else if(playerNum == 2){
            GameObject ctTemp = pc2.transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;        
        }
        else if(playerNum == 3){
            GameObject ctTemp = pc3.transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;           
         }
        else if(playerNum == 4){
            GameObject ctTemp = pc4.transform.Find("CT").gameObject;
            ctTemp.GetComponent<Image>().fillAmount = 0.0f;      
         }
    }

   
	
}
