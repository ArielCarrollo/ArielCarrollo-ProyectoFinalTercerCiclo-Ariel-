using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionEffectHUD : MonoBehaviour
{
    public Transform HUDObject;
    public Transform objetive; 

    public void Move()
    {
        HUDObject.DOMove(objetive.position, 1f);
    }
}

