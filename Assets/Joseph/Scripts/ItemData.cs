using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour {
	public static ItemData instance;
	void Awake () 
	{ 
		if (instance == null)
		{
			instance = this;
		}
	}

	public GameObject[] weapons;
	public GameObject[] armor;
	public GameObject[] accessories;
	public GameObject[] consumables;


	void Start () {
		
	}
	
	void Update () {
		
	}
}
