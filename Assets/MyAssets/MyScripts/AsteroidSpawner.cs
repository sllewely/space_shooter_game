using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	public static int asteroidCount = 0;
	public int maxAsteroids;

	public GameObject asteroidPrefab;
	private float spawnTimer = 1;
	public float spawnRate;

	public Color gizmoColor;
	public float spawnRadius;
	public Transform shipTransform;

	void OnDrawGizmos() {
		Gizmos.color = gizmoColor;
		Gizmos.DrawSphere (shipTransform.position, spawnRadius);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (spawnTimer >= 0) {
			spawnTimer -= Time.deltaTime;
		} else {
			SpawnOneAsteroid ();
			spawnTimer = spawnRate;
		}
	}

	void SpawnOneAsteroid() {
		int numAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid").Length;
		asteroidCount++;
		if (numAsteroids > maxAsteroids) {
			return;
		}

		// create something on the outside edge of the circle
		Vector2 spawnPosition2D = Random.insideUnitCircle.normalized * spawnRadius;
		Vector3 spawnPosition3D = new Vector3 (spawnPosition2D.x, spawnPosition2D.y, 0);
		spawnPosition3D += shipTransform.position;
		Instantiate (asteroidPrefab, spawnPosition3D, Quaternion.identity);

	}
}
