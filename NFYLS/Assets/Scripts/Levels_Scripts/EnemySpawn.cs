using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public Transform[] enemySpawns;
	public GameObject enemy;
	public int nextSpawn = 0;
	public int timeBetweenSpawns = 10;
	// Use this for initialization
	void Start () {
		//Spawn ();
	}


	void Spawn()
	{
		for (int i = 0; i < enemySpawns.Length; i++)
		{
			int enemyFlip = Random.Range (0, 2);
			if (enemyFlip > 0)
				Instantiate(enemy, enemySpawns[i].position, Quaternion.identity);
		}
	}

	void Update() {
		if ((int)Time.time == nextSpawn) {
			Spawn ();
			nextSpawn = (int)Time.time + timeBetweenSpawns;
		}
	}
}
