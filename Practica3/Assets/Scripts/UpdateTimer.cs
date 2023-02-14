using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public float time = 0;
    public TMPro.TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "TIME:" + time.ToString("F2");
    }
}
