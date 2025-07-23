using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepBtnGroupManager : MonoBehaviour
{
    //control steps btns interactable
    public Button[] btns;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void OnCLick(Button btn)
    {
        iniBtns();
        btn.interactable = false;
    }

    public void iniBtns() {
        foreach (Button btn in btns) {
            btn.interactable = true;
        }
    }
}
