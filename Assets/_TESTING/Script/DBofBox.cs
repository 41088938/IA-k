using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBofBox : MonoBehaviour
{
    [SerializeField]
    Sprite Airwaybill;
    [SerializeField]
    Sprite DGD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callImage()
    { 
        GameObject.Find("Procedure2Canvas/Image").GetComponent<Image>().sprite = Airwaybill;
        GameObject.Find("Procedure3Canvas/Scroll View/Viewport/Content/Image").GetComponent<Image>().sprite = DGD;
    }
}
