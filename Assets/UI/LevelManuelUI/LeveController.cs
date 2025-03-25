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
    public void applyLevel()
    {
        
                SceneManager.LoadScene("GameScene_tester_non");//chang the scens name part to get to the right scens
         
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
