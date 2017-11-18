using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActionController : MonoBehaviour {




	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			// Display
		}
	}

	
}
