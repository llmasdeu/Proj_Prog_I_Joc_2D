using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controller del menú de Game Over.
public class GameOverMenuController : MonoBehaviour {
	
	void Update ()
	{
		// Controlamos el teclado.
		if (Input.GetKeyDown (KeyCode.Space))
		{
			// Cargamos el menú principal.
			SceneManager.LoadScene ("Main Menu");
		}
	}
}
