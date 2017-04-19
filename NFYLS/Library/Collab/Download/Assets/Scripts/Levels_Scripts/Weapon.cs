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
		var angle = Mathf.Rad2Deg * rad;

        if (GameObject.Find("Player").GetComponent<PlayerControl>().facingRight)
        {
            if (angle < 180 && angle > 90) angle = 90;
            else if (angle > -180 && angle < -90) angle = -90;
        }

        else
        {
            if (angle > 0 && angle < 90) angle = 90;
            else if (angle < 0 && angle > -90) angle = -90;
        }


        bullet.transform.Rotate(new Vector3(0, 0, angle));
    }
}
