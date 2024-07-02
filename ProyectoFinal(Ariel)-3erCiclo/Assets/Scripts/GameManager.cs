using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public GaugeData gaugeData;
    public TimeData timeData;
    public float Times = 60f;
    public GameObject Backpack;
    void Update()
    {
        Times -= Time.deltaTime;
        Times = Mathf.Clamp(Times, Backpack.GetComponent<BackpackScript>().TimeLimiter, 60f);
        TimeText.text = "Tiempo: " + Times.ToString("F0");

        if (Times <= 0)
        {
            SaveTimeAndLoadFinalScene();
        }
        if (gaugeData.currentValue == 100)
        {
            SaveTimeAndLoadFinalScene();
        }
    }
    void SaveTimeAndLoadFinalScene()
    {
        timeData.Times.InsertNodeAtEnd(60f - Times);
        SceneManager.LoadScene("Final");
    }
}
