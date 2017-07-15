using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

	public static int enemiesKilled;
	public static int enemiesDroped;
	public int pointsForKill = 5;
	public int pointsForDrop = 2;
	private Text text;
	private int score = 0;

	// Use this for initialization
	void Start () {
		enemiesKilled = 0;
		enemiesDroped = 0;
		text = GameObject.Find("ScoreText").GetComponent<Text>();
		text.text = "" + score;
	}
	
	// Update is called once per frame
	void Update () {
		score = (enemiesKilled * pointsForKill) - (enemiesDroped * pointsForDrop);
		text.text = "" + score;
	}
}
