using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TMP_Text text;
    public float timer = 0;
    bool timerStop = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!timerStop)
        timer -= Time.deltaTime;  //time is a float
        int seconds = ((int)timer % 60);
        int minutes = ((int)timer / 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public string getTimer()
    {
        int seconds = ((int)timer % 60);
        int minutes = ((int)timer / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}
