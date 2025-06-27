using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCode : MonoBehaviour
{

    public static TimerCode m_timercode=null;
    // Start is called before the first frame update
    [SerializeField]
    TMP_Text text;
    public float timer = 0;
    static float timerStatic = 0;
    bool timerStop = false;
    public float totalTime = 0;
    static float totalTimeStatic = 0;
    string scenename;

    public GameObject timerCanvas;

    void Start()
    {
        m_timercode = this;
        scenename = SceneManager.GetActiveScene().name;
        totalTime = timer;
        totalTimeStatic = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timerStatic = timer;
        if (!timerStop && scenename.Equals("TimeTrial"))
        {
            timer -= Time.deltaTime;  //time is a float
            int seconds = ((int)timer % 60);
            int minutes = ((int)timer / 60);
            text.text = "Time\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
            if (timer < 0)
            {
                StaticObjOrVar.callFinish();
                GameObject.Find("StopClick").GetComponent<BoxCollider>().enabled = true;
                timerStop = true;

            }
        }
        else if (!timerStop)
        {
            timer += Time.deltaTime;  //time is a float
            int seconds = ((int)timer % 60);
            int minutes = ((int)timer / 60);
            text.text = "Time\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public string getTimer()
    {
        int seconds = ((int)timer % 60);
        int minutes = ((int)timer / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public float getTimerFloat()
    {
        return timer;
    }
    public static float getTimerLeftStatic()
    {
        return timerStatic;
    }
    public static string getTimerStatic()
    {
        int seconds = ((int)timerStatic % 60);
        int minutes = ((int)timerStatic / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void setTimerStop(bool s)
    {
        timerStop = s;
    }

    public void disableTimerCanvas()//disable timer display when display result panel
    {
        timerCanvas.SetActive(false);
    }

    public static void getDisableTimerCanvas()//for call my other static , disable timer display when display result panel
    {
        m_timercode.disableTimerCanvas();
    }
    public static TimerCode hi()
    { 
        return m_timercode;
    }
}
