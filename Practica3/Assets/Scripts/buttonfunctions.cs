using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonfunctions : MonoBehaviour
{
    public void PauseTimer() //Pausamos el timer.
    {
        Time.timeScale = 0;
    }
    public void StartTimer() //Iniciamos el timer.
    {
        Time.timeScale = 1;
    }
    public void ResetPunt() //Reseteamos el timer.
    {
       GameManager.instance.ResetPunt(0);
    }
    public void ChangeScene(string name) //Cambiamos a la escena designada, en este caso iria al menu principal y limpiamos la lista de audios.
    {
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
    }
    public void ExitGame() //Indicamos a la aplicación que se cierre.
    {
        Application.Quit();
    }
}
