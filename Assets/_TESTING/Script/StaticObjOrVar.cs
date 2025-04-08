using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjOrVar : MonoBehaviour
{
    Canvas[] GameUICanvas = new Canvas[3];
    public Canvas[] NewGameUI = new Canvas[4];
    int pageNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameUICanvas[0] = GameObject.Find("GameCommonUI").GetComponent<Canvas>();
        GameUICanvas[1] = GameObject.Find("CommonUI").GetComponent<Canvas>();
        GameUICanvas[2] = GameObject.Find("AskingBar").GetComponent<Canvas>();
        NewGameUI[0] = GameObject.Find("GameCommonUINew").GetComponent<Canvas>();//Main
        NewGameUI[1] = GameObject.Find("Procedure1Canvas").GetComponent<Canvas>();//Procedure1
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
