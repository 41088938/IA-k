using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnserControler : MonoBehaviour
{
    [SerializeField]public GameObject cager1_corr;
    [SerializeField] public GameObject cager2_corr;
    [SerializeField] public GameObject cager3;
    [SerializeField] public GameObject cager4;
    [SerializeField] public GameObject cager5;
    [SerializeField] public GameObject cager6_corr;

    private GameObject crentCager;

    [SerializeField] private int crencatNumber = 0;

    #region random 

    [SerializeField] RandomControler randomControler;
    private GameObject[] catOrder = new GameObject[6];
    
    public void StartGetAnser()
    {
        randomControler.AddRandomNumberList();
        cager1_corr.SetActive(false);
        cager2_corr.SetActive(false);
        cager3.SetActive(false);
        cager4.SetActive(false);
        cager5.SetActive(false);
        cager6_corr.SetActive(false);
        catOrder[randomControler.RandomNumber()] = cager1_corr;
        catOrder[randomControler.RandomNumber()] = cager2_corr;
        catOrder[randomControler.RandomNumber()] = cager3;
        catOrder[randomControler.RandomNumber()] = cager4;
        catOrder[randomControler.RandomNumber()] = cager6_corr;
        catOrder[randomControler.RandomNumber()] = cager5;
        int correctcounter = 0;
        for (int i = 0; i < 4; i++)
        {
            if (catOrder[i] == cager1_corr || catOrder[i] == cager2_corr || catOrder[i] == cager6_corr)
            {
                correctcounter++;
                Debug.Log("correctcounter:"+correctcounter);
            }
            
        }
        if (correctcounter == 3)
        {
            catOrder[0] = cager2_corr;
            catOrder[1] = cager6_corr;
            catOrder[2] = cager4;
            catOrder[3] = cager5;
            catOrder[4] = cager3;
            catOrder[5] = cager1_corr;

        }




        for (int i = 0; i < catOrder.Length; i++)
        {
            Debug.Log(i + ": " + catOrder[i].name);
        }

        crentCager = catOrder[crencatNumber];
        crencatNumber = 0;
    }
    #endregion
    #region Random


    public void updateCrentCager()
    {
        this.gameObject.SetActive(true);
        crencatNumber++;
        crentCager = catOrder[crencatNumber];

        Debug.Log("crencat=" + crencatNumber);
        CagerRandomOutPut();
    }
    public void CagerRandomOutPut()
    {



        if (crentCager == cager1_corr)
        {
            cager2_corr.SetActive(false);
            cager3.SetActive(false);
            cager4.SetActive(false);
            cager5.SetActive(false);
            cager6_corr.SetActive(false);
        }
        else if (crentCager == cager2_corr)
        {
            cager1_corr.SetActive(false);
            cager3.SetActive(false);
            cager4.SetActive(false);
            cager5.SetActive(false);
            cager6_corr.SetActive(false);
        }
        else if (crentCager == cager3)
        {
            cager1_corr.SetActive(false);
            cager2_corr.SetActive(false);
            cager4.SetActive(false);
            cager5.SetActive(false);
            cager6_corr.SetActive(false);
        }
        else if (crentCager == cager4)
        {
            cager1_corr.SetActive(false);
            cager2_corr.SetActive(false);
            cager3.SetActive(false);
            cager5.SetActive(false);
            cager6_corr.SetActive(false);
        }
        else if (crentCager == cager5)
        {
            cager1_corr.SetActive(false);
            cager2_corr.SetActive(false);
            cager3.SetActive(false);
            cager4.SetActive(false);
            cager6_corr.SetActive(false);
        }
        else if (crentCager == cager6_corr)
        {
            cager1_corr.SetActive(false);
            cager2_corr.SetActive(false);
            cager3.SetActive(false);
            cager4.SetActive(false);
            cager5.SetActive(false);

        }
        UnityEngine.Debug.Log(crentCager);



    }
    #endregion
    public int GetCrentCatNumber()
    {
        return crencatNumber;
    }
    public GameObject GetCrentBox()
    {
        return crentCager;
        Debug.Log("crentCrentBox=" + crentCager.name);
    }
    public void SetCrentBox(bool isAtive)
    {
        crentCager.SetActive(isAtive);
    }
}
