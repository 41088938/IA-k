using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : MonoBehaviour
{
    [SerializeField] InputActionAsset playerInput_InputActionAsset;
    private InputAction activateAction;
    [SerializeField] private Animator phone_animator;
    [SerializeField] Animator gameOver;
    [SerializeField] Animator stageClear;
    [SerializeField] GetAnser_1 ga_controler;
   
    // Start is called before the first frame update
    private void Awake()
    {
        // Reference the actions from the InputActionAsset
        var playerActionMap = playerInput_InputActionAsset.FindActionMap("Player");
      
        activateAction = playerActionMap.FindAction("Phone");

        // Bind the Activate action to the method
        activateAction.performed += ctx => PhoneControl();
    }
    private void OnEnable()
    {
        activateAction.Enable();
    }
    private void OnDisable()
    {
        activateAction.Disable();
    }
    private bool phoneIsOpen = false;
    
    private void PhoneControl()
    {  
        Debug.Log("P key pressed!");
        if (gameOver.gameObject.active == true || stageClear.gameObject.active == true)
        {
            Debug.Log("Game is Over, can't call phone");
            return;

        }
        
        if (phoneIsOpen == false)
        {
            phoneIsOpen = true;
        }
        else
        {
            OffPhone();
            return;
        }
        if (phoneIsOpen)
        {
            
            OnPhone();
        }
       

    }
    public void OffPhone()
    {
        BackToHomePage();
        phone_animator.Play("Phone_Out_animation");
        phoneIsOpen = false;
        Debug.Log("Phone offed");
        ga_controler.controlRay(false);//On hitRay


    }
    public void OnPhone()
    {
        phone_animator.Play("Phone_In_animation");
        phoneIsOpen = true;
        Debug.Log("Phone On");
        ga_controler.controlRay(true);//Off hitRay
       
    }
    [SerializeField] GameObject[] pages;
    public void OnPlayer2View()
    {
        ResetAllPhoneScren();
        pages[2].active = true;
       

    }
    public void OnStore()
    {
        ResetAllPhoneScren();
        pages[1].active = true;
     
    }
    public void OnHelp()
    {
        ResetAllPhoneScren();
        pages[3].active= true;
    }
    public void BackToHomePage()
    {
        ResetAllPhoneScren();
        pages[0].active = true;
    }
    
    public void ResetAllPhoneScren()
    {
        for(int i=0;i<pages.Length; i++)
        {
            pages[i].active= false;
        }
    }
}
