using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextAppear : MonoBehaviour
{
    public TextMeshProUGUI myText;

    void Start()
    {
        Color initialColor = myText.color;
        initialColor.a = 0;
        myText.color = initialColor;
        myText.DOFade(1, 1f);
    }
}

