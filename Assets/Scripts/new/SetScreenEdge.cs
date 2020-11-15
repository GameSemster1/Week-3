using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SetScreenEdge : MonoBehaviour
{
	public ScreenEdge edgePref;

	public float zOffset;

	// Start is called before the first frame update
	void Awake()
	{
		var cam = GetComponent<Camera>();
		Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, zOffset));
		Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, zOffset));
		Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, zOffset));
		Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, zOffset));

		var edge = Instantiate<ScreenEdge>(edgePref, Vector3.zero, Quaternion.identity);

		edge.edges = new[]
		{
			FromVector3(topRight), FromVector3(bottomRight), FromVector3(bottomLeft),
			FromVector3(topLeft), FromVector3(topRight)
		};
		Debug.Log(string.Join(", ", edge.edges));
	}

	private static Vector2 FromVector3(Vector3 from)
	{
		return new Vector2(from.x, from.y);
	}

	// Update is called once per frame
	void Update()
	{
	}
}