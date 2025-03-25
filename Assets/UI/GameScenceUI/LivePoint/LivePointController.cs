using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePointController : MonoBehaviour
{
    [SerializeField] Animator LP_animator1;
    [SerializeField] Animator LP_animator2;
    [SerializeField] Animator LP_animator3;
    private int livePointcounter=0;
    [SerializeField] GameCommonUIManager gameOverManager;
    private bool gameOver = false;

    private void Start()
    {
        livePointcounter = 0;
        gameOver = false;
    }
    public void MissSubmition()//call to count the miss subimtion
    {
        livePointcounter = livePointcounter + 1;
        LPAnimationController();//to play the LP animation
    }
    private void LPAnimationController()
    { 
        switch(livePointcounter){
            case 1:
                LP_animator1.Play("LP_Boom_animation");
                break;
            case 2:
                 LP_animator2.Play("LP_Boom_animation");
                break;
            case 3:
                 LP_animator3.Play("LP_Boom_animation");
                
                gameOverManager.gameOver();
                gameOver = true;
                break;
        }
    }

    public bool getGameOver()
    {
        return gameOver;
    }
    

}
