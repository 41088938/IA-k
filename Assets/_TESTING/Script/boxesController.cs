using System;
using System.Collections;
using System.Collections.Generic;
//using Fungus;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class boxesController : MonoBehaviour
{
    //choose SAVER
    ArrayList choose;
    //GameObj
    [SerializeField] TimerCode timerHolder;
    [SerializeField] GameObject PackageICON;
    Image[] icons;
    [SerializeField] GameObject bg;
    public GameObject ClickedBox = null;
    [SerializeField] GameObject BoxPoint;
    GameObject[] points;
    //Other
    [SerializeField] StaticObjOrVar staticHolder;
    [SerializeField] ResultCheckList resultCheckList;
    Camera maincam;
    //[SerializeField]GameObject[] prefebs;
    [SerializeField] CanvasGroup Steps;
    [SerializeField] GameObject[] Flammable;
    [SerializeField] GameObject[] DryIce;
    [SerializeField] GameObject[] TypeBM;
    [SerializeField] GameObject[] battery;
    [SerializeField] GameObject[] overpack;
    //var
    ArrayList gameObjects;
    public int correctBox;
    public int baseScore = 20;
    GameObject[] pointsWithRand;
    public bool getBox = false;
    int numberOfBox = 0;
    public int HowManyBox = 0;
    static boxesController controller = null;
    UnityEngine.InputSystem.Mouse mouse;
    int adder = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new ArrayList();
        gameObjects.Add(Flammable);
        gameObjects.Add (DryIce); 
        gameObjects.Add(TypeBM);
        gameObjects.Add(overpack);
        gameObjects.Add(battery);
        correctBox = 0;
        controller = this;
        points = GameObject.FindGameObjectsWithTag("point");
        bg.SetActive(false);
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //how many package here
        if (SceneManager.GetActiveScene().name == "GameScene_tester_non")
        {
            numberOfBox = 3;
            icons = new Image[3];
        }
        else if (SceneManager.GetActiveScene().name == "Intermediate_Level")
        {
            numberOfBox = 5;
            icons = new Image[5];
        }
        else if (SceneManager.GetActiveScene().name == "Advance_Level")
        {
            numberOfBox = 8;
            icons = new Image[8];
        }
        else if (SceneManager.GetActiveScene().name == "TimeTrial")
        {
            numberOfBox = 5;
            icons = new Image[5];
        }
        //
        pointsWithRand = new GameObject[numberOfBox];
        for(int x =0; x< numberOfBox;x++)
        {
            int ran = UnityEngine.Random.Range(0, points.Length);
            pointsWithRand[x] = points[ran];
            points = RemoveAt(points, ran);
        }

        foreach(GameObject[] objs in gameObjects)
        {
            GameObject clone;
            int ran = UnityEngine.Random.Range(0, objs.Length);
            clone = Instantiate(objs[ran],new Vector3(0,0,0), new Quaternion(0,0,0,0));
            clone = Instantiate(objs[ran], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            clone.transform.parent = GameObject.Find("van/RandomBoxes").transform;
            clone.transform.position =  pointsWithRand[adder].transform.position;
            if (objs[ran].transform.name.Contains("flammable"))
            clone.transform.Rotate(0, 180, 0);
            else if (objs[ran].transform.name.Contains("barrelpackage"))
                clone.transform.Rotate(-90, 0, 0);
            else
                clone.transform.Rotate(0, 90, 0);
            if (objs[ran].transform.name.Contains("barrelpackage"))
                clone.transform.Translate(0,0, 0.35f);
            GameObject go = Instantiate(Resources.Load<GameObject>("OX/packageICON"));
            go.transform.parent = PackageICON.transform;
            go.transform.name = "icon" + adder;
            icons[adder] = go.GetComponent<Image>();
            adder++;
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

    public void BoxClick()
    {
        Steps.interactable = true;
        choose = new ArrayList();
        StaticObjOrVar.NewGameUI[0].enabled = true;
        StaticObjOrVar.NewGameUI[1].enabled = true;
        StaticObjOrVar.NewGameUI[0].transform.Find("Steps").GetComponent<CanvasGroup>().interactable = true;
        bg.SetActive(true);
        getBox = true;
        ClickedBox.transform.position = BoxPoint.transform.position;
        if (ClickedBox.transform.name.Contains("barrelpackage"))
            ClickedBox.transform.Translate(0, 0, 0.2f);
        if (!ClickedBox.transform.name.Contains("barrelpackage"))
        {
            icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/box");
        }
        else
        {
            //no barrel pic
            icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel");
        }
        ClickedBox.GetComponent<DBofBox>().callImage();
        ClickedBox.GetComponent<DBofBox>().callOption();
        string[] on99 = ClickedBox.GetComponent<DBofBox>().getAns();
        for (int x = 0; x < on99.Length; x++)
        {
            Debug.Log(on99[x]);
        }
        Debug.Log("---------------------------");
;
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
        choose.Add(msg);
    }
    public void removeOption(string msg)
    {
        choose.Remove(msg);
    }
    public void checkAns()
    {
        string[] ans = ClickedBox.GetComponent<DBofBox>().getAns();
        if (staticHolder.InProcedure5)
        {
            int temp = 0;
            if (ans[0].Equals("correct"))
            {
                resultCheckList.AddCrossItem("It has no error!",true);
                if(ClickedBox.transform.name.Contains("barrel"))
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_X");
                else
                icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
            }
            else
            {
                for (int x = 0; x < ans.Length; x++)
                {
                    for (int y = 0; y < choose.Count; y++)
                    {
                        if (ans[x].Equals((string)choose[y]))
                        {
                            resultCheckList.AddTickItem((string)choose[y]);
                            choose.Remove(ans[x]);
                            ans[x] = null;
                            temp++;
                            break;
                        }
                    }
                }
                if (temp == ans.Length && choose.Count == 0)
                {
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_O");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");
                    correctBox++;
                    Debug.Log("allcorrect");
                }
                else if (!checkAllNull(ans)||choose.Count!=0)
                {
                    for (int x = 0; x < ans.Length; x++)
                    {
                        Debug.Log(ans[x]);
                    }
                    for (int x = 0; x < choose.Count; x++)
                    {
                        Debug.Log(choose[x]);
                    }
                    resultCheckList.AddCrossItem("<color=#CBB498>You are missing these error:</color>",false);
                    if (!checkAllNull(ans))
                    {
                        for (int x = 0; x < ans.Length; x++)
                        {
                            if (ans[x] != null)
                            {
                                resultCheckList.AddCrossItem(ans[x], true);
                            }
                        }
                    }
                    resultCheckList.AddCrossItem("<color=#CBB498>You choose these wrong answers:</color>", false);
                    if (choose.Count != 0)
                    {
                        for (int x = 0; x < choose.Count; x++)
                        {
                            if (choose[x] != null)
                            {
                                resultCheckList.AddCrossItem((string)choose[x],true);
                            }
                        }
                    }
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_X");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");

                }
                /*
                if (temp == ans.Length)
                {
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_O");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");
                    correctBox++;
                    correctboxstatic++;
                }
                else if (temp < ans.Length)
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
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_X");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
                }
                else if
                { 
                    
                }
                               */
            }

        }
        else
        {
            if (ans[0] == "correct")
            {
                resultCheckList.AddTickItem("You are correct!");
                if (ClickedBox.transform.name.Contains("barrel"))
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_O");
                else
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");
                correctBox++;
            }
            else
            {
                resultCheckList.AddCrossItem("<color=#CBB498>You are missing these error:</color>",false);
                for (int x = 0; x < ans.Length; x++)
                {
                    resultCheckList.AddCrossItem(ans[x], true);
                }
                if (ClickedBox.transform.name.Contains("barrel"))
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_X");
                else
                    icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
            }
        }
        HowManyBox++;
    }
    public void resetVar()
    {
        //******************
        //Now only Time Trial, may not work with other
        //******************
        Debug.Log(correctBox);
            StaticObjOrVar.NewGameUI[5].enabled = false;
            resultCheckList.RemoveAll();
            resultCheckList.GetComponentInParent<Canvas>().enabled = false;
            Destroy(ClickedBox);
            bg.SetActive(false);
            getBox = false;
            StaticObjOrVar.NewGameUI[0].enabled = false;
        
        if (HowManyBox == numberOfBox|| timerHolder.getTimerFloat()<=0)
        {
            StaticObjOrVar.NewGameUI[7].enabled = true;
            //FinishLevel/TotalTime/Time
            StaticObjOrVar.NewGameUI[7].transform.GetChild(1).transform.GetChild(1).GetComponent<TMP_Text>().text = ""+ (int)timerHolder.getTimerFloat();
            //FinishLevel/Score/Time
            StaticObjOrVar.NewGameUI[7].transform.GetChild(2).transform.GetChild(1).GetComponent<TMP_Text>().text = ""+((int)timerHolder.getTimerFloat()*correctBox);
            //set correct box text
            StaticObjOrVar.NewGameUI[7].transform.GetChild(4).transform.GetChild(2).GetComponent<TMP_Text>().text = "" + correctBox;
            int temp = PackageICON.transform.childCount;
            for (int x = 0; x < temp; x++)
            {
                PackageICON.transform.GetChild(0).parent = StaticObjOrVar.NewGameUI[7].transform.GetChild(3).transform;
            }
            timerHolder.disableTimerCanvas();//disable timer display when display result panel
            
        }
    }

    bool checkAllNull(string[] checkObj)
    {
        for (int x = 0; x < checkObj.Length; x++)
        {
            if (checkObj != null)
                return false;
        }
        return true;
    }
    public static boxesController getController()
    {
        return controller;
    }
}
