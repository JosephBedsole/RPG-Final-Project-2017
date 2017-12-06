using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour {

	public static int rewardXP = 0;
	public static int rewardGold = 0;



	//PlayerInventory.instance.AddItem();

	public static void ResetReward(){
		rewardGold = 0;
		rewardXP = 0;
	}
}
