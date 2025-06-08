using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] TimerCode timer;
    [SerializeField] boxesController boxescontroller;
    // Start is called before the first frame update
    void Start()
    {
        setVolume(PlayerPrefs.GetFloat("Volume", 0.5f));
        scrollbar.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setVolume(float v)
    {
        PlayerPrefs.SetFloat("Volume", v);
        audioSource.volume = v;
    }

    public void setVolume()
    {
        PlayerPrefs.SetFloat("Volume", scrollbar.value);
        audioSource.volume = scrollbar.value;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void returnOutside()
    { 
        this.gameObject.GetComponent<Canvas>().enabled = false;
        timer.setTimerStop(false);
        boxescontroller.ClickedBox.GetComponent<Rotate3DObject1>().pause = false;
        StaticObjOrVar.NewGameUI[0].enabled = true;
    }
    public void clickHowToPlay()
    { 
        this.gameObject.transform.transform.Find("HowToPlay").GetComponent<Canvas>().enabled = true;
    }
    public void returnMenu()
    {
        this.gameObject.transform.transform.Find("HowToPlay").GetComponent<Canvas>().enabled = false;
        
    }
    
}
