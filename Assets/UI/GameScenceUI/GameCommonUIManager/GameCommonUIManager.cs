using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameCommonUIManager : MonoBehaviour
{
    #region Variables
    [SerializeField]GameObject gameOverUI;

    
    [SerializeField]GameObject totalUI;
    [SerializeField] Timer timer;
    [SerializeField] private Text complectBox;
    [SerializeField] private Text score;
    [SerializeField] private Text timeText;
    [SerializeField]private Text result;
    [SerializeField] private Text sp;

    [SerializeField]Animator gameOverAnimator;
    [SerializeField]Animator anyButtonAnimtor;
    [SerializeField] Animator totalAnimator;
    [SerializeField] GameObject boxZoomView;
    [SerializeField]Animator van_animtor;
    [SerializeField] Animator gCUI_anmator;

    [SerializeField] GameObject stageClearUI;
    
    
    //[SerializeField] GameObject back_closeZoomButton;
    [SerializeField]GetAnser_1 getAnser;
    // [SerializeField] float stageClearBackWaitTime = 3;
    [SerializeField] Toggle[] checklistToggles;


    #endregion
    private void Start()
    {
        //checkListOpen = true;
        gameOverUI.SetActive(false);
        totalUI.SetActive(false);
        van_animtor.Play("van_GoBack");
       // back_closeZoomButton.SetActive(false);
       
        gameOverAnimator.SetBool("gameOverContinue", false);
        
        
    }
    public void gameOver()
    {
        
        gameOverUI.SetActive(true);
        gameOverAnimator.Play("GameOverIn_Animation");
        anyButtonAnimtor.Play("GameOver_PressAnyKey_Animtion");
        boxZoomView.SetActive(false);


    }
    private void Update()
    {
        //if (boxZoomView.active==true)
      //  {
           // back_closeZoomButton.SetActive(true);
       // }else {back_closeZoomButton.SetActive(false);}

        
            if (gameOverUI.active == true)
            {
                if (Input.anyKey)
                {
                    gameOverAnimator.SetBool("gameOverContinue", true);

                    gameOverAnimator.SetBool("gameOverEnd", true);
                }
            if (gameOverAnimator.GetBool("gameOverEnd") == true)
            {
                totalUI.SetActive(true);
                //gameOverUI.SetActive(false);
                complectBox.text = PlayerPrefs.GetInt("boxComplection").ToString("0/5");
                score.text = PlayerPrefs.GetInt("TotleScore").ToString("00/25");
                Debug.Log("TotleScore: " + PlayerPrefs.GetInt("TotleScore"));
                timeText.text = timer.getFinishTime();
                result.text = "FAIL";
                sp.text = "... AGAIN ?";

                totalAnimator.Play("totalIn_animation");


            }
            }
            
        
        if(getAnser.GetAnserIsCorrected() == true) {
           boxZoomView.SetActive(false);
            getAnser.setAnserIsCorrected();
           

            
        }
        if (stageClearUI.active == true)
        {

            if (Input.anyKey)
            {
                stageClearUI.SetActive(false);
                totalUI.SetActive(true);
                complectBox.text = PlayerPrefs.GetInt("boxComplection").ToString("0/5");
                score.text = PlayerPrefs.GetInt("TotleScore").ToString("00/25");
                Debug.Log("TotleScore: " + PlayerPrefs.GetInt("TotleScore"));
                timeText.text = timer.getFinishTime();
                result.text = "PASS";
                sp.text = "GOOD JOB";
               // SceneManager.LoadScene("lv");
               totalAnimator.Play("totalIn_animation");
            }
        }
        
               
         
       
    }

   
    public void BackToLeveManuel()
    {
      SceneManager.LoadScene("lv");
    }
    
    public void StageClear()
    {
        stageClearUI.SetActive(true);
        boxZoomView.SetActive(false);
       
        
    }
    public void resetCheckList()
    {
        for(int i=0;i<checklistToggles.Length;i++ ){
            checklistToggles[i].isOn = false;

        }
    }
    //private bool checkListOpen = true;
   //[SerializeField] GameObject checklistButton;
    /*public void checkListButton()
    {
        if(checkListOpen== true)
        {
            checklistButton.transform.Rotate(0, 0, 180);
            gCUI_anmator.Play("checklist_In_animation");
            checkListOpen = false;

           
        }
        else
        {
            checklistButton.transform.Rotate(0, 0, 180);
            gCUI_anmator.Play("checklist_Out_animation");
            checkListOpen = true;
        }
      

    }*/
    public void showAnser()
    {
        gCUI_anmator.Play("showAnser_In_animation");
    }
    public void closeAnser()
    {
        gCUI_anmator.Play("showAnser_Out_animation");
    }
}
