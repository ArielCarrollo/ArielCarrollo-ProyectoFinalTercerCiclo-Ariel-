using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackpackScript : MonoBehaviour
{
    public GameObject BackpackGauge;
    public GameObject Timer;
    public GameObject lightBackpack;
    public GameObject doorBlocker;
    public int TimeLimiter = 60;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            this.gameObject.SetActive(false);
            lightBackpack.SetActive(false);
            doorBlocker.SetActive(false);
            TimeLimiter = 0;
            BackpackGauge.GetComponent<TransitionEffectHUD>().Move();
            Timer.GetComponent<TransitionEffectHUD>().Move();
        }
    }
}

