using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.HID.HID;
using Toggle = UnityEngine.UI.Toggle;

public class GamePageControler : MonoBehaviour
{
    [SerializeField] GameObject[] pages;//0=s1,1=s2,2=s3,3=s4,4=s5,5=s6
    private GameObject crentPage;
    private int crentPageNumber = -1;
    [SerializeField] GameObject[] gamePageControlerButton;//0=back 1=next

    [SerializeField] Toggle[] procedurStep;//readOnly
    private Toggle crentPOn = null;
    [SerializeField] Toggle[] crentProcedurStep;
    [SerializeField] GameObject questionSpace;
    [SerializeField] BookZoomFieldController bzfc_controler;
    [SerializeField]GetAnser_1 gac_controler;


    private void Start()
    {
        for (int i = 0; i < crentProcedurStep.Length; i++) {

            crentProcedurStep[i].onValueChanged.AddListener(delegate { ChangeStepByList(); });
            // Add a listener to the toggle to call UpdateObjectState when toggled
        } 
        ResetAllGAmePages();
        
       
    }
    public void ResetAllGAmePages()
    {
        questionSpace.SetActive(false);
        crentPageNumber = -1;
        crentPage = null;
        crentPOn = null;
        bzfc_controler.OffRay(true);
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        for (int i = 0; i < procedurStep.Length; i++)
        {
            procedurStep[i].isOn = false;

        }
        for (int i = 0; i < gamePageControlerButton.Length; i++)
        {
            gamePageControlerButton[i].SetActive(false);

        }
        for (int i = 0; i < crentProcedurStep.Length; i++)
        {
            crentProcedurStep[i].isOn = false;

        }
        Debug.Log("GameProcedurReseted");
    }
    public void NextGamePage()
    {
        if (crentPageNumber + 1 <5)
        {
                for (int i = 0; i < pages.Length; i++)
                {
                    pages[i].SetActive(false);
            }
            if (crentPageNumber > -1) { 
                crentProcedurStep[crentPageNumber].isOn = false;
            }
            Debug.Log("crentProcedurStepOff" + "crentGAmePageNumber " + crentPageNumber);

                crentPageNumber += 1;
                crentProcedurStep[crentPageNumber].isOn=true;
                crentPage = pages[crentPageNumber];
                ProcedureToggle(crentPageNumber);
                crentGameButtonCheck();
            

            Debug.Log("crentProcedurStepOn" + "crentGAmePageNumber " + crentPageNumber);
       

                Debug.Log(pages[crentPageNumber].name + " is active" + "||crentGamePage = " + crentPageNumber);
        }

    }
    public void BackGamePage()
    {
        if (crentPageNumber - 1 > -1) { 
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(false);
            }
            if (crentPageNumber > -1)
            {
                crentProcedurStep[crentPageNumber].isOn = false;
            }
            Debug.Log("crentProcedurStepOff" + "crentGAmePageNumber " + crentPageNumber);
            crentPageNumber -= 1;
        
            Debug.Log("crentProcedurStepOn" + "crentGAmePageNumber " + crentPageNumber);
            crentProcedurStep[crentPageNumber].isOn = true;
            crentPage = pages[crentPageNumber];
            ProcedureToggle(crentPageNumber);
            crentGameButtonCheck();
           

            Debug.Log(" is active" + "||crentGamePage = " + crentPageNumber);
        }

    }
    void crentGameButtonCheck()
    {
        if (crentPage != pages[0]&crentPage!= pages[4])//if not on the boxZoomView & the Submition, button Back & color planal wll apear the color planal will apear
        {
            bzfc_controler.OffRay(false);//the ray in Van,off
            gac_controler.controlRay(false);//the ray for box, off
            gac_controler.controlRay(false);
            SetActiveGamePageControler(true);
            questionSpace.SetActive(true);
        }
        else if (crentPage == pages[0])//if on the boxZoomView button Bac k& color planal will disapear
        {
            bzfc_controler.OffRay(false);//the ray in Van,off
            gac_controler.controlRay(true);//the ray for box, on
            questionSpace.SetActive(false);
            gamePageControlerButton[0].SetActive(false);
            gamePageControlerButton[1].SetActive(true);
        }else
        if (crentPage == pages[4])//if on the Submition, button Next & color planal will apear 
        {
            bzfc_controler.OffRay(false);//the ray in Van,off
            gac_controler.controlRay(false);//the ray for box, off
            gac_controler.controlRay(false);
            questionSpace.SetActive(true);
            gamePageControlerButton[1].SetActive(false);
            gamePageControlerButton[0].SetActive(true);
        }
       
    }

    void ChangeStepByList()//page change controler
    {
        
        pages[0].SetActive(crentProcedurStep[0].isOn);//if crentProcedurStep[x] Toggle is on, active the  page[x]
        pages[1].SetActive(crentProcedurStep[1].isOn);
        pages[2].SetActive(crentProcedurStep[2].isOn);
        pages[3].SetActive(crentProcedurStep[3].isOn);
        pages[4].SetActive(crentProcedurStep[4].isOn);
      //  pages[5].SetActive(crentProcedurStep[5].isOn);
       


    }
    public void SetActiveGamePageControler(bool on)
    {
        if (on) { 
            for (int i = 0; i < gamePageControlerButton.Length; i++)
            {
                gamePageControlerButton[i].SetActive(true);
            }
        } else {
            for (int i = 0; i < gamePageControlerButton.Length; i++)
            {
                gamePageControlerButton[i].SetActive(false);
            }

        }
    }
    
    public void SetCrentProcedurStepOn(int a)
    {
        for (int i = 0; i < crentProcedurStep.Length; i++)
        {
            crentProcedurStep[i].isOn = false;

        }
        crentProcedurStep[a].isOn=true;
        crentPageNumber=a;
        crentPage = pages[crentPageNumber];
        crentGameButtonCheck();
        ProcedureToggle(crentPageNumber);
    } 
    void ProcedureToggle(int toughted)
    {
        procedurStep[toughted].isOn=true;

    }

   }
