using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TMP_Text text;
    public float timer = 0;
    static float timerStatic = 0;
    bool timerStop = false;
    string scenename;
    void Start()
    {
        scenename = SceneManager.GetActiveScene().name;
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
    public static string getTimerStatic()
    {
        int seconds = ((int)timerStatic % 60);
        int minutes = ((int)timerStatic / 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
