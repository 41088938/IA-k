using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePageManuel : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] GameObject ButtonList;
    [SerializeField] Scrollbar scrollbar;

    private void Start()
    {
        scrollbar.value = PlayerPrefs.GetFloat("Volume", 0.5f);

   
    }
    public void StartButton()
    {
        SceneManager.LoadScene("TimeTrial");
    }
    public void OptionButton()
    {
        menu.enabled = true;
        ButtonList.SetActive(false);
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
    public void closeMenu()
    {
        menu.enabled = false;
        ButtonList.SetActive(true);
    }
    public void changeVolume()
    {
        PlayerPrefs.SetFloat("Volume", scrollbar.value);
    }
    public void addPage()
    { 
        
    }
    public void deductPage()
    { 
    
    }
    
}
