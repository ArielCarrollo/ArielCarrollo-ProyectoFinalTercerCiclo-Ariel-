using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource ButtonSound;

    public void PlayButtonSound()
    {
        ButtonSound.Play();
    }
}
