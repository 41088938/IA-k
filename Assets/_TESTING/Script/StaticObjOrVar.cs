using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StaticObjOrVar : MonoBehaviour
{
    public static Canvas[] NewGameUI = new Canvas[8];
    [SerializeField] Canvas[] reasons = new Canvas[3];
    [SerializeField] Image[] ProcedureIcons;
    int pageNum = 1;
    public bool InProcedure5 = false;
    // Start is called before the first frame update
    void Start()
    {
        NewGameUI[0] = GameObject.Find("GameCommonUINew").GetComponent<Canvas>();//Main
        NewGameUI[1] = GameObject.Find("Procedure1Canvas").GetComponent<Canvas>();//Procedure1
        NewGameUI[2] = GameObject.Find("Procedure2Canvas").GetComponent<Canvas>();//Procedure2
        NewGameUI[3] = GameObject.Find("Procedure3Canvas").GetComponent<Canvas>();//Procedure3
        NewGameUI[4] = GameObject.Find("Procedure4Canvas").GetComponent<Canvas>();//Procedure4
        NewGameUI[5] = GameObject.Find("Procedure5Canvas").GetComponent<Canvas>();//Procedure5,For wrong label/AWB/DGD
        NewGameUI[6] = GameObject.Find("ResultCheckList_Canvas").GetComponent<Canvas>();//checkList for each item after checking?
        NewGameUI[7] = GameObject.Find("FinishLevel").GetComponent<Canvas>();//Finish a level


    }
    public void NextPage()
    {
        if (!InProcedure5)
        {
            if (pageNum != 4)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[pageNum - 1].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum + 1].enabled = true;
                ProcedureIcons[pageNum].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum++;
            }
        }
        else
        {
            if (pageNum != 3 && pageNum !=5)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[pageNum-1].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum + 1].enabled = true;
                ProcedureIcons[pageNum].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum++;
            }
            else if(pageNum == 3 && pageNum !=5)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[2].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum + 2].enabled = true;
                ProcedureIcons[3].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum +=2;
            }
        }

    }
    public void BackPage()
    {
        if (!InProcedure5)
        {
            if (pageNum != 1)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[pageNum - 1].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum - 1].enabled = true;
                ProcedureIcons[pageNum-2].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum--;
            }
        }
        else
        {
            if (pageNum == 5)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[3].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum - 2].enabled = true;
                ProcedureIcons[2].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum -= 2;
                
            }
            else if (pageNum != 1)
            {
                NewGameUI[pageNum].enabled = false;
                ProcedureIcons[pageNum-1].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[1];
                NewGameUI[pageNum - 1].enabled = true;
                ProcedureIcons[pageNum-2].sprite = Resources.LoadAll<Sprite>("Steps/Icons")[2];
                pageNum--;
            }
        }


    }
    public void NotAcceptBtn()
    {
        InProcedure5 = true;
        NewGameUI[4].enabled = false;
        NewGameUI[5].enabled = true;
        pageNum++;
    }
    public void AcceptBtn()
    {
        NewGameUI[pageNum].enabled = false;
    }
    public void packagebtn()
    { 
        reasons[0].enabled = true;
        reasons[1].enabled = false;
        reasons[2].enabled = false;
    }
    public void AWBbtn()
    {
        reasons[0].enabled = false;
        reasons[1].enabled = true;
        reasons[2].enabled = false;
    }
    public void DGDbtn()
    {
        reasons[0].enabled = false;
        reasons[1].enabled = false;
        reasons[2].enabled = true;
    }
    public void OKBtn()
    {
        NewGameUI[5].enabled = false;
        NewGameUI[6].enabled = true;
    }
}
