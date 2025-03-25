using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettingManuel : MonoBehaviour
{
    [SerializeField] Button setingButton;
    private Animator animator;
    private bool onclicked=false;
    private bool settingOpened=false;

    private void Start()
    {
        setingButton.onClick.AddListener(gameSetting);
        animator = gameObject.GetComponent<Animator>();
        settingOpened = false;

}
    
    public void gameSetting()
    {
        onclicked=true;
        if (onclicked == true)
        {
            if (settingOpened == false) {
                animator.Play("SetingManuelOut");
                settingOpened=true;
            }else if(settingOpened == true) {
                animator.Play("SetingManuelIn");
                settingOpened = false;
            }
          
            onclicked=false;
        
        }
    }

}
