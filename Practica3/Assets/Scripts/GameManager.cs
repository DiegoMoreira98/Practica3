 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int points = 0;
    public float time = 0;
    public AudioClip background;
    // Start is called before the first frame update
    void Awake()
    {
       if (!instance) //instance  != null 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            AudioManager.instance.PlayAudioOnLoop(background, 1);
        }
        else
        {
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
    }
    public void AddPunt(int value)
    {
        points += value;
    }
    public int GetPunt()
    {
        return points;
    }
    public string GetTime()
    {
        return time.ToString("F2");
    }
}
