using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public Vector2 moveAmount;
	private float moveDirection = 1.0f;

	private Transform wallCheck;
	private bool walled = false;

	// Use this for initialization
	void Start () {

		int n = Random.Range (0, 10);
		if (n % 2 == 0)
			Flip ();
		wallCheck = transform.Find("wallCheck");
	}

	void Update(){

		walled = Physics2D.Linecast (transform.position, wallCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
	}

	void FixedUpdate() {
		moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
		transform.Translate(moveAmount); //Move the enemy

		if (walled)
			Flip ();
	}

	public void Flip() {
		moveDirection *= -1;
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
		
}
