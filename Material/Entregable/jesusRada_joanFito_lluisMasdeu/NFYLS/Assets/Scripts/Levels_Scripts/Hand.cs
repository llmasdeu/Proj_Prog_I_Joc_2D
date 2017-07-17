using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;

    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (facingRight) {
            if (angle < 180 && angle > 90) angle = 90;
            else if (angle > -180 && angle < -90) angle = -90;
        }

        else
        {
            if (angle > 0 && angle < 90) angle = 90;
            else if (angle < 0 && angle > -90) angle = -90;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        if (!GameObject.Find("Player").GetComponent<PlayerControl>().facingRight && facingRight)
        {
            Flip();
        }
        if (GameObject.Find("Player").GetComponent<PlayerControl>().facingRight && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
}
