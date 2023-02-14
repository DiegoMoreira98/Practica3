using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcompleted2 : MonoBehaviour
{
    public AudioClip winnerclip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(winnerclip, 2);
            Invoke("change", 3f);
        }
    }

    public void change()
    {

        SceneManager.LoadScene("Level3");
    }
}
