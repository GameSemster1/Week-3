using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ScreenEdge : MonoBehaviour
{
	public float zOffset;
	public Vector2[] edges;

	public float offset = 5;

	private EdgeCollider2D col;

	public string[] tags;


	// Start is called before the first frame update
	private void Awake()
	{
		var cam = Camera.main;
		if (cam == null)
			return;

		Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, zOffset)) +
		                   new Vector3(offset, offset);
		Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, zOffset)) +
		                      new Vector3(offset, -offset);
		Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, zOffset)) +
		                     new Vector3(-offset, -offset);
		Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, zOffset)) +
		                  new Vector3(-offset, offset);

		edges = new[]
		{
			FromVector3(topRight), FromVector3(bottomRight),
			FromVector3(bottomLeft),
			FromVector3(topLeft), FromVector3(topRight)
		};
		col = GetComponent<EdgeCollider2D>();
		col.points = edges;
	}

	private static Vector2 FromVector3(Vector3 from)
	{
		return new Vector2(from.x, from.y);
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (tags.Any(other.CompareTag))
		{
			Destroy(other.gameObject);
		}
	}
}