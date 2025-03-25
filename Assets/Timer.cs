using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject stageClearUI;
    
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

  
    

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.active == false&&stageClearUI.active == false) 
         elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes,seconds);
      

    }
    public string getFinishTime()
    {
        return timerText.text;
    }
}
