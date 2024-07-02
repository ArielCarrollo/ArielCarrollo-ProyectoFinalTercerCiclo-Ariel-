using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAppear : MonoBehaviour
{
    public Button myButton;
    private CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = myButton.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, 1f);
    }
}


