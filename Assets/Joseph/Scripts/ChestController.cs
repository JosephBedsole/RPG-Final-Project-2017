using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {


	public bool active = true;
	public bool locked = false;

	public Items[] chestContents;

	// Make this an OnMouseClick Function so the player can just click on the item when within a specific area;
	public void HandOverItems ()
	{
		if (active && !locked)
		{
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
