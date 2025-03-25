using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AskingBarMissing_incorrect : MonoBehaviour
{
    [SerializeField] private GameObject[] allCorrectBox;
    [SerializeField] private Toggle[] toggles = new Toggle[8];
    [SerializeField] GetAnser_1 gAS;

    // Update is called once per frame


    public void ToggleSelection_False1()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true|| allCorrectBox[2].active == true|| allCorrectBox[3].active == true|| allCorrectBox[4].active == true)
        {

            if (toggles[0].isOn == true)
            {

                gAS.setWrongAnser(1);

            }
            else if (toggles[0].isOn == false)
            {

                gAS.setWrongAnser(-1);
                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }








            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_False2()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[1].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else if (toggles[1].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }

            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }

    }
    public void ToggleSelection_False3()
    {

        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[2].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else if (toggles[2].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }
            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());

        }
    }
    public void ToggleSelection_False4()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {


            if (toggles[3].isOn == true)
            {

                gAS.setWrongAnser(1);

            }
            else if (toggles[3].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }

        
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
   } 
    }
    public void ToggleSelection_False5()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[4].isOn == true)
            {

                gAS.setWrongAnser(1);

            }
            else if (toggles[4].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }
        
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_False6()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[5].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else
                if (toggles[5].isOn == false)
            {
                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }

       
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_False7()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[6].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else
                if (toggles[6].isOn == false)
            {
                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }


            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_False8()
    {
        if (allCorrectBox[0].active == true || allCorrectBox[1].active == true || allCorrectBox[2].active == true || allCorrectBox[3].active == true || allCorrectBox[4].active == true)
        {
            if (toggles[7].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else
                if (toggles[7].isOn == false)
            {
                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }


            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
}
