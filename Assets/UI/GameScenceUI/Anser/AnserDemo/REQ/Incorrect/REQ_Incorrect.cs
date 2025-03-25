using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REQ_Incorrect : MonoBehaviour
{
    [SerializeField] GameObject[] anser;
    [SerializeField] GameObject[] posAnser;
    private int offtotalCorrectanser = 1;
    /* private void Start()
     {
         for (int i = 0; i < anser.Length; i++)
         {
             anser[i].SetActive(false);
         }
         for (int i = 0; i < posAnser.Length; i++)
         {
             posAnser[i].SetActive(false);
         }
     } */
    public GameObject GetAnserREQIncorr(int x)
    {
        switch (x)
        {
            case 1:
                return anser[0];
                break;
            case 2:
                return anser[1];
                break;
            case 3:
                return anser[2];
                break;
            case 4:
                return anser[3];
                break;
            case 5:
                return anser[4];
                break;
            case 6:
                return anser[5];
                break;
            case 7:
                return anser[6];
                break;
            case 8:
                return anser[7];
                break;
            case 9:
                return anser[8];
                break;
            case 10:
                return anser[9];
                break;
            case 11:
                return anser[10];
                break;
            case 12:
                return anser[11];
                break;
            case 13:
                return anser[12];
                break;
            case 14:
                return anser[13];
                break;
            case 15:
                return anser[14];
                break;
            case 16:
                return anser[15];
                break;
            case 17:
                return anser[16];
                break;
            case 20:
                return posAnser[0];
                break;
            case 21:
                return posAnser[1];
                break;
            case 22:
                return posAnser[2];
                break;
            case 23:
                return posAnser[3];
                break;
            case 24:
                return posAnser[4];
                break;



        }
        return null;
    }
    public int GetNonREQIncorrOfftotalCorrectanser()
    {
        return offtotalCorrectanser;
    }

}
