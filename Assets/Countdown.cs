using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Countdown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField]GameCommonUIManager gameCommonUIManager;
 

    
    void Update()
    {
        
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0) 
        { 
            remainingTime = 0;

           
            timerText.color = Color.red;
            gameCommonUIManager.gameOver();


        }
                
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes,seconds);

       


    }
}
