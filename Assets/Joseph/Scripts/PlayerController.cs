using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	bool isStepping = false;
	float x;
	float y;
	int i = 0;

	public Vector3 offset = new Vector3(0, 0, -10);
	ChestController chest;
	Animator anim;
	Rigidbody2D body;
	SpriteRenderer charSprite;

	void Start ()
	{
		Cursor.visible = true;
		// AudioManager.PlayMusic();                            //   Remove this and put it on the game manager
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		charSprite = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate ()
	{
		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");		

		body.velocity = new Vector2(x, y) * speed;
		
		anim.SetFloat("Speed", body.velocity.magnitude);
		anim.SetFloat("RunX", x);
		anim.SetFloat("RunY", y);
		
		CheckDirection();

		CameraMovement();

		if((Mathf.Abs(x) > 0.5f || Mathf.Abs(y) > 0.5f) && !isStepping){
			StartCoroutine("UpdateBattleChance");
		}
	}

	void CheckDirection ()
	{
		Debug.Log("What's up");
		if (body.velocity.x > 0.1f)
		{
			anim.SetBool("Right", true);
			anim.SetBool("Left", false);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
		}
		else if (body.velocity.x < -0.1f)
		{
			anim.SetBool("Right", false);
			anim.SetBool("Left", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
		}
		else if (body.velocity.y > 0.1f)
		{
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
			anim.SetBool("Up", true);
			anim.SetBool("Down", false);
		}
		else if (body.velocity.y < -0.1f)
		{
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
			anim.SetBool("Up", false);
			anim.SetBool("Down", true);
		}
	}

	IEnumerator UpdateBattleChance(){
		isStepping = true;
		GameManager.instance.battleChance += 1.0f;
		GameManager.instance.RandomEncounterRoll();
		yield return new WaitForSeconds(1.0f);
		isStepping = false;
	}

	void CameraMovement ()
	{
		Camera.main.transform.position = this.transform.position + offset;
	}

	public void OpenChest ()
	{
		if (chest.active)
		{
			chest.HandOverItems();
			// Call a display items script from the ChestController as well;

			MenuController.instance.chestPrompt.gameObject.SetActive(false);
			chest.active = false;
			
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Shop")
		{
			ShopController.instance.nearShop = true;
		}

		if (c.gameObject.tag == "Portal")
		{
			// Display do you want to enter
			// or
			// Just transition
			SceneController.instance.ChangeScene();
		}

		if (c.gameObject.tag == "Chest")
		{
			chest = c.gameObject.GetComponent<ChestController>();
			if (chest.active)
			{
				MenuController.instance.chestPrompt.gameObject.SetActive(true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Shop")
		{
			ShopController.instance.nearShop = false;
		}

		if (c.gameObject.tag == "Chest")
		{
			MenuController.instance.chestPrompt.gameObject.SetActive(false);
		}
	}



}
