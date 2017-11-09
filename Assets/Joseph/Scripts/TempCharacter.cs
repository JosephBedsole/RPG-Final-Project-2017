using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCharacter : MonoBehaviour {

	public static TempCharacter instance;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public Items mainHand;
	public Items armor;
	public Items accessory;

}
