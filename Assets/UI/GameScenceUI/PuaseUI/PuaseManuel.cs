using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PuaseManuel : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject inforUI;
    [SerializeField] GameObject replayUI;
    [SerializeField] GameObject exitUI;
    
    [SerializeField] GameObject stageinfoUI;
    [SerializeField] GameObject audioUI;
    [SerializeField] GameObject languageUI;

    [SerializeField] Text rounds;
    [SerializeField]
   
    AnserControler ac_controler;
   
    
    AudioManager audioManager;//get audioManager
    
    

    #endregion

    public void Start()
    {
        pauseUI.SetActive(false);
        replayUI.SetActive(false);
        inforUI.SetActive(false);
        exitUI.SetActive(false);

    }
    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();//get audioManager
    }
 
   //RTUI
    public void PauseGame()
    {
        audioManager.SoundEffect(audioManager.clicking);//call audioManager to player soundeffect, clicking is the clip name set at sc Audio Manager
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        stageinfoUI.SetActive(true);
        audioUI.SetActive(false);
        languageUI.SetActive(false);
        udateRound();

        replayUI.SetActive(false);
        inforUI.SetActive(false);
    }
    //replay
    public void Replay()
    {
        Time.timeScale = 0;
        
        audioManager.SoundEffect(audioManager.clicking);
        replayUI.SetActive(true);
        pauseUI.SetActive(false);
        inforUI.SetActive(false);

    }
    public void replayYesbutton()
    {
        audioManager.SoundEffect(audioManager.clicking);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//restart the scence
        Time.timeScale = 1;
    }
    public void replayNobutton()
    {
        audioManager.SoundEffect(audioManager.clicking);
        replayUI.SetActive(false);
        exitUI.SetActive(false);
        Time.timeScale = 1;
    }
    //end replay

    public void ResumeGame()
    {
        audioManager.SoundEffect(audioManager.clicking);
        pauseUI.SetActive(false);
        inforUI.SetActive(false);
        replayUI.SetActive(false);
        Time.timeScale = 1;
    }
    //infoUI (clos button use ResumeGame()) 
    public void InformationManuel()
    {
        
        audioManager.SoundEffect(audioManager.clicking);
        replayUI.SetActive(false);
        pauseUI.SetActive(false);
        inforUI.SetActive(true);
        Time.timeScale = 0;
    }
    
   //BackButton and NextButton infoPageManager

    //end infoUI
    //end RTUI
    
    //Exit UI
    public void ExitGame()
    {
        audioManager.SoundEffect(audioManager.clicking);
        exitUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 0;

    }
    public void exitYesButton()
    {
        audioManager.SoundEffect(audioManager.clicking);
        Time.timeScale = 1;
        SceneManager.LoadScene("lv");//chang the scens name part to get to the right scens
    }
    public void exitNobutton()
    {
        audioManager.SoundEffect(audioManager.clicking);
        replayUI.SetActive(false);
        exitUI.SetActive(false);
        pauseUI.SetActive(true);
    }
    //end Exit UI
    public void StageInfoUI()
    {
        
        audioManager.SoundEffect(audioManager.clicking);
        stageinfoUI.SetActive(true);
        audioUI.SetActive(false);
        languageUI.SetActive(false);

        replayUI.SetActive(false);
        inforUI.SetActive(false);
    }

    public void udateRound()
    {
        int p = ac_controler.GetCrentCatNumber() + 1;
        rounds.text =p.ToString("0 /5");
    }

    public void AudioManuel()
    {
        audioManager.SoundEffect(audioManager.clicking);
        stageinfoUI.SetActive(false);
        audioUI.SetActive(true);
        languageUI.SetActive(false);

        replayUI.SetActive(false);
        inforUI.SetActive(false);
    }
    public void LanguageSetting()
    {
        audioManager.SoundEffect(audioManager.clicking);
        stageinfoUI.SetActive(false);
        audioUI.SetActive(false);
        languageUI.SetActive(true);

        replayUI.SetActive(false);
        inforUI.SetActive(false);
    }
    
    
}
