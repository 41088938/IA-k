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
    public string[] Choose;
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
    [SerializeField]
    GameObject[] prefebs;
    [SerializeField] CanvasGroup Steps;
    //var
    public int correctBox = 0;
    public int baseScore = 20;
    GameObject[] pointsWithRand;
    public bool getBox = false;
    int numberOfBox = 0;
    public int HowManyBox = 0;
    static int correctboxstatic = 0;
    static boxesController controller = null;
    UnityEngine.InputSystem.Mouse mouse;

    // Start is called before the first frame update
    void Start()
    {
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
            numberOfBox = 4;
            icons = new Image[4];
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
            GameObject clone;
            int ran = UnityEngine.Random.Range(0, prefebs.Length);
            clone = Instantiate(prefebs[ran],new Vector3(0,0,0), new Quaternion(0,0,0,0));
            clone = Instantiate(prefebs[ran], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            clone.transform.parent = GameObject.Find("van/RandomBoxes").transform;
            clone.transform.position =  pointsWithRand[x].transform.position;
            if (prefebs[ran].transform.name.Contains("flammable"))
            clone.transform.Rotate(0, 180, 0);
            else if (prefebs[ran].transform.name.Contains("barrelpackage"))
                clone.transform.Rotate(-90, 0, 0);
            else
                clone.transform.Rotate(0, 90, 0);
            if (prefebs[ran].transform.name.Contains("barrelpackage"))
                clone.transform.Translate(0,0, 0.35f);
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
        Steps.interactable = true;
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
        string[] temp = ClickedBox.GetComponent<DBofBox>().getAns();
        for (int x = 0; x < temp.Length; x++)
        {
            Debug.Log(temp[x]);
        }
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
                    for (int y = 0; y < Choose.Length; y++)
                    {
                        if (ans[x] == Choose[y])
                        {
                            resultCheckList.AddTickItem(Choose[y]);
                            ans[x] = null;
                            Choose[y] = null;
                            temp++;
                            break;
                        }
                    }
                }
                if (temp == ans.Length && checkAllNull(Choose))
                {
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_O");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/O");
                    correctBox++;
                    correctboxstatic++;
                }
                else if (!checkAllNull(ans))
                {
                    resultCheckList.AddCrossItem("<color=#CBB498>You are missing these error:</color>",false);
                    for (int x = 0; x < ans.Length; x++)
                    {
                        if (ans[x] != null)
                        {
                            resultCheckList.AddCrossItem(ans[x], true);
                        }
                    }
                    resultCheckList.AddCrossItem("<color=#CBB498>You choose these wrong answers:</color>", false);
                    if (!checkAllNull(Choose))
                    {
                        for (int x = 0; x < Choose.Length; x++)
                        {
                            if (Choose[x] != null)
                            {
                                resultCheckList.AddCrossItem(Choose[x],true);
                            }
                        }
                    }
                    if (ClickedBox.transform.name.Contains("barrel"))
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/barrel_X");
                    else
                        icons[HowManyBox].sprite = Resources.Load<Sprite>("OX/X");
                }
                else if (!checkAllNull(Choose))
                {
                    resultCheckList.AddCrossItem("You choose these wrong answers:", false);
                    if (!checkAllNull(Choose))
                    {
                        for (int x = 0; x < Choose.Length; x++)
                        {
                            if (Choose[x] != null)
                            {
                                resultCheckList.AddCrossItem(Choose[x],true);
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
                correctboxstatic++;
            }
            else
            {
                for (int x = 0; x < ans.Length; x++)
                {
                    resultCheckList.AddCrossItem(ans[x],true);
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
        Debug.Log(correctBox + " " + timerHolder.getTimerFloat());
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
            StaticObjOrVar.NewGameUI[7].transform.GetChild(2).transform.GetChild(1).GetComponent<TMP_Text>().text = ""+((int)timerHolder.getTimerFloat()+ baseScore*correctBox);
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
    public static void resetVarInTime()//for time trial, if no time
    {
        //******************
        //Now only Time Trial, may not work with other
        //******************
         TimerCode.getDisableTimerCanvas();//disable timer display when display result panel

        GameObject temp2 = GameObject.Find("GameCommonUINew/GameObject");
        StaticObjOrVar.NewGameUI[7].enabled = true;
        //set time text
        StaticObjOrVar.NewGameUI[7].transform.GetChild(1).GetComponent<TMP_Text>().text = "" + "0";//(int)TimerCode.getTimerLeftStatic();
        //set total score text, remain time * correct box
        StaticObjOrVar.NewGameUI[7].transform.GetChild(2).transform.GetChild(1).GetComponent<TMP_Text>().text = "" + ((int)TimerCode.getTimerLeftStatic() * correctboxstatic);
        //set correct box text
        StaticObjOrVar.NewGameUI[7].transform.GetChild(4).transform.GetChild(2).GetComponent<TMP_Text>().text = "" + correctboxstatic;
        int temp = temp2.transform.childCount;
        for (int x = 0; x < temp; x++)
        {
            temp2.transform.GetChild(0).parent = StaticObjOrVar.NewGameUI[7].transform.GetChild(3).transform;
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
