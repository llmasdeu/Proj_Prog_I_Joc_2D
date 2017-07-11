using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	private float randX;
	private Vector2 spawnPosition;
	public float spawnRate = 2f;
	private float nextSpawn = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-10f, 20f);
			spawnPosition = new Vector2 (randX, transform.position.y);
			Instantiate (enemy, spawnPosition, Quaternion.identity);
		}
	}
}
