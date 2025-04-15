using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillInComponent : MonoBehaviour
{
    [ContextMenu("Add Dry ice")]
    public void AddDryIce()
    {
        DBofBox temp = GetComponent<DBofBox>();
        if (temp == null) temp = gameObject.AddComponent<DBofBox>();
        temp.AWBoption = new string[]
        {
            "Missing the \"Net Quantity weight of Dry Ice\"",
            "Incorrext Hazard Label",
            "Incorrect placement of the \"shipper and consignee Mark\"",
            "Missing the \"Proper Shipping Name\" in AWB",
            "Missing the word \"UN\"",
            "Incorrect \"UN number\""
        };
        temp.Packageoption = new string[]
        {
            "Incorrect usage of \"DG statement\" / Need to be removed",
            "Missing the word \"UN\"",
            "Missing the \"Net Quantity of Dry Ice\"",
            "Missing the \"Proper Shipping Name\"",
            "Incorrect \"UN number\""
        };
        temp.Dgdoption = new string[]
        {
            "Non, there is no DGD"
        };
    }
}
