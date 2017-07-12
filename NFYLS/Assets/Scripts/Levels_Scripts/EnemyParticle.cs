using UnityEngine;
using System.Collections;

public class EnemyParticle : MonoBehaviour
{
	private float time;

    void Start()
    {
		time = Random.Range(3f,6f);
        Destroy(gameObject, time);
    }

}