using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPageController : MonoBehaviour
{
    [SerializeField]Text infoDesc;
    [SerializeField]Image infoImage;
    [SerializeField]Text pageNumber;
    private int counter=0;

   
    public void showPages(InfoPages page,InfoPageDatabase database)
    {
        counter = 0;
        for (int i = 0; i < database.gamePlayinfo.Length; i++)
        {
            counter++;
        }
        infoDesc.text=page.description;
        infoImage.sprite=page.infoImage;
        pageNumber.text=page.pagNumber+"/"+counter;
    }
   

}
