using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
	
	public EventSystem eventSystem;				// Funciona correctamente con la BETA de Unity 5.6
	public GameObject selectedObject;

	private bool buttonSelected;

	// Initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) 
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
}