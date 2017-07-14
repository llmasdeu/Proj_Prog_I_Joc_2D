using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	private Vector2 spawnPosition;
	public float spawnRate = 2f;
	private float nextSpawn = 2f;

	// Use this for initialization
	void Start () {

		nextSpawn += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			spawnRate -= (spawnRate/20);
			spawnPosition = new Vector2 (transform.position.x, transform.position.y);
			Instantiate (enemy, spawnPosition, Quaternion.identity);
		}
	}
}
