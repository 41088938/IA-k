using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    [SerializeField]private Slider volumeSlider;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider soundEffectSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")|| PlayerPrefs.HasKey("AllVolume")|| PlayerPrefs.HasKey("SoundEffectVolume"))
        {
            LoadVoulume();
        }
        else
        {
            SetMusicVolume();
            SetVolume();
            SetSoundEffectVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;//Controller with Slider
        audioMixer.SetFloat("Music",Mathf.Log10(volume)*20);

        PlayerPrefs.SetFloat("musicVolume",volume);//save in PlayerPrefs
    }
    public void SetVolume()
    {
        float volume = volumeSlider.value;//Controller with Slider
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("AllVolume",volume);//save in PlayerPrefs
    }
    public void SetSoundEffectVolume()
    {
        float volume = soundEffectSlider.value;
        audioMixer.SetFloat("SoundEffect", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);//save in PlayerPrefs
    }

    private void LoadVoulume()
    {
        musicSlider.value=PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();//set background music volume

        volumeSlider.value=PlayerPrefs.GetFloat("AllVolume");
        SetVolume();//set all volume

        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume");
        SetSoundEffectVolume();//set sound effect volume
    }
   
}
