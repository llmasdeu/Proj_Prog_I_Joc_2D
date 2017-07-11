using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public Vector2 moveAmount;
	private float moveDirection = 1.0f;

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
		transform.Translate(moveAmount); //Move the enemy
	}

	public void Flip() {
		moveDirection *= -1;
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
		
	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "wall") {
			Flip();
		}
	}
}
