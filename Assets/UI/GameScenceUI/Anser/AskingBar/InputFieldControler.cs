using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFieldControler : MonoBehaviour
{
    [SerializeField] InputField stickerInputField;
    [SerializeField] Text askingBarText;
    [SerializeField] Text stickerText;
    [SerializeField] Button inputFeildEnterButton;

    [SerializeField] Animator askingDetailBar_aimator;
    [SerializeField] NonDG_Incorrect nonDG_Incor_Input;


    private bool isOpenDetailBar=false;
    private string playerEnteredString;
    private void Start()
    {
        isOpenDetailBar = false;
    }
    private void Update()
    {
        
      
    }
    
    }
   
 
    
    
    
    

