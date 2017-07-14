using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float f = 10;
    public GameObject m_bullet;

	public float firePeriod = 0.1f;
	private float nextFire = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (Time.time > nextFire) {
				nextFire = Time.time + firePeriod;
				fire();
			}
        }

    }

    private void fire()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject bullet = Instantiate(m_bullet) as GameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(f * new Vector2((mouse.x - transform.position.x), (mouse.y - transform.position.y)).normalized);

        float rad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
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
