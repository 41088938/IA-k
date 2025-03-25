using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChatControler : MonoBehaviour
{
    [SerializeField] InputActionAsset playerInput_InputActionAsset;
    [SerializeField] Animator chat;
    private InputAction viewChatAction;
    private InputAction chatActiveAction;
    private InputAction sendActiveAction;
    [SerializeField] GameObject inputPlanal;
    private void Awake()
    {
        // Reference the actions from the InputActionAsset
        var playerActionMap = playerInput_InputActionAsset.FindActionMap("Chat");

        viewChatAction = playerActionMap.FindAction("ViewChat");
        chatActiveAction = playerActionMap.FindAction("EnterChat");
        sendActiveAction = playerActionMap.FindAction("SendChat");

        // Bind the Activate action to the method
        viewChatAction.performed += ctx => ViewChat();
        chatActiveAction.performed += ctx => EnterChat();
        sendActiveAction.performed += ctx => SendChat();
    }
    private void OnEnable()
    {
        viewChatAction.Enable();
        chatActiveAction.Enable();
        sendActiveAction.Enable();
    }
    private void OnDisable()
    {
        viewChatAction.Disable();
        chatActiveAction.Disable();
        sendActiveAction.Disable();
    }
    private bool chatIsOpen=false;
    [SerializeField] GameObject viewChat; 
    public void ViewChat()
    {
        if (chatIsOpen == false)
        {
            chatIsOpen = true;
        }
        else { chatIsOpen = false; }
        if (chatIsOpen == true)
        {
            chat.Play("Chat_In_animation");
            viewChat.transform.Rotate(0, 0, 180);
        }
        else
        {
            viewChat.transform.Rotate(0, 0, 180);
            chat.Play("Chat_Out_animation");
        }

    }
   private bool inputMassageOpen=false;
    void EnterChat()
    {
        if (inputMassageOpen == false)
        {
            inputMassageOpen = true;
        }
        else
        {
            inputMassageOpen = false;
        }
        if (inputMassageOpen == true)
        {
            inputPlanal.active= true;

        }
        else
        {
            inputPlanal.active= false;
        }
    }
    void SendChat()
    {
        //.....
    }
}
