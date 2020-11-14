using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Shield : MonoBehaviour
{
	public float shieldTime;
	public Renderer shield;
	public float maxPower, minPower;

	private float startTime;
	private bool shieldOn = false;

	public bool turnOn = false;

	private Collider2D col;

	// Start is called before the first frame update
	void Start()
	{
		col = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (turnOn)
		{
			TurnOn();
			turnOn = false;
		}

		if (shieldOn)
		{
			col.enabled = false;
			shield.enabled = true;
			var currentTime = (Time.time - startTime) / shieldTime;
			shieldOn = currentTime < 1;
			shield.material.SetFloat("_RimPower", (maxPower - minPower) * (1 - currentTime) + minPower);
		}
		else
		{
			col.enabled = true;
			shield.enabled = false;
		}
	}

	public void TurnOn()
	{
		shieldOn = true;
		startTime = Time.time;
	}
}