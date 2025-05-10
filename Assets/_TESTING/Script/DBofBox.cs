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
        GameObject.Find("Procedure2Canvas/AWBDA/AWB_ScrollRect/Image").GetComponent<Image>().sprite = Airwaybill;
        //GameObject.Find("Procedure2Canvas/Image").GetComponent<Image>().preserveAspect = true;
        GameObject.Find("Procedure3Canvas/DGDDG/DGDDA/DGD_ScrollRect/Image").GetComponent<Image>().sprite = DGD;
    }

    public void callOption()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("optionTag");
        for (int x = 0; x < gos.Length; x++)
        {
            Destroy(gos[x]);
        }

        for (int x = 0; x < AWBoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext,GameObject.Find("Procedure5Canvas/AWBCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "AWBoption" + (x + 1);
            go.GetComponent<TMP_Text>().text = AWBoption[x];
            go.transform.GetChild(2).gameObject.SetActive(false);
        }
        for (int x = 0; x < Packageoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext, GameObject.Find("Procedure5Canvas/PackageCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "Packageoption" + (x + 1);
            go.GetComponent<TMP_Text>().text = Packageoption[x];
            if (this.gameObject.name.Contains("Dry"))
            {
                if (Packageoption[x].Contains("UN"))
                {
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Dry_ice/Dry_ice_Missing_UN");
                }
                else if (Packageoption[x].Contains("Hazard"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Dry_ice/Missing_Hazard_Label");
                else
                    go.transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (this.gameObject.name.Contains("flammable"))
            {
                if (Packageoption[x].Contains("Orientation"))
                {
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Flammable/Flammable_Missing_Orientation_Label");
                }
                else if (Packageoption[x].Contains("Subsidiary"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Flammable/Flammable_Missing_Subsidiary_Hazard_Label");
                else if (Packageoption[x].Contains("Type_Code"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Flammable/Flammable_Missing_Type_Code");
                else if (Packageoption[x].Contains("UN"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Flammable/Flammable_Missing_UN");
                else
                    go.transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (this.gameObject.name.Contains("Lithium"))
            {
                if (Packageoption[x].Contains("sodium"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Lithium/lithium_Missing_sodium_ion_battery_label");
                else if (Packageoption[x].Contains("number"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Lithium/lithium_Missing_UN_number");
                else if (Packageoption[x].Contains("UN"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Lithium/lithium_Missing_UN");
                else
                    go.transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (this.gameObject.name.Contains("overpack"))
            {
                if (Packageoption[x].Contains("CAO"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Overpack/CAO_Label");
                else if (Packageoption[x].Contains("5.1"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Overpack/Hazard_Label_5.1");
                else if (Packageoption[x].Contains("6.1"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Overpack/Hazard_Label_6");
                else if (Packageoption[x].Contains("Orientation"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Overpack/Overpack_Missing_Orientation_Label");
                else if (Packageoption[x].Contains("UN"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Overpack/Overpack_Missing_UN");
                else
                    go.transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (this.gameObject.name.Contains("barrel"))
            {
                if (Packageoption[x].Contains("CAO"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Type_B_Package/CAO_Label");
                else if (Packageoption[x].Contains("Category"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Type_B_Package/Category_Label");
                else if (Packageoption[x].Contains("Gross"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Type_B_Package/Permissible_Gross_Weight");
                else if (Packageoption[x].Contains("Trefoil"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Type_B_Package/Trefoil_Symbol");
                else if (Packageoption[x].Contains("UN"))
                    go.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Missing_icon/Type_B_Package/Type_B_Missing_UN");
                else
                    go.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        for (int x = 0; x < Dgdoption.Length; x++)
        {
            GameObject go = Instantiate(optiontext, GameObject.Find("Procedure5Canvas/DGDCanvas/Scroll View/Viewport/Content").transform);
            go.transform.name = "DGDoption" + (x + 1);
            
            go.GetComponent<TMP_Text>().text = Dgdoption[x];
            if (Dgdoption[0] == "NAN, there is no DGD")
            go.transform.GetChild(1).GetComponent<Button>().enabled = false;
            go.transform.GetChild(0).GetComponent<Image>().enabled = false;
            go.transform.GetChild(2).gameObject.SetActive(false);
        }
        GameObject.FindAnyObjectByType<boxesController>().initArrays(AWBoption.Length+Packageoption.Length+Dgdoption.Length);
    }
    public string[] getAns()
    {
        return ans;
    }

}
