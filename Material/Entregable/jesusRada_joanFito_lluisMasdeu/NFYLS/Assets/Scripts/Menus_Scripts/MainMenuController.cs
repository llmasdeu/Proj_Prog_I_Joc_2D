using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controller del menú principal.
public class MainMenuController : MonoBehaviour {

	// Procedimiento encargado de controlar el botón de nuevo juego.
	public void OnNewGameButtonClick()
	{
		// Cargamos el menú de selección de nivel.
		SceneManager.LoadScene ("Level Selection Menu");
	}

	// Procedimiento encargado de controlar el botón de salida del juego.
	public void OnExitGameButtonClick()
	{
		// Salimos de la aplicación.
		Application.Quit ();
	}
}
