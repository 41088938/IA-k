using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnerChecking : MonoBehaviour
{
    [SerializeField] LivePointController LPController;
    private bool allCorrect = false;

    private void Start()
    {
        allCorrect = false;
    }
    public void checkAnser()
    {
        if (allCorrect == false)
        {
            LPController.MissSubmition();

        }
    }

   

}
