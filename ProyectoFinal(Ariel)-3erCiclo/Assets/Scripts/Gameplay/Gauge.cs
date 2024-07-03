using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public GaugeData gaugeData; 
    public Slider slider; 

    void Update()
    {
        if (gaugeData != null && slider != null)
        {
            slider.value = gaugeData.currentValue;
        }
    }
}
