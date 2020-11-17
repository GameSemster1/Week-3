using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Places the current GameObject at a specified screen coordinate.
/// </summary>
public class PlaceAtScreen : MonoBehaviour
{
	[Tooltip("A coordinate on the screen (values between 0 and 1) to place this object at.")]
	public Vector3 screenPosition;

	public Vector3 screenScale;

	// Start is called before the first frame update
	void Start()
	{
		var cam = Camera.main;
		if (cam != null)
		{
			transform.position = cam.ScreenToWorldPoint(
				new Vector3(screenPosition.x * cam.pixelWidth,
					screenPosition.y * cam.pixelHeight, screenPosition.z));

			var temp = cam.ScreenToWorldPoint(
				new Vector3(screenScale.x * cam.pixelWidth,
					screenScale.y * cam.pixelHeight, 0));

			temp.z = screenScale.z;

			transform.localScale = temp;
		}
	}
}