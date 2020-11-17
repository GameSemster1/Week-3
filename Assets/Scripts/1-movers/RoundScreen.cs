using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundScreen : MonoBehaviour
{
	[Tooltip("Speed of movement, in meters per second")] [SerializeField]
	float speed;

	public float screenOffset = 1f;

	float right;
	float left;
	float up;
	float down;

	private void Start()
	{
		var cam = Camera.main;

		if (cam == null)
			return;

		Vector3 max = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
		Vector3 min = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));

		left = min.x - screenOffset;
		right = max.x + screenOffset;

		up = max.y + screenOffset;
		down = min.y - screenOffset;
	}

	void Update()
	{
		float
			horizontal =
				Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
		float vertical = Input.GetAxis("Vertical"); // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
		Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
		transform.position += movementVector;

		float x = transform.position.x;
		float y = transform.position.y;

		if (x > right)
		{
			transform.position = new Vector3(left, y, 0f);
		}
		else if (x < left)
		{
			transform.position = new Vector3(right, y, 0f);
		}
		else if (y > up)
		{
			transform.position = new Vector3(x, down, 0f);
		}
		else if (y < down)
		{
			transform.position = new Vector3(x, up, 0f);
		}
	}
}