using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "inventory/CharacterInventory", order = 2)]
public class CharacterInventory : ScriptableObject {

	public Items helmet;
	public Items sword;
	public Items rightHand;
	public Items rightAccessory;
	public Items leftHand;
	public Items leftAccessory;
	public Items breastPlate;
	public Items neckAccessory;
	public Items legs;
	public Items feet;

}
