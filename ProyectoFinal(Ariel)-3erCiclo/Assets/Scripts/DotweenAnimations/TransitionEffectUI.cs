using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionEffectUI : MonoBehaviour
{
    public Transform UIobject;
    public Transform objetive;
    public Transform objetiveReverse;
    private Tween currentTween; 

    public void Move()
    {
        currentTween = UIobject.DOMove(objetive.position, 1f);

        currentTween.OnComplete(() =>
        {
            Time.timeScale = 0f; 
        });
    }
    public void ReverseMove()
    {
        Time.timeScale = 1;
        UIobject.DOMove(objetiveReverse.position, 1f);
    }
    private void Start()
    {
        if(this.gameObject.tag == "Instructions")
        {
            Move();
        }
    }
}
