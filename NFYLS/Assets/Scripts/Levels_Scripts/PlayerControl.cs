﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.
    [HideInInspector]
    public bool canDoubleJump = false;
    [HideInInspector]
    public bool doubleJump = false;

    public bool canFly = false;


    public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public float jumpForce = 1000f;      	// Amount of force added when the player jumps.

    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.
    private Transform wallCheck;          	// A position marking where to check if the player is on a wall.
    private Transform wallCheckB;          	// A position marking where to check if the player is on a wall.
    private bool walled = false;            // Whether or not the player is on a wall.


    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        wallCheck = transform.Find("wallCheck");
        wallCheckB = transform.Find("wallCheckB");
    }


    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))
              || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Enemy"))
              || canFly;
        walled = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground"))
              || Physics2D.Linecast(transform.position, wallCheckB.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && (grounded || walled))
        {
            jump = true;
            canDoubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && canDoubleJump)
            doubleJump = true;

        
        
    }


    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (lookingRight() && !facingRight)
            // ... flip the player.
            Flip();

        else if (!lookingRight() && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (jump)
        {

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            canDoubleJump = true;

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }

        if (doubleJump)
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            canDoubleJump = false;
            doubleJump = false;
        }

    }


    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    bool lookingRight()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        if (dir.x > 0) return true;
        else return false;
    }
}
