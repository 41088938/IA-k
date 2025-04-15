using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class checkBoxClick : MonoBehaviour
{
    [SerializeField]
    Sprite[] pics;
    [SerializeField]
    TMP_Text te;
    string type;
    bool checkBox = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        if (!checkBox)
        {
            GetComponent<Image>().sprite = pics[1];
            if (this.transform.parent.name.Contains("AWB"))
                GameObject.FindFirstObjectByType<boxesController>().addOption("AWB", this.transform.parent.GetComponent<TMP_Text>().text);
            if (this.transform.parent.name.Contains("Package"))
                GameObject.FindFirstObjectByType<boxesController>().addOption("Package", this.transform.parent.GetComponent<TMP_Text>().text);
            if (this.transform.parent.name.Contains("DGD"))
                GameObject.FindFirstObjectByType<boxesController>().addOption("DGD", this.transform.parent.GetComponent<TMP_Text>().text);
        }
        else
        {
            GetComponent<Image>().sprite = pics[0];
            if (this.transform.parent.name.Contains("AWB"))
                GameObject.FindFirstObjectByType<boxesController>().removeOption("AWB", this.transform.parent.GetComponent<TMP_Text>().text);
            if (this.transform.parent.name.Contains("Package"))
                GameObject.FindFirstObjectByType<boxesController>().removeOption("Package", this.transform.parent.GetComponent<TMP_Text>().text);
            if (this.transform.parent.name.Contains("DGD"))
                GameObject.FindFirstObjectByType<boxesController>().removeOption("DGD", this.transform.parent.GetComponent<TMP_Text>().text);
        }
        checkBox = !checkBox;
    }
}
