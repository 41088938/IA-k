using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconClick : MonoBehaviour
{
    GameObject ICONBTN;
    // Start is called before the first frame update
    void Start()
    {
        ICONBTN = StaticObjOrVar.ICONBTN;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    { 

        ICONBTN.SetActive(true);
        ICONBTN.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
        
    }
}
