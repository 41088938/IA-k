using UnityEngine;

public class BookZoomFieldController : MonoBehaviour
{
    [SerializeField]public GameObject boxZoomField;
     [SerializeField]GameObject carInSide;
    bool rayIsOn=true;
    [SerializeField]GamePageControler gpc_controler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rayIsOn == true) { 
        if (carInSide.active == true) { 
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.transform.tag == "vanInside")
                        Debug.Log("hitedVan");
                    {
                            gpc_controler.SetCrentProcedurStepOn(0);

                    }
                }
            }
        }
        }
        else
        {
           // boxZoomField.SetActive(false);
        }

    }
    public void OffRay(bool on)
    {
        rayIsOn=on;
    }
    public void OutZoomVeiw()
    {
        boxZoomField.SetActive(false);
    }
}
