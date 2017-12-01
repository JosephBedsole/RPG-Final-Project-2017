using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	float x;
	float y;

	public Vector3 offset = new Vector3(0, 0, -10);

	ChestController chest;
	Animator anim;
	Rigidbody2D body;

	void Start ()
	{
		Cursor.visible = true;
		AudioManager.PlayMusic();                            //   Remove this and put it on the game manager
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");		

		body.velocity = new Vector2(x, y) * speed;
		
		anim.SetFloat("Speed", body.velocity.magnitude);
		anim.SetFloat("RunX", x);
		anim.SetFloat("RunY", y);

		CameraMovement();
	}

	void CameraMovement ()
	{
		Camera.main.transform.position = this.transform.position + offset;
		// Vector3 newXOffset;
		// Vector3 newYOffset;

		// if (x > 0.1f)
		// {
		// 	newXOffset = new Vector3(1, 0, -10);
		// }
		// else if (x < -0.1f)
		// {
		// 	newXOffset = new Vector3(-1, 0, -10);
		// }
		// else
		// {
		// 	newXOffset = new Vector3(0, 0, -10);
		// }

		// if (y > 0.1f)
		// {
		// 	newYOffset = new Vector3(0, 1, -10);
		// }
		// else if (y < -0.1f)
		// {
		// 	newYOffset = new Vector3(0, -1, -10);
		// }
		// else
		// {
		// 	newYOffset = new Vector3(0, 0, -10);
		// }

		// offset = newXOffset + newYOffset;

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
