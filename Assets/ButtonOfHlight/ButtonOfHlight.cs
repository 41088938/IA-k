using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOfHlight : MonoBehaviour
{
    [SerializeField] Toggle[] highlighters;
    [SerializeField] GameObject[] rectcPage;
    

    public void ResetButtonHightlighter()
    {
        for(int i = 0; i < highlighters.Length; i++)
        {
            highlighters[i].isOn=false;

        }
     //   highlighters[0].isOn = true;

    }
    public void ResetRectcPage()
    {
        for (int i = 0;i < rectcPage.Length; i++)
        {
            rectcPage[i].SetActive(false);
        }
       // rectcPage[0].SetActive(true);
    }
    private void ResetReject()
    {
        ResetButtonHightlighter();
        ResetRectcPage();
        

    }
    public void PackageButton()
    {
        ResetReject();
        highlighters[0].isOn = true;
        rectcPage[0].SetActive(true) ;



    }
    public void AWBButton()
    {
        ResetReject();
        highlighters[1].isOn = true;
        rectcPage[1].SetActive(true);
    }
    public void DGDButton()
    {
        ResetReject();
        highlighters[2].isOn = true;
        rectcPage[2].SetActive(true);
    }
}
