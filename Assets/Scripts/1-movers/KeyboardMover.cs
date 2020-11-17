using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class KeyboardMover : MonoBehaviour
{
	[Tooltip("Speed of movement, in meters per second")] [SerializeField]
	float speed = 1f;

	public float screenOffset = 0f;

	float leftLimitPlayer;
	float rightLimitPlayer;
	float topLimitPlayer;
	float bottomLimitPlayer;

	private void Start()
	{
		var cam = Camera.main;

		if (cam == null)
			return;

		Vector3 max = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
		Vector3 min = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));

		leftLimitPlayer = min.x - screenOffset;
		rightLimitPlayer = max.x + screenOffset;

		topLimitPlayer = max.y + screenOffset;
		bottomLimitPlayer = min.y - screenOffset;
	}

	void Update()
	{
		float
			horizontal =
				Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
		float vertical = Input.GetAxis("Vertical"); // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
		Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
		transform.position += movementVector;

		transform.position = new Vector3
		(
			Mathf.Clamp(transform.position.x, leftLimitPlayer, rightLimitPlayer),
			Mathf.Clamp(transform.position.y, bottomLimitPlayer, topLimitPlayer),
			transform.position.z
		);
		//transform.Translate(movementVector);
		// NOTE: "Translate(movementVector)" uses relative coordinates - 
		//       it moves the object in the coordinate system of the object itself.
		// In contrast, "transform.position += movementVector" would use absolute coordinates -
		//       it moves the object in the coordinate system of the world.
		// It makes a difference only if the object is rotated.
	}
}