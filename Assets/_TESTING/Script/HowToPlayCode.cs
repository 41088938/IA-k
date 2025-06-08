using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToPlayCode : MonoBehaviour
{
    // Start is called before the first frame update
    int page = 1;
    int Pagecount = 0;

    [SerializeField] Image img;

    void Start()
    {
        Pagecount = Resources.LoadAll("HowToPlay/").Length/2;
        img.sprite = Resources.Load<Sprite>("HowToPlay/"+page);
        Debug.Log(Pagecount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextPage()
    {
        if (page == Pagecount)
            page = 1;
        else
            page++;
        img.sprite = Resources.Load<Sprite>("HowToPlay/" + page);
    }
    public void PrevPage()
    {
        if (page == 1)
            page = Pagecount;
        else
            page--;
        img.sprite = Resources.Load<Sprite>("HowToPlay/" + page);
    }
}
