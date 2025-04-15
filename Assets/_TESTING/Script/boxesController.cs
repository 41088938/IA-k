using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class boxesController : MonoBehaviour
{
    //GameObj
    public string[] AWBChoose;
    public string[] PackageChoose;
    public string[] DGDChoose;
    [SerializeField] GameObject PackageICON;
    Image[] icons;
    [SerializeField] GameObject bg;
    GameObject ClickedBox = null;
    [SerializeField] GameObject BoxPoint;
    GameObject[] points;
    //Other
    Camera maincam;
    [SerializeField]
    GameObject[] prefebs;
    //var
    GameObject[] pointsWithRand;
    public bool getBox = false;
    bool turnBox = false;
    int numberOfBox = 0;
    UnityEngine.InputSystem.Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("point");
        bg.SetActive(false);
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //how many package here
        if (SceneManager.GetActiveScene().name == "GameScene_tester_non")
        {
            numberOfBox = 3;
            icons = new Image[3];
        }

        //
        pointsWithRand = new GameObject[numberOfBox];
        for(int x =0; x< numberOfBox;x++)
        {
            int ran = UnityEngine.Random.Range(0, points.Length);
            pointsWithRand[x] = points[ran];
            points = RemoveAt(points, ran);
        }

        for(int x = 0; x<pointsWithRand.Length;x++)
        {
            int ran = UnityEngine.Random.Range(0, prefebs.Length);
            GameObject clone = Instantiate(prefebs[ran],new Vector3(0,0,0), new Quaternion(0,0,0,0));
            clone.transform.parent = GameObject.Find("van/RandomBoxes").transform;
            clone.transform.position =  pointsWithRand[x].transform.position;
            clone.transform.Rotate(0,90,0);
            
        }
        //Debug.Log(Boxes.Length);
            /*
            if (SceneManager.GetActiveScene().name== "GameScene_tester_non")
                BoxesSelected = new GameObject[3];
            for (int x = 0; x < BoxesSelected.Length; x++)
            {
                int ran = UnityEngine.Random.Range(0, Boxes.Length);
                BoxesSelected[x] = Boxes[ran];
                Boxes[ran].SetActive(false);
                Boxes = RemoveAt(Boxes, ran);
            }
            */


    }

    // Update is called once per frame
    void Update()
    {
        mouse = UnityEngine.InputSystem.Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame&&!getBox)
        {
            RaycastHit hit;
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = maincam.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
                if (hit.collider.gameObject.tag == "box")
                {
                    ClickedBox = hit.collider.gameObject;
                    BoxClick();
                }
            }
        }

    }
    public void initArrays(int x,int y,int z)
    {
        AWBChoose = new string[x];
        PackageChoose = new string[y];
        DGDChoose = new string[z];
    }
    public void BoxClick()
    {
        StaticObjOrVar.NewGameUI[0].enabled = true;
        StaticObjOrVar.NewGameUI[1].enabled = true;
        bg.SetActive(true);
        getBox = true;
        ClickedBox.transform.position = BoxPoint.transform.position;
        ClickedBox.GetComponent<DBofBox>().callImage();
        ClickedBox.GetComponent<DBofBox>().callOption();
    }
    public void TurnLeft()
    {
        ClickedBox.transform.Rotate(0,-90,0);
    }
    public void TurnRight()
    {
        ClickedBox.transform.Rotate(0, 90, 0);
    }
    public GameObject[] RemoveAt(GameObject[] source, int index)
    {
        int temp = 0;
        GameObject[] dest = new GameObject[source.Length - 1];
        for (int x = 0; x < source.Length; x++)
        {
            if (x == index)
            {
                temp++;
                continue;
            }

            dest[x-temp] = source[x];
            
        }

        return dest;
    }
    public string[] RemoveAt(string[] source, int index)
    {
        int temp = 0;
        string[] dest = new string[source.Length - 1];
        for (int x = 0; x < source.Length; x++)
        {
            if (x == index)
            {
                temp++;
                continue;
            }

            dest[x - temp] = source[x];

        }

        return dest;
    }
    public void addOption(string which,string msg)
    {
        if (which == "AWB")
        {
            for (int a = 0; a < AWBChoose.Length; a++)
            {
                if (AWBChoose[a] == "")
                {
                    AWBChoose[a] = msg;
                    break;
                }
            }
        }
        else if (which == "DGD")
        {
            for (int a = 0; a < DGDChoose.Length; a++)
            {
                if (DGDChoose[a] == "")
                {
                    DGDChoose[a] = msg;
                    break;
                }
            }
        }
        else
        {
            for (int a = 0; a < AWBChoose.Length; a++)
            {
                if (AWBChoose[a] == "")
                {
                    AWBChoose[a] = msg;
                    break;
                }
            }
        }
        Debug.Log("Added "+which + ", " + msg);
    }
    public void removeOption(string which, string msg)
    {
        if (which == "AWB")
        {
            for (int a = 0; a < AWBChoose.Length; a++)
            {
                if (AWBChoose[a] == msg)
                {
                    AWBChoose= RemoveAt(AWBChoose, a);
                    break;
                }
            }
        }
        else if (which == "DGD")
        {
            for (int a = 0; a < DGDChoose.Length; a++)
            {
                if (DGDChoose[a] == msg)
                {
                    DGDChoose = RemoveAt(DGDChoose,a);
                    break;
                }
            }
        }
        else
        {
            for (int a = 0; a < PackageChoose.Length; a++)
            {
                if (PackageChoose[a] == msg)
                {
                    PackageChoose = RemoveAt(PackageChoose, a);
                    break;
                }
            }
        }
        Debug.Log("Removed "+which + ", " + msg);
    }
}
