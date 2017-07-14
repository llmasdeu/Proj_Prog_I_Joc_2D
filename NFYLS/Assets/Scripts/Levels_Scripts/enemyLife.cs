using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour {

    public int life = 3;
	public GameObject particle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (life < 1) {
			float x;
			float y;
			float z = 0;
			for (int i = 0; i < 4; i++) {
				GameObject part = Instantiate (particle) as GameObject;
				x = Random.Range (-1f, 1f);
				y = Random.Range (-1f, 1f);

				part.transform.position = transform.position + new Vector3(x,y,z);
			}
			Destroy (gameObject);
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerAttack")
        {
            life--;
        }
		if (other.gameObject.tag == "mapEnd")
		{
			life = 0;
		}
        
    }
}
