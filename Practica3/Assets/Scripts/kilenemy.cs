using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilenemy : MonoBehaviour
{
    public GameObject enemy;
    public AudioClip enemykillclip;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("playerfoot")) //Instanciamos el AddPunt("con la cantidad que deseamos sumar"), reproducimos el sonido de enemigo muerto, y destruimos el enemigo.
        {
            GameManager.instance.AddPunt(10);
            AudioManager.instance.PlayAudio(enemykillclip, 1);
            Destroy(enemy);
        }
    }
}
