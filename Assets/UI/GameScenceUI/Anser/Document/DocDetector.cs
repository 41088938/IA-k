using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DocDetector : MonoBehaviour
{
    [SerializeField] AnserControler ac_controler;
    [SerializeField] DocControl dc_controler;
    private GameObject crentBox;
    
    // Start is called before the first frame update
    
    public void DocUpdate()
    {
        dc_controler.ResetDoc();
        crentBox = ac_controler.GetCrentBox();
        ChangWaybillDoc();


    }
    public void ChangWaybillDoc()
    {
        if(crentBox==ac_controler.cager1_corr|| crentBox == ac_controler.cager5)
        {
            int x = Random.Range(0, 2);
            if (x % 2 == 0)
            {
                dc_controler.SetWaybillDocActive(0);
                
            }
            else
            {
                dc_controler.SetWaybillDocActive(4);
            }
            dc_controler.SetShipperDocActive(Random.Range(0,2));


        }else if(crentBox == ac_controler.cager2_corr|| crentBox == ac_controler.cager3)
        {
            int x = Random.Range(0, 2);
            if (x % 2 == 0)
                dc_controler.SetWaybillDocActive(1);
            else
            {
                dc_controler.SetWaybillDocActive(2);
            }
            dc_controler.SetShipperDocOff();
        }
        else if (crentBox == ac_controler.cager4 || crentBox == ac_controler.cager6_corr)
        {
            int x = Random.Range(0, 2);
            if (x % 2 == 0)
                dc_controler.SetWaybillDocActive(3);
            else
            {
                dc_controler.SetWaybillDocActive(5);
            }
            dc_controler.SetShipperDocOff();
        }
        
    }
   
}//control waybuil to mach the cage
