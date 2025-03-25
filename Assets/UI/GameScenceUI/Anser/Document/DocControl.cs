using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DocControl : MonoBehaviour
{
    [SerializeField] Toggle[] nonDGCorr_Toggle;
    [SerializeField] Toggle[] nonDGIncorr_Toggle;
    [SerializeField]
    Toggle[] nonDGIncorr_wrong_Toggle;//the toggle needed to select

    [SerializeField] Toggle[] rEQCorr_Toggle;
    [SerializeField] Toggle[] rEQInccorr_Toggle;
    [SerializeField]
    Toggle[] rEQInccorr_Wrong_Toggle;

    [SerializeField] Toggle[] nonRadioCorr_Toggle;
    [SerializeField] Toggle[] nonRadioIncorr_Toggle;
    [SerializeField]
    Toggle[] nonRadioIncorr_Wrong_Toggle;

    [SerializeField] Toggle[] corr_Shipper_Toggle;
    [SerializeField] Toggle[] incorr_Shipper_Toggle;

    [SerializeField] public GameObject[] waybillDoc;
    [SerializeField] public GameObject[] shipperDoc;
    
    private GameObject crentWaybillDoc;// double=Incorr
    private GameObject crentShipperDoc;//double=Incorr
    private int[] crentNum=new int[2];
    

    [SerializeField] private GetAnser_1 ga_controler;
   // [SerializeField] Animator doc_animator;

    [SerializeField] Rotate3DObject1 r3dc_controler;

    [SerializeField] GameObject submitionButton;
    //[SerializeField]GameObject shipper_button;
    // Start is called before the first frame update
    void Start()
    {
        ResetDoc();
       
    }

    #region toggle Controler
    public void ResetDoc()
    {
        for (int i = 0; i < nonDGCorr_Toggle.Length; i++)
        {
            nonDGCorr_Toggle[i].isOn = false;
        }
        for (int i = 0; i < nonDGIncorr_Toggle.Length; i++)
        {
            nonDGIncorr_Toggle[i].isOn = false;
        }


        for (int i = 0; i < rEQCorr_Toggle.Length; i++)
        {
            rEQCorr_Toggle[i].isOn = false;
        }
        for(int i = 0;i < rEQInccorr_Toggle.Length ; i++)
        {
            rEQInccorr_Toggle[i].isOn=false;
        }


        for (int i = 0; i < nonRadioCorr_Toggle.Length; i++)
        {
            nonRadioCorr_Toggle[i].isOn = false;
        }
        for (int i = 0; i < nonRadioIncorr_Toggle.Length; i++)
        {
            nonRadioIncorr_Toggle[i].isOn = false;
        }


        for( int i = 0; i<waybillDoc.Length; i++)
        {
            waybillDoc[i].SetActive(false);
        }
        for (int i = 0; i < shipperDoc.Length; i++)
        {
            shipperDoc[i].SetActive(false);
        }
        for(int i=0; i< corr_Shipper_Toggle.Length; i++)
        {
            corr_Shipper_Toggle[i].isOn=false;

        }
        for(int i = 0; i < incorr_Shipper_Toggle.Length; i++)
        {
            incorr_Shipper_Toggle [i].isOn=false;
        }
        
        r3dc_controler.enabled = true;
        wrongSelected_counter = 0;
        correctedSelected_counter = 0;

    }
    private int correctedSelected_counter=0;
    private int wrongSelected_counter = 0;
    private int offerNeededAnser=0;

    
    public void AddToggleListener()
    {
      //  correctedSelected_counter = 0;
        if (crentWaybillDoc == waybillDoc[0])
        {
            for (int i = 0; i < rEQCorr_Toggle.Length; i++)
            {
                rEQCorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
                
            }
            offerNeededAnser = 0;
        }
        else if (crentWaybillDoc == waybillDoc[1])
        {
            for (int i = 0; i < nonRadioCorr_Toggle.Length; i++)
            {
                nonRadioCorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);

            }

            offerNeededAnser = 0;
            
        }
        else
        if (crentWaybillDoc == waybillDoc[2])
        {
            
            for (int i = 0; i < nonRadioIncorr_Toggle.Length; i++)
            {
                if (nonRadioIncorr_Toggle[i].tag == "CorrectAnser")
                {
                    nonRadioIncorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedCorrect);
                }else
                nonRadioIncorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
                
                
            }offerNeededAnser=1;

        }
        else if (crentWaybillDoc == waybillDoc[3])
        {
            for (int i = 0; i < nonDGIncorr_Toggle.Length; i++)
            {

                nonDGIncorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
                
            }offerNeededAnser=0;

        }
        else if (crentWaybillDoc == waybillDoc[4])
        {
            for (int i = 0; i < rEQInccorr_Toggle.Length; i++)
            {
                rEQInccorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
                
            }
            offerNeededAnser = 0;
        }
        else if (crentWaybillDoc == waybillDoc[5])
        {
            for (int i = 0; i < rEQInccorr_Toggle.Length; i++)
            {
                nonDGCorr_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);

            }
            offerNeededAnser = 0;
        }
        
            
        

            Debug.Log("Crent Doc" + crentWaybillDoc.name);
    }
    void OnToggleValueChangedCorrect(bool isOn)
    {
        int x = 0;
        if (isOn)
        {
            x+=1;
           
        }
        else
        {
            x -= 1;
        }
        correctedSelected_counter += x;
        Debug.Log("correctedSelected_counter" + correctedSelected_counter);
    }

    void OnToggleValueChangedWrong(bool isOn)
    {

        int x = 0;
        if (isOn)
        {
            x += 1;
            Debug.Log("WrongSelected_coun");
        }
        else
        {
            x -= 1;
           
        }
        wrongSelected_counter += x;
        Debug.Log("WrongSelected_counter" + wrongSelected_counter);
    }

    public bool DocToggleAnserCheck()
    {
        if (correctedSelected_counter >= offerNeededAnser)
        { if (wrongSelected_counter == 0) { 
                return true;
            }
            else { return false; } 
        }
        else {  return false; }
    }

    #endregion
    #region document Controler




    public void SetWaybillDocActive(int x)
    {
        crentWaybillDoc = waybillDoc[x];
        crentWaybillDoc.SetActive(true);
        AddToggleListener();
        Debug.Log("Crent Doc" + crentWaybillDoc.name);
    }

    //[SerializeField] GameObject dgdChecklistToggle;
    public void SetShipperDocActive(int x)
    {
        crentShipperDoc = shipperDoc[x];
      //  shipper_button.SetActive(true);
        crentShipperDoc.SetActive(true);
       // dgdChecklistToggle.active = true;
        if (GetCrentSipperDoc() == shipperDoc[0])
        {
            for (int i = 0; i < incorr_Shipper_Toggle.Length; ++i)
            {
                if (incorr_Shipper_Toggle[i].tag == "CorrectAnser")
                    incorr_Shipper_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedCorrect);
                else
                    incorr_Shipper_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
            }
            offerNeededAnser += 1;
        }
        else if (GetCrentSipperDoc() == shipperDoc[1])
        {
            for (int i = 0; i < corr_Shipper_Toggle.Length; i++)
            {
                corr_Shipper_Toggle[i].onValueChanged.AddListener(OnToggleValueChangedWrong);
            }

        }
    }
    [SerializeField] GameObject dgdScoreView;
    public void SetShipperDocOff()
    {
        //  dgdChecklistToggle.active = false;
        //shipper_button.SetActive(false);
        /*for(int i = 0;i < shipperDoc.Length; i++)
        {
            shipperDoc[i].SetActive(false);
        }*/
        dgdScoreView.SetActive(false);
    }

   
   /* public void WrongDoc()
    {
        for (int i = 0; i < crentNum.Length; i++)
        {
            if (crentNum[i] % 2 == 0)
            {
                ga_controler.setWrongAnser(1);
            }
        }
       
    }*/
    public GameObject GetCrentSipperDoc()
    {
        return crentShipperDoc;
    }
    public GameObject GetCrentWaybillDoc()
    {
        return crentWaybillDoc;
    }


    #endregion


    #region on off
    [SerializeField] GameObject vaninside;
    [SerializeField] GameObject zoomFild;
    [SerializeField] BookZoomFieldController bzfc_controler;
   // public void MissingDocOut()
    //{
    //    doc_animator.Play("Doc_Missing_out_animation");
       
        
        
   // }
  //  public void MissingDocIn()
   // {
    //    doc_animator.Play("Doc_Missing_in_animation");
        
   // }
    public void OutDoc()
    {
       // doc_animator.Play("Doc_out_Animation");
        submitionButton.SetActive(true);
        r3dc_controler.enabled = true;
        vaninside.SetActive(true);
        bzfc_controler.OffRay(true);

    }
    public void InDoc()
    {
        submitionButton.SetActive(false);
       // doc_animator.Play("Doc_in_Animation");
        r3dc_controler.enabled = false;
        vaninside.SetActive(false);
        Debug.Log("vaninside= "+vaninside.active);
        bzfc_controler.OffRay(false);


    }
    public void ShipperIn()
    {
      //  doc_animator.Play("Doc_Shipper_in_animation");
        //MissingDocOut();
        //OutDoc();
        //doc_animator.Play("Doc_in_Animation");
        r3dc_controler.enabled = false;
        vaninside.SetActive(false);
        Debug.Log("vaninside= " + vaninside.active);
        bzfc_controler.OffRay(false);

    }
    public void ShipperOut()
    {
       // doc_animator.Play("Doc_Shipper_out_animation");
        submitionButton.SetActive(true);
        r3dc_controler.enabled = true;
        vaninside.SetActive(true);
        bzfc_controler.OffRay(true);
    }

    #endregion

}
