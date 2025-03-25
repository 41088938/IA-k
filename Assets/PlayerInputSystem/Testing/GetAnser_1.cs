using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug=UnityEngine.Debug;

//working on anser changing
public class GetAnser_1 : MonoBehaviour
{
    [SerializeField] GameObject rotationCube;

    #region SelectionAreaVariables
    private GameObject sLighter1;
    private GameObject sLighter2;
    private GameObject sLighter3;
    private GameObject sLighter4;
    private GameObject sLighter5;
    private GameObject sLighter6;
    private GameObject sLighter7;
    private GameObject sLighter8;
    private GameObject sLighter9;
    private GameObject sLighter10;
    private GameObject sLighter11;
    private GameObject sLighter12;
    private GameObject sLighter13;
    private GameObject sLighter14;
    private GameObject sLighter15;
    private GameObject lighter16;
    private GameObject lighter17;
    private GameObject lighter18;
    private GameObject lighter19;
    private GameObject lighter20;

    private GameObject positionLighter1;
    private GameObject positionLighter2;
    private GameObject positionLighter3;
    private GameObject positionLighter4;
    private GameObject positionLighter5;
    private GameObject positionLighter6;
    private GameObject positionLighter7;//tester Shipment


    #endregion

    #region counter
   [SerializeField] private int allBox=5;//change stage total boxs number
    private int OfferCorrectAnser;//change total aner number
    private int totleCorrectAnser=0;
    private int worngAnserCounter = 0;

    private bool anserIsCorrected=false;



    #endregion
    
    [SerializeField] AnserControler ac_controler;

    [SerializeField]
    InputField_WordSelection_Control iFWS_controler;

    #region askingBar infoBar
    [SerializeField] InfoBarReset InfoBarContoler;
    [SerializeField]GameObject[] missingInfoPage;
   
    [SerializeField] Toggle[] lables;
    //[SerializeField] private Text missingInfoPageNumber;

    /* //beginerLeve Cagers
     [SerializeField] GameObject cager1_corr;
     [SerializeField] GameObject cager2_corr;
     [SerializeField] GameObject cager3;
     [SerializeField] GameObject cager4;
     [SerializeField]GameObject cager5;
     //*/
    private GameObject crentCager;

    
    //[SerializeField] Button missing;
    //[SerializeField] Animator missingINfoBar;
    #endregion
    [SerializeField] GameObject stageComplectUI;
    #region askingBar under
    [SerializeField] GameObject askingBar;

  
    [SerializeField] Text askingBarQSelect;
    [SerializeField] Text askingBarQCancel;


    [SerializeField] Button shipmentYes;
    [SerializeField] Button wayBillYes;
    [SerializeField] Button stickerYes;
    [SerializeField] Button sticker2Yes;
    [SerializeField] Button sticker3Yes;
    [SerializeField] Button sticker4Yes;
    [SerializeField] Button sticker5Yes;

    #endregion

    //[SerializeField] BookControler book_contor;

    [SerializeField] LivePointController LPController;
    [SerializeField] GameCommonUIManager gCUIManger;

    [SerializeField] Text score;


    [SerializeField] GameObject[] nonDGIncorrAnser;
    [SerializeField] GameObject[] nonDGIncorrPosAnser;
    
    [SerializeField] GameObject[] nonDGCorrectAnser;
    [SerializeField]GameObject[] nonDGCorrectPosAnser;

    [SerializeField] GameObject[] nonRAdioCorrAnser;
    [SerializeField] GameObject[] nonRadioCorrPosAnser;

    [SerializeField]GameObject[] nonRadioIncorrAnser;
    [SerializeField]GameObject[] nonRadioIncorPosAnser;

    [SerializeField]GameObject[] rEQIncorrAnser;
    [SerializeField]GameObject[] rEQIncorPosAnser;

    [SerializeField] GameObject[] rEQCorrAnser;
    [SerializeField] GameObject[] rEQCorrPOsAnser;

    [SerializeField]
    BookZoomFieldController bZoom_controler;
    [SerializeField ]Animator van_animator;
    
    [SerializeField] DocDetector docD_dector;
    private int point=0;

    private bool uiOn = false;
    
   
    public void Start() {
      
       
        ac_controler.StartGetAnser();
        for (int i = 0; i < lables.Length; i++)
        {

            lables[i].onValueChanged.AddListener(delegate { ChangeMissingLable(); });
            // Add a listener to the toggle to call UpdateObjectState when toggled
        }
        resetmissingInformation();

        //book_contor.ResetBook();
        //package=GameObject.FindGameObjectWithTag("package");
        getPackageVariables();
        
        //Debug.Log("sLighter1:"+sLighter1.name);
        askingBar.SetActive(false);
        PlayerPrefs.SetInt("boxComplection",0);
        Debug.Log("box Complection"+PlayerPrefs.GetInt("boxComplection"));
        stageComplectUI.SetActive(false);
        point = 0;
        //anserManager.showAnser();

        docD_dector.DocUpdate();


        anserIsCorrected = false;
        score.text="Score :"+Mathf.Ceil(point).ToString("00");
       

    }
   

    void Update()
    {
        

        if (!uiOn)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.transform.tag == "WrongAnser")
                    {
                        switch (hit.transform.name)
                        {
                            case "Anser1":

                                if (sLighter1.active == false)
                                {
                                    sLighter1.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter1.active == true)
                                {
                                    sLighter1.SetActive(false);
                                    worngAnserCounter--;

                                }

                                break;
                            case "Anser2":
                                if (sLighter2.active == false)
                                {
                                    sLighter2.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter2.active == true)
                                {
                                    sLighter2.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser3":
                                if (sLighter3.active == false)
                                {
                                    sLighter3.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter3.active == true)
                                {
                                    sLighter3.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser4":
                                if (sLighter4.active == false)
                                {
                                    sLighter4.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter4.active == true)
                                {
                                    sLighter4.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser5":
                                if (sLighter5.active == false)
                                {
                                    sLighter5.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter5.active == true)
                                {
                                    sLighter5.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser6":
                                if (sLighter6.active == false)
                                {
                                    sLighter6.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter6.active == true)
                                {
                                    sLighter6.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser7":
                                if (sLighter7.active == false)
                                {
                                    sLighter7.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter7.active == true)
                                {
                                    sLighter7.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser8":
                                if (sLighter8.active == false)
                                {
                                    sLighter8.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter8.active == true)
                                {
                                    sLighter8.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser9":
                                if (sLighter9.active == false)
                                {
                                    sLighter9.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter9.active == true)
                                {
                                    sLighter9.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser10":
                                if (sLighter10.active == false)
                                {
                                    sLighter10.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter10.active == true)
                                {
                                    sLighter10.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser11":
                                if (sLighter11.active == false)
                                {
                                    sLighter11.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter11.active == true)
                                {
                                    sLighter11.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser12":
                                if (sLighter12.active == false)
                                {
                                    sLighter12.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter12.active == true)
                                {
                                    sLighter12.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser13":
                                if (sLighter13.active == false)
                                {
                                    sLighter13.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter13.active == true)
                                {
                                    sLighter13.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser14":
                                if (sLighter14.active == false)
                                {
                                    sLighter14.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter14.active == true)
                                {
                                    sLighter14.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser15":
                                if (sLighter15.active == false)
                                {
                                    sLighter15.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (sLighter15.active == true)
                                {
                                    sLighter15.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser16":
                                if (lighter16.active == false)
                                {
                                    lighter16.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (lighter16.active == true)
                                {
                                    lighter16.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser17":
                                if (lighter17.active == false)
                                {
                                    lighter17.SetActive(true);
                                    worngAnserCounter++;
                                }
                                else if (lighter17.active == true)
                                {
                                    lighter17.SetActive(false);
                                    worngAnserCounter--;

                                }
                                break;
                            case "Anser18":
                                if (lighter18.active == false)
                                {
                                    lighter18.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter18.active == true)
                                {
                                    lighter18.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser19":
                                if (lighter19.active == false)
                                {
                                    lighter19.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter19.active == true)
                                {
                                    lighter19.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;

                            case "Anser20":
                                if (lighter20.active == false)
                                {
                                    lighter20.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter20.active == true)
                                {
                                    lighter20.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;


                            case "Shipment":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(true);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);
                                break;
                            case "WayBill":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(true);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);
                                break;
                            case "Sticker":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(true);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);

                                break;
                            case "Sticker2":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(true);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);

                                break;
                            case "Sticker3":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(true);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);

                                break;
                            case "Sticker4":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(true);
                                sticker5Yes.gameObject.SetActive(false);
                                Debug.Log("hited=" + name);
                                break;
                            case "Sticker5":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(true);
                                Debug.Log("hited=" + name);
                                break;


                        }
                    }
                    if (hit.transform.tag == "CorrectAnser")
                    {
                        switch (hit.transform.name)
                        {

                            case "Anser1":
                                totleCorrectAnser++;
                                if (sLighter1.active == false)
                                {
                                    sLighter1.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter1.active == true)
                                {
                                    sLighter1.SetActive(false);
                                    totleCorrectAnser--;

                                }

                                break;
                            case "Anser2":
                                if (sLighter2.active == false)
                                {
                                    sLighter2.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter2.active == true)
                                {
                                    sLighter2.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser3":
                                if (sLighter3.active == false)
                                {
                                    sLighter3.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter3.active == true)
                                {
                                    sLighter3.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser4":
                                if (sLighter4.active == false)
                                {
                                    sLighter4.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter4.active == true)
                                {
                                    sLighter4.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser5":
                                if (sLighter5.active == false)
                                {
                                    sLighter5.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter5.active == true)
                                {
                                    sLighter5.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser6":
                                if (sLighter6.active == false)
                                {
                                    sLighter6.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter6.active == true)
                                {
                                    sLighter6.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser7":
                                if (sLighter7.active == false)
                                {
                                    sLighter7.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter7.active == true)
                                {
                                    sLighter7.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser8":
                                if (sLighter8.active == false)
                                {
                                    sLighter8.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter8.active == true)
                                {
                                    sLighter8.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser9":
                                if (sLighter9.active == false)
                                {
                                    sLighter9.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter9.active == true)
                                {
                                    sLighter9.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser10":
                                if (sLighter10.active == false)
                                {
                                    sLighter10.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter10.active == true)
                                {
                                    sLighter10.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser11":
                                if (sLighter11.active == false)
                                {
                                    sLighter11.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter11.active == true)
                                {
                                    sLighter11.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser12":
                                if (sLighter12.active == false)
                                {
                                    sLighter12.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter12.active == true)
                                {
                                    sLighter12.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser13":
                                if (sLighter13.active == false)
                                {
                                    sLighter13.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter13.active == true)
                                {
                                    sLighter13.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser14":
                                if (sLighter14.active == false)
                                {
                                    sLighter14.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter14.active == true)
                                {
                                    sLighter14.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser15":
                                if (sLighter15.active == false)
                                {
                                    sLighter15.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (sLighter15.active == true)
                                {
                                    sLighter15.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;

                            case "Anser16":
                                if (lighter16.active == false)
                                {
                                    lighter16.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter16.active == true)
                                {
                                    lighter16.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser17":
                                if (lighter17.active == false)
                                {
                                    lighter17.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter17.active == true)
                                {
                                    lighter17.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser18":
                                if (lighter18.active == false)
                                {
                                    lighter18.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter18.active == true)
                                {
                                    lighter18.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser19":
                                if (lighter19.active == false)
                                {
                                    lighter19.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter19.active == true)
                                {
                                    lighter19.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;
                            case "Anser20":
                                if (lighter20.active == false)
                                {
                                    lighter20.SetActive(true);
                                    totleCorrectAnser++;
                                }
                                else if (lighter20.active == true)
                                {
                                    lighter20.SetActive(false);
                                    totleCorrectAnser--;

                                }
                                break;

                            case "Shipment":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(true);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                break;
                            case "WayBill":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(true);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);
                                break;
                            case "Sticker":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(true);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);

                                break;

                            case "Sticker2":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(true);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);

                                break;
                            case "Sticker3":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(true);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(false);


                                break;
                            case "Sticker4":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(true);
                                sticker5Yes.gameObject.SetActive(false);


                                break;
                            case "Sticker5":
                                Time.timeScale = 0;
                                AskingBar();
                                shipmentYes.gameObject.SetActive(false);
                                wayBillYes.gameObject.SetActive(false);
                                stickerYes.gameObject.SetActive(false);
                                sticker2Yes.gameObject.SetActive(false);
                                sticker3Yes.gameObject.SetActive(false);
                                sticker4Yes.gameObject.SetActive(false);
                                sticker5Yes.gameObject.SetActive(true);
                                break;




                        }



                    }

                }
            }

            //Debug.Log("boxComplection: "+PlayerPrefs.GetInt("boxComplection"));
        }


            
        
    }
    public void getPackageVariables()
    {

        
       // CagerRandomOutPut(CagerRandom());//get crent box;


        if(ac_controler.GetCrentBox() == ac_controler.cager1_corr) {  //cage REQCorr  
            sLighter1 = rEQCorrAnser[0];
            sLighter1.SetActive(false);
            //Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = rEQCorrAnser[1];
            sLighter2.SetActive(false);
           // Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = rEQCorrAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = rEQCorrAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = rEQCorrAnser[4];
            sLighter5.SetActive(false);
            sLighter6 = rEQCorrAnser[5];
            sLighter6.SetActive(false);
            sLighter7 = rEQCorrAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = rEQCorrAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = rEQCorrAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = rEQCorrAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = rEQCorrAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = rEQCorrAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = rEQCorrAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = rEQCorrAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = rEQCorrAnser[14];
            sLighter15.SetActive(false);
            lighter16 = rEQCorrAnser[15];
            lighter16.SetActive(false);
            lighter17 = rEQCorrAnser[16];
            lighter17.SetActive(false);
            lighter18 = null;
            lighter19 = null;

            positionLighter1 = rEQCorrPOsAnser[0];
           // Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = rEQCorrPOsAnser[1];
            positionLighter2.SetActive(false);
           // Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = rEQCorrPOsAnser[2];
            positionLighter3.SetActive(false);
            //Debug.Log("position light3:" + positionLighter3.name);
          /*  positionLighter4 = null;

            positionLighter5 = null;
            positionLighter6 = null;*/

            totleCorrectAnser = 0;
            worngAnserCounter = 0;
            OfferCorrectAnser = 0;
        }
        else if (ac_controler.GetCrentBox() == ac_controler.cager2_corr)//nonRadiocorr
        {
            sLighter1 = nonRAdioCorrAnser[0];
            sLighter1.SetActive(false);
          //  Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = nonRAdioCorrAnser[1];
            sLighter2.SetActive(false);
           // Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = nonRAdioCorrAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = nonRAdioCorrAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = nonRAdioCorrAnser[4];
            sLighter5.SetActive(false);
            sLighter6 = nonRAdioCorrAnser[5];
            sLighter6.SetActive(false);
            sLighter7 = nonRAdioCorrAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = nonRAdioCorrAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = nonRAdioCorrAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = nonRAdioCorrAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = nonRAdioCorrAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = nonRAdioCorrAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = nonRAdioCorrAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = nonRAdioCorrAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = nonRAdioCorrAnser[14];
            sLighter15.SetActive(false);
            lighter16 = nonRAdioCorrAnser[15];
            lighter16.SetActive(false);
            lighter17 = nonRAdioCorrAnser[16];
            lighter17.SetActive(false);
            lighter18 = nonRAdioCorrAnser[17];
            lighter18.SetActive(false);
            lighter19 = null;

            positionLighter1 = nonRadioCorrPosAnser[0];
            //Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = nonRadioCorrPosAnser[1];
            positionLighter2.SetActive(false);
           // Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = nonRadioCorrPosAnser[2];
            positionLighter3.SetActive(false);
           // Debug.Log("position light3:" + positionLighter3.name);
            positionLighter4 = nonRadioCorrPosAnser[3];
            positionLighter4.SetActive(false);
           // Debug.Log("position light4:" + positionLighter4.name);
            positionLighter5 = nonRadioCorrPosAnser[4];
            positionLighter5.SetActive(false);
           // Debug.Log("position light5:" + positionLighter5.name);
            positionLighter6 = nonRadioCorrPosAnser[5];
            positionLighter6.SetActive(false);
            //Debug.Log("position light6:" + positionLighter6.name);

            positionLighter7 = nonRadioCorrPosAnser[6];
            positionLighter7.SetActive(false);
           // Debug.Log("position light7:" + positionLighter7.name);

            totleCorrectAnser = 0;
            worngAnserCounter = 0;
            OfferCorrectAnser = 0;
        }
        else if (ac_controler.GetCrentBox() == ac_controler.cager3)//incorrect box Radio
        {
            sLighter1 = nonRadioIncorrAnser[0];
            sLighter1.SetActive(false);
           // Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = nonRadioIncorrAnser[1];
            sLighter2.SetActive(false);
            //Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = nonRadioIncorrAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = nonRadioIncorrAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = nonRadioIncorrAnser[4];
            sLighter5.SetActive(false);
            sLighter6 = nonRadioIncorrAnser[5];
            sLighter6.SetActive(false);
            sLighter7 = nonRadioIncorrAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = nonRadioIncorrAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = nonRadioIncorrAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = nonRadioIncorrAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = nonRadioIncorrAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = nonRadioIncorrAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = nonRadioIncorrAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = nonRadioIncorrAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = nonRadioIncorrAnser[14];
            sLighter15.SetActive(false);
            lighter16 = nonRadioIncorrAnser[15];
            lighter16.SetActive(false);
            lighter17 = nonRadioIncorrAnser[16];
            lighter17.SetActive(false);
            lighter18 = nonRadioIncorrAnser[17];
            lighter18.SetActive(false);
            lighter19 = null;
            lighter20 = null;

            positionLighter1 =nonRadioIncorPosAnser[0];
           // Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = nonRadioIncorPosAnser[1];
            positionLighter2.SetActive(false);
          //  Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = nonRadioIncorPosAnser[2];
            positionLighter3.SetActive(false);
          //  Debug.Log("position light3:" + positionLighter3.name);
            positionLighter4 = nonRadioIncorPosAnser[3];
            positionLighter4.SetActive(false);
           // Debug.Log("position light4:" + positionLighter4.name);
            positionLighter5 = nonRadioIncorPosAnser[4];
            positionLighter5.SetActive(false);
            //Debug.Log("position light5:" + positionLighter5.name);

            /*positionLighter5 = null;
             positionLighter6 = null;*/



            totleCorrectAnser = 0;
            worngAnserCounter = 0;
            OfferCorrectAnser = 2;
        }
        else if(ac_controler.GetCrentBox() == ac_controler.cager4)//nonDGIncorr
        {
            sLighter1 = nonDGIncorrAnser[0];
            sLighter1.SetActive(false);
          //  Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = nonDGIncorrAnser[1];
            sLighter2.SetActive(false);
           // Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = nonDGIncorrAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = nonDGIncorrAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = nonDGIncorrAnser[4] ;
            sLighter5.SetActive(false);
            sLighter6 = nonDGIncorrAnser[5]; ;
            sLighter6.SetActive(false);
            sLighter7 = nonDGIncorrAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = nonDGIncorrAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = nonDGIncorrAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = nonDGIncorrAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = nonDGIncorrAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = nonDGIncorrAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = nonDGIncorrAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = nonDGIncorrAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = nonDGIncorrAnser[14];
            sLighter15.SetActive(false);
            lighter16 = nonDGIncorrAnser[15];
            lighter16.SetActive(false);
            lighter17 = nonDGIncorrAnser[16];
            lighter17.SetActive(false);
            lighter18 = nonDGIncorrAnser[17];
            lighter18.SetActive(false);
            lighter19 = nonDGIncorrAnser[18];
            lighter19.SetActive(false);
            lighter20 = null;
            positionLighter1 = nonDGIncorrPosAnser[0];
            Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = nonDGIncorrPosAnser[1];
            positionLighter2.SetActive(false);
            Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = nonDGIncorrPosAnser[2];
            positionLighter3.SetActive(false);
            Debug.Log("position light3:" + positionLighter3.name);
            positionLighter4 = nonDGIncorrPosAnser[3];
            positionLighter4.SetActive(false);
            Debug.Log("position light4:" + positionLighter4.name);
            
          /*  positionLighter5 = null;
            positionLighter6 = null;*/
          
            totleCorrectAnser = 1;
            worngAnserCounter = 0;
            OfferCorrectAnser = 0;
        }
        else if(ac_controler.GetCrentBox() == ac_controler.cager5) {//REQIncorr
            sLighter1 = rEQIncorrAnser[0];
            sLighter1.SetActive(false);
          //  Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = rEQIncorrAnser[1];
            sLighter2.SetActive(false);
          //  Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = rEQIncorrAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = rEQIncorrAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = rEQIncorrAnser[4];
            sLighter5.SetActive(false);
            sLighter6 = rEQIncorrAnser[5];
            sLighter6.SetActive(false);
            sLighter7 = rEQIncorrAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = rEQIncorrAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = rEQIncorrAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = rEQIncorrAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = rEQIncorrAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = rEQIncorrAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = rEQIncorrAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = rEQIncorrAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = rEQIncorrAnser[14];
            sLighter15.SetActive(false);
            lighter16 = rEQIncorrAnser[15];
            lighter16.SetActive(false);
            lighter17 = rEQIncorrAnser[16];
            lighter17.SetActive(false);
            lighter18 = null;
            lighter19 = null;
            lighter20 = null;
            positionLighter1 = rEQIncorPosAnser[0];
          //  Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = rEQIncorPosAnser[1];
            positionLighter2.SetActive(false);
          //  Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = rEQIncorPosAnser[2];
            positionLighter3.SetActive(false);
           // Debug.Log("position light3:" + positionLighter3.name);
            
            positionLighter5 = null;
            positionLighter6 = null;


            totleCorrectAnser = 0;
            worngAnserCounter = 0;
            OfferCorrectAnser = 1;
        }
        else if (ac_controler.GetCrentBox() == ac_controler.cager6_corr)//nonDG_corr
        {
            sLighter1 = nonDGCorrectAnser[0];
            sLighter1.SetActive(false);
            Debug.Log("sLighter1:" + sLighter1.name);
            sLighter2 = nonDGCorrectAnser[1];
            sLighter2.SetActive(false);
            Debug.Log("sLighter2:" + sLighter2.name);

            sLighter3 = nonDGCorrectAnser[2];
            sLighter3.SetActive(false);
            sLighter4 = nonDGCorrectAnser[3];
            sLighter4.SetActive(false);
            sLighter5 = nonDGCorrectAnser[4];
            sLighter5.SetActive(false);
            sLighter6 = nonDGCorrectAnser[5]; ;
            sLighter6.SetActive(false);
            sLighter7 = nonDGCorrectAnser[6];
            sLighter7.SetActive(false);
            sLighter8 = nonDGCorrectAnser[7];
            sLighter8.SetActive(false);
            sLighter9 = nonDGCorrectAnser[8];
            sLighter9.SetActive(false);

            sLighter10 = nonDGCorrectAnser[9];
            sLighter10.SetActive(false);
            sLighter11 = nonDGCorrectAnser[10];
            sLighter11.SetActive(false);
            sLighter12 = nonDGCorrectAnser[11];
            sLighter12.SetActive(false);
            sLighter13 = nonDGCorrectAnser[12];
            sLighter13.SetActive(false);
            sLighter14 = nonDGCorrectAnser[13];
            sLighter14.SetActive(false);
            sLighter15 = nonDGCorrectAnser[14];
            sLighter15.SetActive(false);
            lighter16 = nonDGCorrectAnser[15];
            lighter16.SetActive(false);
            lighter17 = nonDGCorrectAnser[16];
            lighter17.SetActive(false);
            lighter18 = nonDGCorrectAnser[17];
            lighter18.SetActive(false);
            lighter19 = nonDGCorrectAnser[18];
            lighter19.SetActive(false);
            lighter20 = nonDGCorrectAnser[19];
            lighter20.SetActive(false);

            positionLighter1 = nonDGCorrectPosAnser[0];
            Debug.Log("position light1:" + positionLighter1.name);
            positionLighter1.SetActive(false);
            positionLighter2 = nonDGCorrectPosAnser[1];
            positionLighter2.SetActive(false);
            Debug.Log("position light2:" + positionLighter2.name);
            positionLighter3 = nonDGCorrectPosAnser[2];
            positionLighter3.SetActive(false);
            Debug.Log("position light3:" + positionLighter3.name);
            positionLighter4 = nonDGCorrectPosAnser[3];
            positionLighter4.SetActive(false);
            Debug.Log("position light4:" + positionLighter4.name);

            /*  positionLighter5 = null;
              positionLighter6 = null;*/

            totleCorrectAnser = 0;
            worngAnserCounter = 0;
            OfferCorrectAnser = 0;
        }
        else if (ac_controler.GetCrentBox() == null)
        {
            Debug.Log("Error!!! cager not find!!!");
        }
        ac_controler.SetCrentBox(true);
        GameObject cBname = ac_controler.GetCrentBox();

        iFWS_controler.InputFieldButtonTextControl();
       

        docD_dector.DocUpdate();

        rotationCube.transform.eulerAngles = Vector3.zero;

        Debug.Log("Active Cager=" + cBname.name);
             
       

    }
    [SerializeField] DocMissingInfo_Controler dmc_controler;
    [SerializeField] InputField_WordSelection_Control ifwsc_controler;
    [SerializeField] GameObject procedureUI;
    public void Submition()
    {
        dmc_controler.CheckInputAnser();
       
        if (dmc_controler.CheckInputAnser() == true){
            Debug.Log("CheckINputAnser" + dmc_controler.CheckInputAnser());


            if (ifwsc_controler.CheckInputFieldToogle() == true) { 
                Debug.Log("CheckINputAnserPage2" + ifwsc_controler.CheckInputFieldToogle());

                Debug.Log("TotalOfficeAnser" + OfferCorrectAnser + "|| SelectAnser " + totleCorrectAnser);

                if (totleCorrectAnser >= OfferCorrectAnser)
                {

                    Debug.Log("TotalOfficeAnser" + OfferCorrectAnser+"|| SelectAnser "+ totleCorrectAnser);

                    if (worngAnserCounter == 0)
                    {

                        Debug.Log("WrongAnser" + worngAnserCounter);


                        anserIsCorrected = true;
                        if (anserIsCorrected)
                        {
                            ac_controler.SetCrentBox(false);
                            procedureUI.SetActive(false);

                            //   Debug.Log("point="+point);

                            int x = PlayerPrefs.GetInt("boxComplection");
                            x += 1;
                            PlayerPrefs.SetInt("boxComplection", x);
                            Debug.Log("boxComplection" + PlayerPrefs.GetInt("boxComplection"));

                            point = point + 5;
                            PlayerPrefs.SetInt("TotleScore", point);
                            Debug.Log("TotleScore" + PlayerPrefs.GetInt("TotleScore"));

                            score.text = "Score: " + PlayerPrefs.GetInt("TotleScore").ToString("00");
                            InfoBarContoler.resteMissinginformation();
                            resetmissingInformation();
                           // missingINfoBar.Play("AskingBar_Animation_In");
                            bZoom_controler.OutZoomVeiw();
                            van_animator.Play("close");

                            Debug.Log("GetCrentCatNumber=" + ac_controler.GetCrentCatNumber());


                            if (PlayerPrefs.GetInt("boxComplection") == allBox)
                            {
                                gCUIManger.StageClear();

                            }
                            else
                            {


                                ac_controler.updateCrentCager();

                                //getRandomCager();

                                getPackageVariables();
                                //book_contor.ResetBook();
                                dmc_controler.ResetDocMissing();
                                ifwsc_controler.ResetMissingInputToggle();
                                gCUIManger.resetCheckList();
                                gCUIManger.showAnser();


                            }
                            anserIsCorrected = false;
                        }


                    }
                    else
                    {
                        LPController.MissSubmition();
                    }
                }
                else
                {
                    LPController.MissSubmition();
                }
            }
            else
            {
                LPController.MissSubmition();
            }
        } else
        {
            LPController.MissSubmition();
        }

    }

    #region positionLighter

    public void AskingBar()//control the qustion bar qustion
    {
        
        if (positionLighter1.active == true)//will add more position lighter
        {
            askingBarQCancel.gameObject.SetActive(true);

        }
        else if (positionLighter2.active == true)
        {
            askingBarQCancel.gameObject.SetActive(true);

        }
        else if (positionLighter3.active == true)
        {
            askingBarQCancel.gameObject.SetActive(true);
        }
        else if(positionLighter4!=null&&positionLighter4.active == true)
        {
            askingBarQCancel.gameObject.SetActive(true);
        }
        else if (positionLighter5!=null&&positionLighter5.active == true)
        {
            askingBarQCancel.gameObject.SetActive(true);
        }
        else if(positionLighter6!=null&&positionLighter6.active == true)
        {
            askingBarQCancel.gameObject.SetActive(true);
        }
        else if (positionLighter7!=null&&positionLighter7.active == true)
         {
                askingBarQCancel.gameObject.SetActive(true);
            }

        else if (positionLighter1.active ==false)
        {
            askingBarQSelect.gameObject.SetActive(true);
        }
        else if(positionLighter2.active == false)
        {
            askingBarQSelect.gameObject.SetActive (true);
        }
        else if (positionLighter3.active == false)
        {
            askingBarQSelect.gameObject.SetActive(true);
        }
        else if (positionLighter4 != null&&positionLighter4.active == false)
        {
            askingBarQSelect.gameObject.SetActive(true);
        }
        else if (positionLighter5 != null && positionLighter5.active == false)
        {
            askingBarQSelect.gameObject.SetActive(true);
        }
        else if (positionLighter6 != null && positionLighter6.active == false)
        {
            askingBarQSelect.gameObject.SetActive(true);
        }
        else if (positionLighter7 != null && positionLighter7.active == false)
            {
            askingBarQSelect.gameObject.SetActive(true);
        }
            askingBar.SetActive(true);
        
      
    }

    public void WrongShipmentPositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);

        if (positionLighter1.active==true)
            {
                positionLighter1.SetActive(false);
                if (positionLighter1.tag == "WrongAnser")
                {

                    worngAnserCounter--;
                }
                else if (positionLighter1.tag == "CorrectAnser")
                {
                    totleCorrectAnser--;
                }
            }
            else if (positionLighter1.active == false)
            {
                positionLighter1.SetActive(true);
                if (positionLighter1.tag == "WrongAnser")
                {

                    worngAnserCounter++;
                }
                else if (positionLighter1.tag == "CorrectAnser")
                {
                    totleCorrectAnser++;
                }


            }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser + "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;


    }
    public void WrongWayBillPositionYes()
    {
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        askingBar.SetActive(false);
        if (positionLighter2.active==true)
        {
            positionLighter2.SetActive(false);
            if (positionLighter2.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter2.tag == "CorrectAnser")
            {
                totleCorrectAnser--;

            }
           
        }
        else if (positionLighter2.active == false)
        {

            positionLighter2.SetActive(true);
            if (positionLighter2.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter2.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }
            



        }
        Debug.Log("totleCorrectAnse: "+totleCorrectAnser);
        Time.timeScale = 1;

    }
    public void StickerPositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        if (positionLighter3.active==true)
        {
            positionLighter3.SetActive(false);
            if (positionLighter3.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter3.tag == "CorrectAnser")
            {
                totleCorrectAnser--;
            }
        }
        else if (positionLighter3.active == false)
        {
            positionLighter3.SetActive(true);
            if (positionLighter3.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter3.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }

        }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser+ "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;

    }

    public void Sticker2PositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);

        if (positionLighter4.active==true)
        {
            positionLighter4.SetActive(false);
            if (positionLighter4.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter4.tag == "CorrectAnser")
            {
                totleCorrectAnser--;
            }
        }
        else if (positionLighter4.active==false)
        {
            positionLighter4.SetActive(true);
            if (positionLighter4.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter4.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }

        }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser + "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;

    }
    public void Sticker3PositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        if (positionLighter5.active==true)
        {
            positionLighter5.SetActive(false);
            if (positionLighter5.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter5.tag == "CorrectAnser")
            {
                totleCorrectAnser--;
            }
        }
      else if (positionLighter5.active==false)
        {
            positionLighter5.SetActive(true);
            if (positionLighter5.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter5.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }

        }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser + "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;

    }
    public void Sticker4PositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        if (positionLighter6.active==true)
        {
            positionLighter6.SetActive(false);
            if (positionLighter6.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter6.tag == "CorrectAnser")
            {
                totleCorrectAnser--;
            }
        }
       else if (positionLighter6.active==false)
        {
            positionLighter6.SetActive(true);
            if (positionLighter6.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter6.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }

        }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser + "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;

    }
    public void Sticker5PositionYes()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        if (positionLighter7.active==true)
        {
            positionLighter7.SetActive(false);
            if (positionLighter7.tag == "WrongAnser")
            {

                worngAnserCounter--;
            }
            else if (positionLighter7.tag == "CorrectAnser")
            {
                totleCorrectAnser--;
            }
        }
        else if (positionLighter7.active == false)
        {
            positionLighter7.SetActive(true);
            if (positionLighter7.tag == "WrongAnser")
            {

                worngAnserCounter++;
            }
            else if (positionLighter7.tag == "CorrectAnser")
            {
                totleCorrectAnser++;
            }

        }
        Debug.Log("totleCorrectAnse: " + totleCorrectAnser + "WorngAnse: " + worngAnserCounter);
        Time.timeScale = 1;

    }
    public void WrongPositionNO()
    {
        askingBar.SetActive(false);
        askingBarQCancel.gameObject.SetActive(false);
        askingBarQSelect.gameObject.SetActive(false);
        Time.timeScale = 1;


    }

    #endregion


    [SerializeField] Rotate3DObject1 r3dc_controler;
    #region MissingBar

    void ChangeMissingLable()
    {
        missingInfoPage[0].SetActive(lables[0].isOn);
       

        missingInfoPage[1].SetActive(lables[1].isOn);
        


    }
    public void MissingLablePress()
    {
        lables[0].isOn=true;
        lables[1].isOn = false;
    }
    public void MissingInfoPress()
    {
        lables[1].isOn = true;
        lables[0].isOn = false;
    }
    public void resetmissingInformation()
    {
        for (int i = 0; i < lables.Length; i++)
        {
            lables[i].isOn=false;
        }
        lables[0].isOn = true;
       
       

    }
    #endregion


    #region Geter Seter 
   public void controlRay(bool OffRaycase)
    {
        uiOn = OffRaycase;
    }

    public bool GetAnserIsCorrected()
    {
        return anserIsCorrected;
    }
    public void setAnserIsCorrected()
    {
        anserIsCorrected = false;
    }
    public void setTotlalCorrectAnser(int x)
    {
        totleCorrectAnser +=x;
    }
    public void setWrongAnser(int x)
    {
        worngAnserCounter += x;
    }
    public int getWrongAnserNum()
    {
        return worngAnserCounter;
    }
    public int getOfficeCorrectAnser()
    {
        return OfferCorrectAnser;
    }
    public int getTotlalCorrectAnser()
    {
        return totleCorrectAnser;
    }

    #endregion

}