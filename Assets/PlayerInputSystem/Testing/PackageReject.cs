using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageReject : MonoBehaviour
{
    [SerializeField] private GameObject rejectReseaonUI;
    [SerializeField] private GameObject packageQRUI;
    


   public void ChangeToRejectReseaon()
    {
        packageQRUI.SetActive(false);
        rejectReseaonUI.SetActive(true);

    }
    public void backToSelection()
    {
        packageQRUI.SetActive(true);
        rejectReseaonUI.SetActive(false);
    }
    

}
