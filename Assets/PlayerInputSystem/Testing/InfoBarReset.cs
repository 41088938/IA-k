using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarReset : MonoBehaviour
{
    [SerializeField] private GetAnser_1 getAner_1;
    [SerializeField] Toggle[] toggles;
    [SerializeField] GameObject[] page;

    public void resteMissinginformation()
    {
        if (getAner_1.GetAnserIsCorrected())
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = false;

            }
            for (int i = 0;i < page.Length; i++)
            {
                page[i].SetActive(false);
            }
            page[0].SetActive(true);
        }
    }
   
}
