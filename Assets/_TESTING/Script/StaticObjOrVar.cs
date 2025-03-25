using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjOrVar : MonoBehaviour
{
    public static Canvas[] GameUICanvas = new Canvas[3];
    // Start is called before the first frame update
    void Start()
    {
        GameUICanvas[0] = GameObject.Find("GameCommonUI").GetComponent<Canvas>();
        GameUICanvas[1] = GameObject.Find("CommonUI").GetComponent<Canvas>();
        GameUICanvas[2] = GameObject.Find("AskingBar").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
