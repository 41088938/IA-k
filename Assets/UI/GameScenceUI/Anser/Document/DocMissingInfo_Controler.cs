using UnityEngine;
using UnityEngine.UI;

public class DocMissingInfo_Controler : MonoBehaviour
{
    //[SerializeField] private Text selectionMissing_text;
    //[SerializeField] AnserControler ac_controler;
   // [SerializeField] string[] selectionMissing_string;
    [SerializeField] DocControl docC_controler;
    [SerializeField] GetAnser_1 ga_controler;
    [SerializeField] private AnserControler ac_controler;
    private bool isAllCorrect = false;

     
   // private int wrongSelected = 0;//selected the Anser is not correct counter
    private int correctSelected = 0;//selected the Anser is correct(able to get though the sumition


  //  private int officeDocCorrectAnserCounter = 0;
 //   private int officeShippmentCorrectAnserCounter = 0;
   // private int officeCorrectAnser = 0;

    [SerializeField] public GameObject prefab; // Assign your prefab in the Inspector
    [SerializeField] public GameObject content; // Assign the Content object of the Scroll View

    int wrongAnserNumber = 0;
    int officeAnserNumber=0;
    int selectedAnserNumber = 0;
    [SerializeField]
    string [] correctAnse;
    [SerializeField] string[] anserText1;
    [SerializeField] string[] anserText2;
    [SerializeField] string[] anserText3;
    [SerializeField] string[] anserText4;
    [SerializeField] string[] anserText5;
    [SerializeField] string[] anserText6;

   // [SerializeField] int optionNumber=3;
    int crageNumber = 0;//REQCorr,RadioCorr,RadioIncorr,DGIncorr,REQIncorr,DGCorr
    
    
    private void Start()
    {
        runed = false;
        ResetDocMissing();
        

    }
    GameObject[] sliderAddedObject ;
    string[] selectableOption = new string[3];
    public void ResetIsAllCorrectDoc()
    {
        isAllCorrect = false;
        Debug.Log("Doc Corret counter Reseted");

    }
private float moveDownWard = 0;
    //int n = 0;
    private bool runed=false;
  
    #region scorllView
    public void GetScorllViewToggle()
    {
        

        runed = true;

        if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[0])
        {
            sliderAddedObject = new GameObject[anserText1.Length];


            for (int i = 0; i < anserText1.Length; i++)
            {

                GameObject newItem = Instantiate(prefab, content.transform);

                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject" + sliderAddedObject[i]);

                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText1[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;

            }
            officeAnserNumber = 0;
        }
        else if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[1])
        {
            sliderAddedObject = new GameObject[anserText2.Length];
            for (int i = 0; i < anserText2.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject"+sliderAddedObject[i]);

                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText2[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
            officeAnserNumber = 0;

        }
        else if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[2])
        {
            sliderAddedObject = new GameObject[anserText4.Length];
            for (int i = 0; i < anserText4.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject"+sliderAddedObject[i]);
                
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText4[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
            officeAnserNumber = 0;
        }
        else if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[3])
        {
            sliderAddedObject = new GameObject[anserText3.Length];
            for (int i = 0; i < anserText3.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject" + sliderAddedObject[i]);

                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText3[i];
                if (itemText.text =="1x2kg")
                {
                    toggle.onValueChanged.AddListener(OnToggleValueChangedCorrect);
                }
                else
                    toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
            officeAnserNumber = 1;

        }
        else if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[4])
        {
            sliderAddedObject = new GameObject[anserText5.Length];
            for (int i = 0; i < anserText5.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);


                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject" + sliderAddedObject[i]);


                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText5[i];
                if (itemText.text == correctAnse[1])
                {
                    toggle.onValueChanged.AddListener(OnToggleValueChangedCorrect);
                }
                else
                    toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
            officeAnserNumber = 1;
        }
        else if (docC_controler.GetCrentWaybillDoc() == docC_controler.waybillDoc[5])
        {
            sliderAddedObject = new GameObject[anserText6.Length];
            for (int i = 0; i < anserText6.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                sliderAddedObject[i] = newItem;
                Debug.Log("sliderAddObject" + sliderAddedObject[i]);

                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = anserText6[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
            officeAnserNumber = 0;
        }


        Debug.Log("DOC OfficeAnseNumber:" + officeAnserNumber);
    }
 


    
   /* public void RemoveScrollViewToggle(GameObject asd)
    {
        if (gameObject != null && gameObject.name != "InputFieldButtonControler")
        {
            Destroy(asd);
            Debug.Log("Remove "+gameObject.name);
        }else Debug.Log("Remove " + null);

    } */
    Text itemText;
    void OnToggleValueChangedCorrect(bool isOn)
    {
       
        int x = 0;
        
            if (isOn)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }
        
        
        correctSelected += x;
        Debug.Log("correctedSelected_counter= " + correctSelected);
    }
    void OnToggleValueChangedWrong(bool isOn)
    {
        int x = 0;


        if (isOn)
        {
            x = 1;
        }
        else
        {
            x =- 1;
        }


        wrongAnserNumber += x;
        Debug.Log("WrongSelected_counter= " + wrongAnserNumber);


    }
    
    public void AddItemToScorllView()
    {
       

        moveDownWard = 0;
       
        
     
        
            
            GetScorllViewToggle();
          
           

       
    }
    #endregion




    public void ResetDocMissing()//reset
    {
        if (runed == true) { 
        if (sliderAddedObject.Length != 0 || sliderAddedObject.Length != null)
        {
            for (int i = 0; i < sliderAddedObject.Length; i++)
            {
                Destroy(sliderAddedObject[i]);

            }
        }
        }
        wrongAnserNumber = 0;
        officeAnserNumber = 0;
        selectedAnserNumber = 0;
        ResetIsAllCorrectDoc();
        AddItemToScorllView();
        
        correctSelected = 0;
        isAllCorrect = false;
        
    }
    

    public bool CheckInputAnser()//cheack anser

    {
        if(correctSelected >= officeAnserNumber) {
            if (wrongAnserNumber == 0)
            {

                return  true;
            }
            else

                return false;
        }
        else 

        return false; 
    }

    
}
