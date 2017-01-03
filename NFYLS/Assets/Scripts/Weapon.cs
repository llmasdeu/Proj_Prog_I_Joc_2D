using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public GameObject m_bullet;
	void Start () 
	{

	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			fire();
		}

	}

	private void fire()
	{
		Vector3 mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		GameObject bullet = Instantiate (m_bullet) as GameObject;
		bullet.transform.position = transform.position;

		float rad = Mathf.Atan2 (mouse.y - transform.position.y, mouse.x - transform.position.x);
		bullet.transform.Rotate (new Vector3(0,0, Mathf.Rad2Deg * rad));
	}
}
