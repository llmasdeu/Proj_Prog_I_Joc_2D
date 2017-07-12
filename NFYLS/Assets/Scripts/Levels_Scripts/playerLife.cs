using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour {

    public int life = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (life < 1)
		{
			Destroy (gameObject);

			// Accedemos a la pantalla de Game Over.
			SceneManager.LoadScene ("Game Over");
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            life--;
        }

    }
}
