using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerLife : MonoBehaviour {

    public int life = 3;
	public Text text;
	public float inmunityTime = 2f;
	private float nextHitTime = 0f;

	private float spriteBlinkingTimer = 0.0f;
	private float spriteBlinkingMiniDuration = 0.1f;
	private float spriteBlinkingTotalTimer = 0.0f;
	private float spriteBlinkingTotalDuration = 0.6f;
	private bool startBlinking = false;

    // Use this for initialization
    void Start() {
		text = GameObject.Find("HealthText").GetComponent<Text>();
		text.text = "" + life;
    }

    // Update is called once per frame
    void Update()
    {
		if (life < 0)
		{
			Destroy (gameObject);

			// Accedemos a la pantalla de Game Over.
			SceneManager.LoadScene ("Game Over");
		}

		if(startBlinking == true)
		{ 
			SpriteBlinkingEffect();
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
			if (Time.time > nextHitTime) {
				nextHitTime = Time.time + inmunityTime;
				life--;
				text.text = "" + life;
				startBlinking = true;
			}
        }
		if (other.gameObject.tag == "mapEnd")
			life = -1;

				

    }

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "enemy") {
			if (Time.time > nextHitTime) {
				nextHitTime = Time.time + inmunityTime;
				life--;
				text.text = "" + life;
				startBlinking = true;
			}
		}
	}

	private void SpriteBlinkingEffect()
	{
		spriteBlinkingTotalTimer += Time.deltaTime;
		if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration) {
			startBlinking = false;
			spriteBlinkingTotalTimer = 0.0f;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to 
			//your sprite
			return;
		}

		spriteBlinkingTimer += Time.deltaTime;
		if (spriteBlinkingTimer >= spriteBlinkingMiniDuration) {
			spriteBlinkingTimer = 0.0f;
			if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
			}
		}
	}
}
