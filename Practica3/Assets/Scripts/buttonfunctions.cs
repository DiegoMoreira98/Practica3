using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonfunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseTimer()
    {
        Time.timeScale = 0;
    }
    public void StartTimer()
    {
        Time.timeScale = 1;
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
