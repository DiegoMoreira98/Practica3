using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcompleted : MonoBehaviour
{
    public AudioClip winnerclip;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //Si el player llega al final del mapa reproduce el audio de winner e invoca change().
        {
            AudioManager.instance.PlayAudio(winnerclip, 2);
            Invoke("change",2f);
        }
    }

    public void change() //Al invocarse change(), carga el siguiente escenario y limpia la lista de audio.
    {

           SceneManager.LoadScene("Level2");
           AudioManager.instance.ClearAudioList();
    }
}
