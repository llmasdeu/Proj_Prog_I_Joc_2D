using UnityEngine;
using System.Collections;

public class EnemyParticle : MonoBehaviour
{
	private float time;

    void Start()
    {
		time = Random.Range(3f,15f);
        Destroy(gameObject, time);
    }

}