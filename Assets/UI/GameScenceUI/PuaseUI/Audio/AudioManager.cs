using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source--------")]
   [SerializeField]AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip clicking;//add line if new Audio Clip added

    private void Start()
    {
        musicSource.clip=background;
        musicSource.Play();
    }

    public void SoundEffect(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
