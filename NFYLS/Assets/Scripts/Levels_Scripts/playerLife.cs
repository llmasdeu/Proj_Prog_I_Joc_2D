using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour {

    public int life = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life < 1) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            life--;
        }

    }
}
