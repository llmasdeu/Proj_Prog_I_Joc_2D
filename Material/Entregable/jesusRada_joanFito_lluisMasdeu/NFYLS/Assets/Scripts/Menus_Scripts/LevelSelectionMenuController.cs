using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controller del nivel de selección de nivel.
public class LevelSelectionMenuController : MonoBehaviour {

	// Procedimiento encargado de controlar los botones de selección de nivel.
	public void OnLevelButtonClick(string sceneName)
	{
		// Cargamos el nivel seleccionado.
		SceneManager.LoadScene (sceneName);
	}

	// Procedimiento encargado de controlar el botón de regreso al menú principal.
	public void OnGoBackButtonClick()
	{
		// Cargamos el menú principal.
		SceneManager.LoadScene ("Main Menu");
	}
}
