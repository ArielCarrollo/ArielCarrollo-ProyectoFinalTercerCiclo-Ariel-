using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GaugeData", menuName = "Game/GaugeData", order = 1)]
public class GaugeData : ScriptableObject
{
    public float currentValue = 0f;
    public void ResetGauge()
    {
        currentValue = 0f;
    }

    public void AddToGauge(float value)
    {
        currentValue += value;
        currentValue = Mathf.Clamp(currentValue, 0f, 100f);
    }
}
