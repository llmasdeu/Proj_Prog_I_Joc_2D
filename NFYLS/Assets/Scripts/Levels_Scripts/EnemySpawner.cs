using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	private Vector2 spawnPosition;

	public float xSpawnRNGMax = 0;
	public float xSpawnRNGMin = 0;
	public float ySpawnRNGMax = 0;
	public float ySpawnRNGMin = 0;

	public float spawnRate = 2f;
	public float spawnIncresase = 5f;
	private float nextSpawn = 2f;

	// Use this for initialization
	void Start () {

		nextSpawn += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			float xRNG = Random.Range (xSpawnRNGMin, xSpawnRNGMax);
			float yRNG = Random.Range (ySpawnRNGMin, ySpawnRNGMax);
			nextSpawn = Time.time + spawnRate;
			spawnRate *=  1 - (spawnIncresase/100);
			spawnPosition = new Vector2 (transform.position.x + xRNG, transform.position.y + yRNG);
			Instantiate (enemy, spawnPosition, Quaternion.identity);
		}
	}
}
