using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DBofBox : MonoBehaviour
{
    [SerializeField]
    Sprite Airwaybill;
    [SerializeField]
    Sprite DGD;
    [SerializeField]
    public string[] AWBoption;
    [SerializeField]
    public string[] Packageoption;
    [SerializeField]
    public string[] Dgdoption;
    GameObject optiontext;
    [SerializeField]
    string[] ans;
    // Start is called before the first frame update
    void Start()
    {
        optiontext = Resources.Load<GameObject>("OptionsText");
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

    public void callOption()
    {
        for (int x = 0; x < AWBoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext,GameObject.Find("Procedure5Canvas/AWBCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "AWBoption" + (x + 1);
            go.GetComponent<TMP_Text>().text = AWBoption[x];
        }
        for (int x = 0; x < Packageoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext, GameObject.Find("Procedure5Canvas/PackageCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "Packageoption" + (x + 1);
            go.GetComponent<TMP_Text>().text = Packageoption[x];
        }
        for (int x = 0; x < Dgdoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext, GameObject.Find("Procedure5Canvas/DGDCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "DGDoption" + (x + 1);
            go.GetComponent<TMP_Text>().text = Dgdoption[x];
            if (Dgdoption[0] == "NAN, there is no DGD")
            go.transform.GetChild(1).GetComponent<Button>().enabled = false;
            go.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        GameObject.FindAnyObjectByType<boxesController>().initArrays(AWBoption.Length+Packageoption.Length+Dgdoption.Length);
    }
    public string[] getAns()
    {
        return ans;
    }
}
