using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	float x;
	float y;

	public Vector3 offset = new Vector3(0, 0, -10);

	Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");

		body.velocity = new Vector2(x, y) * speed;

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



}
