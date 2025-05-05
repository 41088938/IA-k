using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class boxesController : MonoBehaviour
{
    //choose SAVER
    public string[] Choose;
    //GameObj
    [SerializeField] TimerCode timerHolder;
    [SerializeField] GameObject PackageICON;
    Image[] icons;
    [SerializeField] GameObject bg;
    GameObject ClickedBox = null;
    [SerializeField] GameObject BoxPoint;
    GameObject[] points;
    //Other
    [SerializeField] StaticObjOrVar staticHolder;
    [SerializeField] ResultCheckList resultCheckList;
    Camera maincam;
    [SerializeField]
    GameObject[] prefebs;
    //var
    GameObject[] pointsWithRand;
    public bool getBox = false;
    int numberOfBox = 0;
    public int HowManyBox = 0;
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
            GameObject go = Instantiate(Resources.Load<GameObject>("OX/packageICON"));
            go.transform.parent = PackageICON.transform;
            go.transform.name = "icon" + x;
            icons[x] = go.GetComponent<Image>();
        }
        StaticObjOrVar.NewGameUI[0].enabled = false;
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
                if (hit.collider.gameObject.tag == "box")
                {
                    ClickedBox = hit.collider.gameObject;
                    StaticObjOrVar.selectedObj = ClickedBox;
                    BoxClick();
                }
            }
        }

    }
    public void initArrays(int x)
    {
        Choose = new string[x];
    }
    public void BoxClick()
    {
        StaticObjOrVar.NewGameUI[0].enabled = true;
        StaticObjOrVar.NewGameUI[1].enabled = true;
        bg.SetActive(true);
        getBox = true;
        ClickedBox.transform.position = BoxPoint.transform.position;
        if (!ClickedBox.transform.name.Contains("barrelpackage"))
        {
            icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/box");
        }
        else
        {
            //no barrel pic
            icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/white");
        }
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
    public void addOption(string msg)
    {
            for (int x = 0; x < Choose.Length; x++)
            {
                if (Choose[x] == null)
                {
                    Choose[x] = msg;
                    break;
                }
            }
    }
    public void removeOption(string msg)
    {
            for (int a = 0; a < Choose.Length; a++)
            {
                if (Choose[a] == msg)
                {
                    Choose[a] = null;
                    break;
                }
            }
    }
    public void checkAns()
    {
        string[] ans = ClickedBox.GetComponent<DBofBox>().getAns();
        if (staticHolder.InProcedure5)
        {
            int temp = 0;
            if (ans[0] == "correct")
            {
                resultCheckList.AddCrossItem("It has no error!");
                icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
            }
            else
            {
                for (int x = 0; x < ans.Length; x++)
                {
                    for (int y = 0; y < Choose.Length; y++)
                    {
                        if (ans[x] == Choose[y])
                        {
                            resultCheckList.AddTickItem(Choose[y]);
                            ans[x] = null;
                            temp++;
                            break;
                        }
                    }
                }
                if (temp == ans.Length)
                {
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");
                }
                else
                {
                    resultCheckList.AddCrossItem("You are missing these error:");
                    for (int x = 0; x < ans.Length; x++)
                    {
                        if (ans[x] != null)
                        {
                            temp++;
                            resultCheckList.AddCrossItem(ans[x]);
                        }
                    }
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
                }

            }
        }
        else
        {
            if (ans[0] == "correct")
            {
                resultCheckList.AddTickItem("You are correct!");
                icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");

            }
            else
            {
                for (int x = 0; x < ans.Length; x++)
                {
                    resultCheckList.AddCrossItem(ans[x]);
                }

                icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
            }
        }
        HowManyBox++;
    }
    public void resetVar()
    {
            StaticObjOrVar.NewGameUI[5].enabled = false;
            resultCheckList.RemoveAll();
            resultCheckList.GetComponentInParent<Canvas>().enabled = false;
            Destroy(ClickedBox);
            bg.SetActive(false);
            getBox = false;
            StaticObjOrVar.NewGameUI[0].enabled = false;

        if (HowManyBox == numberOfBox)
        {
            StaticObjOrVar.NewGameUI[7].enabled = true;
            StaticObjOrVar.NewGameUI[7].transform.GetChild(1).GetComponent<TMP_Text>().text = "Total Time Left\n"+timerHolder.getTimer();
            int temp = PackageICON.transform.childCount;
            for (int x = 0; x < temp;x++)
            {
                PackageICON.transform.GetChild(0).parent = StaticObjOrVar.NewGameUI[7].transform.GetChild(2).transform;
            }

        }
    }

}
