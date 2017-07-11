using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionMenuController : MonoBehaviour {
	public void OnLevelButtonClick(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void OnGoBackButtonClick() {
		SceneManager.LoadScene ("Main Menu");
	}
}
