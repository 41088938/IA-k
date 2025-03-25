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
    GameObject[] Boxes;
    GameObject[] BoxesSelected;
    [SerializeField] GameObject bg;
    GameObject ClickedBox = null;
    [SerializeField] GameObject BoxPoint;

    //Other
    Camera maincam;

    //var
    public bool getBox = false;
    bool turnBox = false;
    UnityEngine.InputSystem.Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        
        bg.SetActive(false);
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Boxes = GameObject.FindGameObjectsWithTag("box");
        Debug.Log(Boxes.Length);
        if (SceneManager.GetActiveScene().name== "GameScene_tester_non")
            BoxesSelected = new GameObject[3];
        for (int x = 0; x < BoxesSelected.Length; x++)
        {
            int ran = UnityEngine.Random.Range(0, Boxes.Length);
            BoxesSelected[x] = Boxes[ran];
            Boxes[ran].SetActive(false);
            Boxes = RemoveAt(Boxes, ran);
        }

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
    public void BoxClick()
    {
        StaticObjOrVar.GameUICanvas[0].enabled = true;
        bg.SetActive(true);
        getBox = true;
        ClickedBox.transform.position = BoxPoint.transform.position;
        
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

}
