using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeveController : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject infoUI;
    private int level=0;
    #endregion 
    public void Start()
    {
        infoUI.SetActive(false);
    }
   
    public void BackButton()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void applyLevel(int x)
    {
        if (x == 0)
            SceneManager.LoadScene("GameScene_tester_non");//chang the scens name part to get to the right scens
        else if (x == 1)
            SceneManager.LoadScene("Intermediate_Level");
        else if (x == 2)
            SceneManager.LoadScene("Advance_Level");
        else if (x == 3)
            SceneManager.LoadScene("TimeTrial");
    }
    public void CloseInfoPage()
    {
        infoUI.SetActive(false);
    }
    public void InfoButton()
    {
        infoUI.SetActive(true);
    }
}
