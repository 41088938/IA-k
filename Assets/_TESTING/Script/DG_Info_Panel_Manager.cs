using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DG_Info_Panel_Manager : MonoBehaviour
{
    public Image infoImage;
    // Start is called before the first frame update
    /*void Start()
     {

     }*/

    // Update is called once per frame
    /* void Update()
     {

     }*/

    public void setImg(Sprite m_img)
    {
        infoImage.sprite= m_img;
    }


}
