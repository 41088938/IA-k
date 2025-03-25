using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class RandomControler : MonoBehaviour
{
    List<int> list = new List<int>();
   
    public int RandomNumber()
    {
   
        int index = UnityEngine.Random.Range(0, list.Count - 1);    //  Pick random element from the list
        
        int i = list[index];    //  i = the number that was randomly picked
        
        list.RemoveAt(index);   //  Remove chosen element
        return i;
    }
    public void AddRandomNumberList()
    {
        for (int n = 0; n < 6; n++)    //  Populate list
        {
            list.Add(n);

        }
    }
   
}
