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
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        GameManager.instance.AddPunt(20);
        Debug.Log(GameManager.instance.GetPunt());
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
