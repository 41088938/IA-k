using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonRadioactiveIncorr : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] Toggle neededSelection1;
    [SerializeField]Toggle neededSelection_option;
    [SerializeField] Toggle[] wrongToggl;
    [SerializeField] GameObject nonRadioUPSticker;
    [SerializeField] GetAnser_1 gAS;


    public void ToggleSelection_NonRadiotrue_Option()
    {
        if (box.active == true) { 
            if (neededSelection_option.isOn && nonRadioUPSticker.active==false)
             {
             
           
                gAS.setTotlalCorrectAnser(1);
                
                Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| OfficeCorrectAnser=" + gAS.getOfficeCorrectAnser());
            }
            if (!neededSelection_option.isOn)
            {

                gAS.setTotlalCorrectAnser(-1);
            }

        
         }
    }
    public void ToggleSelection_NonRadioTrue1()
    {
        if (box.active == true ){
        if (neededSelection1.isOn)
        {
            gAS.setTotlalCorrectAnser(1);

                Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| OfficeCorrectAnser=" + gAS.getOfficeCorrectAnser());
            }
        else if (neededSelection1.isOn == false)
        {
            gAS.setTotlalCorrectAnser(-1);
           
        }
    }}
    public void ToggleSelection_NonRadioFalse1()
    {
        if (box.active == true)
        {
           
                if (wrongToggl[0].isOn == true)
                {
                
                    gAS.setWrongAnser(1);
                  
                }
                else if (wrongToggl[0].isOn == false)
            {
                 
                    gAS.setWrongAnser(-1);
                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
                 }

            

           

           

           
            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_NonRadioFalse2()
    {
        if (box.active == true)
        {
            if (wrongToggl[1].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else if (wrongToggl[1].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }

            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());

        } }
    public void ToggleSelection_NonRadioFalse3()
    {
        if (box.active == true)
        {
            if (wrongToggl[2].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else if (wrongToggl[2].isOn == false)
            {

                gAS.setWrongAnser(-1);

                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }
            Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
        }
    }
    public void ToggleSelection_NonRadioFalse4()
    {
        if (box.active == true)
        {

            if (wrongToggl[3].isOn == true)
            {

                gAS.setWrongAnser(1);
                
            }
            else if(wrongToggl[3].isOn == false)
            {
                
                    gAS.setWrongAnser(-1);
                
                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }

        }
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
    }
    public void ToggleSelection_NonRadioFalse5()
    {
        if (box.active == true)
        {
            if (wrongToggl[4].isOn == true)
            {

                gAS.setWrongAnser(1);
                
            }
            else if (wrongToggl[4].isOn == false)
            {
                
                    gAS.setWrongAnser(-1);
                
                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }
        }
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());
    }
    public void ToggleSelection_NonRadioFalse6() {
        if (box.active == true)
        {
            if (wrongToggl[5].isOn == true)
            {

                gAS.setWrongAnser(1);


            }
            else
                if (wrongToggl[5].isOn == false)
            {
                gAS.setWrongAnser(-1);
             
                Debug.Log("WrongAnserCounter=" + gAS.getWrongAnserNum());
            }
            
        }
        Debug.Log("inToggle_CorrectAnser=" + gAS.getTotlalCorrectAnser() + "| WrongAnserCounter=" + gAS.getWrongAnserNum());

    }
}
