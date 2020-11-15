using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScreenSpawner : MonoBehaviour
{
	public Mover obj;
	public float offset, zOffset;

	[SerializeField] Vector3 velocityOfSpawnedObject;

	[Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField]
	float minTimeBetweenSpawns = 1f;

	[Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField]
	float maxTimeBetweenSpawns = 3f;

	[Tooltip("Minimum angle difference from this object")] [SerializeField]
	float minAngle = -15f;

	[Tooltip("Maximum angle difference from this object")] [SerializeField]
	float maxAngle = 15f;


	private Vector3 start, end;

	// Start is called before the first frame update
	private void Awake()
	{
		var cam = Camera.main;
		if (cam == null)
			return;

		Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, zOffset)) +
		                   Vector3.up * offset;
		Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, zOffset)) +
		                  Vector3.up * offset;

		start = topLeft;
		end = topRight;
	}

	void Start()
	{
		this.StartCoroutine(SpawnRoutine());
	}

	private IEnumerator SpawnRoutine()
	{
		while (true)
		{
			float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
			yield return new WaitForSeconds(timeBetweenSpawns);
			Vector3 positionOfSpawnedObject = LerpByPercent(start, end, Random.value);
			var rotationOfSpawnedObject = Quaternion.Euler(0, 0, (maxAngle - minAngle) * Random.value + minAngle);
			var newObject = Instantiate(obj, positionOfSpawnedObject, rotationOfSpawnedObject);
			newObject.SetVelocity(velocityOfSpawnedObject);
		}
	}

	private static Vector3 LerpByPercent(Vector3 a, Vector3 b, float x)
	{
		Vector3 p = x * (b - a) + a;
		return p;
	}
}