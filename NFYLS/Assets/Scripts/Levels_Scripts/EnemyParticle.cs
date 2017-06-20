using UnityEngine;
using System.Collections;

public class EnemyParticle : MonoBehaviour
{
    public float time = 5.0f;

    void Start()
    {
        Destroy(gameObject, time);
    }

}