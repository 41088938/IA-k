using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjOrVar : MonoBehaviour
{
    Canvas[] GameUICanvas = new Canvas[3];
    public Canvas[] NewGameUI = new Canvas[7];
    int pageNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameUICanvas[0] = GameObject.Find("GameCommonUI").GetComponent<Canvas>();
        GameUICanvas[1] = GameObject.Find("CommonUI").GetComponent<Canvas>();
        GameUICanvas[2] = GameObject.Find("AskingBar").GetComponent<Canvas>();
        NewGameUI[0] = GameObject.Find("GameCommonUINew").GetComponent<Canvas>();//Main
        NewGameUI[1] = GameObject.Find("Procedure1Canvas").GetComponent<Canvas>();//Procedure1
        NewGameUI[2] = GameObject.Find("Procedure2Canvas").GetComponent<Canvas>();//Procedure2
        NewGameUI[3] = GameObject.Find("Procedure3Canvas").GetComponent<Canvas>();//Procedure3
        NewGameUI[4] = GameObject.Find("Procedure4Canvas").GetComponent<Canvas>();//Procedure4
        NewGameUI[5] = GameObject.Find("Procedure5Canvas").GetComponent<Canvas>();//Procedure5,For wrong label/AWB/DGD
        NewGameUI[6] = GameObject.Find("CheckList").GetComponent<Canvas>();//checkList for each item after checking?
        //NewGameUI[7] = GameObject.Find("FinishLevel").GetComponent<Canvas>();//Finish a level
    }
    public void NextPage()
    {
        //if(pageNum != pagemaxnum)
        NewGameUI[pageNum].enabled = false;
        NewGameUI[pageNum+1].enabled = true;
        pageNum++;
    }
    public void BackPage()
    {
        if(pageNum!=1)
        {
            NewGameUI[pageNum].enabled = false;
            NewGameUI[pageNum - 1].enabled = true;
            pageNum--;
        }

    }

}
