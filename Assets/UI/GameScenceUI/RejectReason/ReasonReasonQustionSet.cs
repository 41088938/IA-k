using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class ReasonReasonQustionSet : MonoBehaviour
{
    [SerializeField] string[] packageRection1;//REQ

    [SerializeField] string[] awbRection1;//REQ

    [SerializeField] string[] dgdRection1;//REQ


    [SerializeField] Text[] packageTogglText;

    [SerializeField] Text[] awbTogglText;

    [SerializeField] Text[] dgdTogglText;

    [SerializeField] AnserControler ac_controler;
    [SerializeField] DocControl dc_controler;


    [SerializeField] GameObject[] packages;
    [SerializeField] GameObject[] wab;
    [SerializeField] GameObject[] dgd;

    private GameObject cerentPackage;
    private GameObject cerentAWB;
    private GameObject cerentDGD;

    private bool correctRectionPackage=false;
    private bool correctRectioncerentAWB=false;
    private bool correctRectioncerentDGD = false;


    private string packageCorrectAnser;
    private string packageCorrectAWB;
    private string packageCorrectDGD;

    private bool noReject = true;
    

    private void Update()
    {
        cerentPackage = ac_controler.GetCrentBox();
        if (cerentPackage = packages[2])
        {
            QForREQIncorrect();
        }
        else if (cerentPackage = packages[0]) {

            QForRadioIncorrect();


        }
        else if (cerentPackage = packages[1])
        {
            QForNonDGIncorrect();
        }
        cerentAWB = dc_controler.GetCrentWaybillDoc();
        if (cerentAWB == wab[4])
        {

        }
        cerentDGD = dc_controler.GetCrentSipperDoc();
        if (cerentDGD == null) 
        {
            correctRectioncerentDGD=true;
            Debug.Log("no DGD rejection");
        }
    }


    public void QForREQIncorrect()
    {
        for(int i = 0; i < 3; i++)
        {
            packageTogglText[i].text = packageRection1[i];
            awbTogglText[i].text = awbRection1[i];
            dgdTogglText[i].text = dgdRection1[i];
        }
    }
    public void QForRadioIncorrect()
    {
        for (int i = 0; i < 3; i++)
        {
            packageTogglText[i].text = packageRection1[i];
            awbTogglText[i].text = awbRection1[i];
            dgdTogglText[i].text = dgdRection1[i];
        }
        packageCorrectAnser = packageRection1[0];
        packageCorrectAWB= awbRection1[0];
        packageCorrectDGD = dgdRection1[0];
    }
    public void QForNonDGIncorrect()
    {
        for (int i = 0; i < 3; i++)
        {
            packageTogglText[i].text = packageRection1[i];
            awbTogglText[i].text = awbRection1[i];
            dgdTogglText[i].text = dgdRection1[i];
        }
    }
    public bool CorrectRejectRection()
    {
        if (!noReject)
        {
            if (correctRectionPackage == true)
            {
                Debug.Log("CorrectRejectRection()correctRectionPackage=Pass");

                if (correctRectioncerentAWB == true)
                {
                    Debug.Log("CorrectRejectRection()correctRectioncerentAWB=Pass");

                    if (correctRectioncerentDGD == true)
                    {
                        Debug.Log("CorrectRejectRection()All=true");
                        return true;
                        

                    }
                }
             }        

            
        }
        Debug.Log("NonRjection");

        return false;
        
    }
}
