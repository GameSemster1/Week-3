using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpawner : MonoBehaviour
{
	public GameObject obj;
	public float zOffset;
	public Vector3 offset;

	[Tooltip("Lower left corner of the screen box. Values between 0 and 1 (0,0 -> bottom left, 1,1 -> top right.")]
	public Vector2 screenLocationMin;

	[Tooltip("The upper right corner of the screen box. Values between 0 and 1 (0,0 -> bottom left, 1,1 -> top right.")]
	public Vector2 screenLocationMax;

	[Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField]
	float minTimeBetweenSpawns = 1f;

	[Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField]
	float maxTimeBetweenSpawns = 3f;

	[Tooltip("Minimum angle difference from this object")] [SerializeField]
	float minAngle = -15f;

	[Tooltip("Maximum angle difference from this object")] [SerializeField]
	float maxAngle = 15f;


	private Vector3 min, max;

	// Start is called before the first frame update
	private void Awake()
	{
		var cam = Camera.main;
		if (cam == null)
			return;

		max = cam.ScreenToWorldPoint(
			new Vector3(screenLocationMin.x * cam.pixelWidth,
				screenLocationMin.y * cam.pixelHeight,
				zOffset)) + offset;
		min = cam.ScreenToWorldPoint(new Vector3(screenLocationMax.x * cam.pixelWidth,
			screenLocationMax.y * cam.pixelHeight,
			zOffset)) + offset;
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
			Vector3 positionOfSpawnedObject = RandomInBox(min, max);
			var rotationOfSpawnedObject = Quaternion.Euler(0, 0, (maxAngle - minAngle) * Random.value + minAngle);
			var newObject = Instantiate(obj, positionOfSpawnedObject, rotationOfSpawnedObject);
		}
	}

	private static Vector3 LerpByPercent(Vector3 a, Vector3 b, float x)
	{
		Vector3 p = x * (b - a) + a;
		return p;
	}

	private static Vector3 RandomInBox(Vector3 min, Vector3 max)
	{
		var x = Random.Range(min.x, max.x);
		var y = Random.Range(min.y, max.y);
		var z = Random.Range(min.z, max.z);
		return new Vector3(x, y, z);
	}
}