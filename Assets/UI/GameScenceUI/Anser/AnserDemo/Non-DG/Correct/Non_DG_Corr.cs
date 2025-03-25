using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_DG_Corr : MonoBehaviour
{
    [SerializeField] GameObject[] anser;
    [SerializeField] GameObject[] positionans;


    private int offtotalCorrectanser = 0;
   /*private void Start()
    {
        for (int i = 0; i < anser.Length; i++)
        {
            anser[i].SetActive(false);
        }
        for (int i = 0; i < positionans.Length; i++)
        {
            positionans[i].SetActive(false);
        }
    }*/
    public GameObject GetAnserNonDGCorr(int x)
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
            case 18:
                return anser[17];
                break;
            case 19:
                return anser[18];
                break;
            case 20:
                return positionans[0];
                break;
            case 21:
                return positionans[1];
                break;
            case 22:
                return positionans[2];
                break;
            case 23:
                return positionans[3];
                break;



        }
        return null;
    }
    public int GetNonDGCorrOfftotalCorrectanser()
    {
        return offtotalCorrectanser;
    }
}
