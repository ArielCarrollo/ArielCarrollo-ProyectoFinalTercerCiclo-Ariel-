using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject MusicSettings;
    public GameObject MenúCanvas;
    public GameObject Backtomenubutton;
    public GameObject Credits;
    public bool Onview = false;

    public void ShowAudioSettings()
    {
        if (Onview == false)
        {
            Onview = true;
            MusicSettings.GetComponent<TransitionEffectUI>().Move();
        }
        else
        {
            Onview = false;
            MusicSettings.GetComponent<TransitionEffectUI>().ReverseMove();
        }
    }
    public void EnableBacktoMenu()
    {
        if (Onview == true)
        {
            Backtomenubutton.SetActive(true);
        }
    }
    public void ShowCredits()
    {
        if (Onview == false)
        {
            Onview = true;
            Credits.GetComponent<TransitionEffectUI>().Move();
        }
        else
        {
            Onview = false;
            Credits.GetComponent<TransitionEffectUI>().ReverseMove();
        }
    }
    public void EnableMenúCanvas()
    {
        MenúCanvas.SetActive(true);
        Backtomenubutton.SetActive(false);
        MusicSettings.GetComponent<TransitionEffectUI>().ReverseMove();
        Onview = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
