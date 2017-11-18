using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {


	public bool active = true;
	public bool locked = false;

	public Items[] chestContents;
	public int goldToGive = 10;

	// Make this an OnMouseClick Function so the player can just click on the chest when within a specific area;

	void Start ()
	{
		goldToGive = Random.Range(1, 10); // Can I make this a function that is called from a different script?
	}

	public void HandOverItems ()
	{
		if (active && !locked)
		{
			PlayerInventory.instance.gold += goldToGive;
			for (int i = 0; i < chestContents.Length; ++i)
			{
				Items newItem = chestContents[i];
				PlayerInventory.instance.AddItem(newItem);
			}
		}
		else if (active && locked)
		{
			// look for key
			// if key
			// set locked to false
			// else
			// Display: "Locked"
			// Play: Locked sound
		}
		else
		{
			Debug.Log("The chest is not active");
		}
	}

}
