using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	public void OnNewGameButtonClick() {
		SceneManager.LoadScene ("Level Selection Menu");
	}

	public void OnExitGameButtonClick() {
		Application.Quit ();
	}
}
