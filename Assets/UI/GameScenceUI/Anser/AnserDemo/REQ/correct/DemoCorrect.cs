using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCorrect : MonoBehaviour
{
    [SerializeField] GameObject incorret1;
    [SerializeField] GameObject incorret2;
    [SerializeField] GameObject incorret3;
    [SerializeField] GameObject incorret4;
    [SerializeField] GameObject incorret5;
    [SerializeField] GameObject incorret6;
    [SerializeField] GameObject incorret7;
    [SerializeField] GameObject incorret8;
    [SerializeField] GameObject incorret9;
    [SerializeField] GameObject incorret10;
    [SerializeField] GameObject incorret11;
    [SerializeField] GameObject incorret12;
    [SerializeField] GameObject incorret13;
    [SerializeField] GameObject incorret14;
    [SerializeField] GameObject incorret15;
    [SerializeField] GameObject incorret16;
    [SerializeField] GameObject incorret17;
    //  [SerializeField] GameObject incorret18;

    [SerializeField]GameObject inSticker;
    [SerializeField]GameObject inShipment;
    [SerializeField]GameObject inWayBill;
    
    private int offtotalCorrectanser=0;
     public GameObject GetAnserDemoCorr(int x)
    {
        switch (x)
        {
            case 1: return incorret1;
                
            case 2: return incorret2;
               
                case 3: return incorret3;
                
                case 4: return incorret4;
               
                   case 5: return incorret5;
                
                case 6: return incorret6;
                
                case 7: return incorret7;
                
                case 8: return incorret8;
               
                case 9: return incorret9;
                
                case 10: return incorret10;
                
                case 11: return incorret11;
                
                case 12: return incorret12;
                
                case 13: return incorret13;
               
                case 14: return incorret14;
              
                case 15: return incorret15;
                
                case 16: return incorret16;
               
                case 17: return incorret17;
                
                case 20: return inSticker;
                case 21: return inShipment;
                case 22: return inWayBill;

               
        }
        return null;
    }
    public int GeDemoOfftotalCorrectanser()
    {
        return offtotalCorrectanser;
    }


}
