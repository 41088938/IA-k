using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
   
    private int x;
    private int CreatRandom()
    {
        List<int>Nums = new List<int>();
        for(int i = 0; i < 5; i++) { 
        Nums.Add(i);
        }
        
        for (int i = 0; i < Nums.Count; i++)
        {
            Nums[i] = Random.Range(0, Nums.Count);
            // Debug.Log(x);
           x= Nums[i];
          
        }
       
        Nums.Remove(Nums[x]);
         return x; 
    }
    public int GetRadom()
    {
        CreatRandom();
        return x;

    }
    
}
