using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class InputField_WordSelection_Control : MonoBehaviour
{
   
    //[SerializeField] Text wordSelectionButton_text;
   // [SerializeField] InputField wordSelectionLabel_text;
    // private GameObject crentBox;

    private int textNum = 0;
    int officeAnserNumber = 0;
    int correctAnserNumber=0;
    
    int wrongAnserNumber = 0;

    GameObject[] addedObject;
    bool runed=false;

    [SerializeField] private string[] selectionText_NonDGIncorr;
    [SerializeField]private string[] selectionText_NonDGcorr;

    [SerializeField]private string[] selectionText_REQIncorr;
    [SerializeField]private string[] selectionText_REQCorr;

    [SerializeField] private string[] selectionText_NonRadioCorr;
    [SerializeField]private string[] selectionText_REQRadioInCorr;

    private string[] crentText=new string[3];

    [SerializeField] private AnserControler ac_controler;
    
    [SerializeField] public GameObject prefab;
    [SerializeField] public GameObject content;

    private void Start()
    {
        runed = false;
    }
    public void InputFieldButtonTextControl()
    { 
        

        runed = true;
        
        //crentBox = ac_controler.GetCrentBox();
        //cage1=REQCorr cage2=nonRadioacorr cage3= incorrectRadio cage4=nonDGIncorr cage5=REQIncorr cage6=nonDG_corr
        if (ac_controler.GetCrentBox() == ac_controler.cager1_corr) {
            addedObject = new GameObject[crentText.Length];


            for (int i = 0; i < crentText.Length; i++){
               
                GameObject newItem = Instantiate(prefab, content.transform);
                Debug.Log("addedObject " + addedObject[i]);
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                addedObject[i] = newItem;


                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_REQCorr[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;

            }
        }else if (ac_controler.GetCrentBox() == ac_controler.cager2_corr)
        {
            addedObject = new GameObject[crentText.Length];
            for (int i = 0; i < crentText.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                addedObject[i] = newItem;
                Debug.Log("addedObject " + addedObject[i]);
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_NonRadioCorr[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }

        }  else if(ac_controler.GetCrentBox() == ac_controler.cager3)
        {
            addedObject = new GameObject[crentText.Length];
            for (int i = 0; i < crentText.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                addedObject[i] = newItem;
                Debug.Log("addedObject " + addedObject[i]);
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_REQRadioInCorr[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
        }else if (ac_controler.GetCrentBox() == ac_controler.cager4)
        {
            addedObject = new GameObject[crentText.Length];
            for (int i = 0; i < crentText.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                addedObject[i] = newItem;
                Debug.Log("addedObject " + addedObject[i]);
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_NonDGIncorr[i];
                if(itemText.text== "Net Quantity 2kg")
                {
                    toggle.onValueChanged.AddListener(OnToggleValueChangedCorrect);
                }else
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
           
            officeAnserNumber = 1;
           
        }
        else if (ac_controler.GetCrentBox() == ac_controler.cager5)
        {
            addedObject = new GameObject[crentText.Length];
            for (int i = 0;i < crentText.Length; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                addedObject[i] = newItem;
                Debug.Log("addedObject " + addedObject[i]);
                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_REQIncorr[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
        }else if (ac_controler.GetCrentBox()== ac_controler.cager6_corr)
        {
            addedObject = new GameObject[crentText.Length];
            for ( int i = 0;i<crentText.Length ; i++)
            {
                GameObject newItem = Instantiate(prefab, content.transform);
                addedObject[i] = newItem;
                Debug.Log("addedObject " + addedObject[i]);

                Text itemText = newItem.GetComponentInChildren<Text>();
                Toggle toggle = newItem.GetComponentInChildren<Toggle>();
                newItem.transform.position = newItem.transform.position - new Vector3(0, moveDownWard, 0);
                itemText.text = selectionText_NonDGcorr[i];
                toggle.onValueChanged.AddListener(OnToggleValueChangedWrong);
                moveDownWard += 120;
            }
        }
        
        Debug.Log("InputButtonReseted2");

    }
    float moveDownWard = 0;
    void AddItemToScorllView()
    {
      

        moveDownWard = 0;
   
            InputFieldButtonTextControl();
     
    }

    void OnToggleValueChangedWrong(bool isOn)
    {
        int x = 0;


        if (isOn)
        {
            x += 1;
        }
        else
        {
            x -= 1;
        }


        wrongAnserNumber += x;
        Debug.Log("WrongSelected_counter= " + wrongAnserNumber);


    }


    void OnToggleValueChangedCorrect(bool isOn)
    {
        int x = 0;
        
       
     if (isOn)
      {
        x += 1;
     }
      else
       {
           x -= 1;
       }

        
   
        correctAnserNumber += x;
        Debug.Log("correctedSelected_counter= " + correctAnserNumber);
    }
   
    public bool CheckInputFieldToogle()
    {
        if (correctAnserNumber >=officeAnserNumber)
        {
            if (wrongAnserNumber == 0)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
        

    }

    

    public void ResetMissingInputToggle()
    {
        if (addedObject.Length != 0 || addedObject.Length != null)
        {
            for (int i = 0; i < addedObject.Length; i++)
            {
                Destroy(addedObject[i]);

            }
        }

        officeAnserNumber = 0;
         correctAnserNumber = 0;
         
         wrongAnserNumber = 0;
        AddItemToScorllView();
        Debug.Log("InputButtonReseted");
    }
}
