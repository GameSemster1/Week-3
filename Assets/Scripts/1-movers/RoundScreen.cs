using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundScreen : MonoBehaviour
{
	[Tooltip("Speed of movement, in meters per second")]
	[SerializeField] float speed;
    
	[SerializeField] float right;
	[SerializeField] float left;
	[SerializeField] float up;
	[SerializeField] float down;

	void Update() {
		float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
		float vertical = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
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