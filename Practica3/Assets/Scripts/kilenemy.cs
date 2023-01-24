using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilenemy : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("playerfoot"))
        {
            Destroy(enemy);
        }
    }
}
