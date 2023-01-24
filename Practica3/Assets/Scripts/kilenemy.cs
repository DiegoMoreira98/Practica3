using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilenemy : MonoBehaviour
{
    public GameObject enemy; 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(enemy);
        }
    }
}
