using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float time = 0.4f;
    public bool throwable = false;

    void Start()
    {
        Destroy(gameObject, time);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "ground" && !throwable)
        {
            Destroy(gameObject);
        }
    }

}