using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalManager : MonoBehaviour
{
    [SerializeField] private Canvas Options;
    public GaugeData gaugestatus;
    public TimeData timeData;
    public MyOwnTree<Image> EndsTree;
    public Image Root;
    public Image Final1;
    public Image Final2;
    public Image Final3;
    public Image Final4;
    public Image Final5;
    public Image finalImage;
    public TextMeshProUGUI FinalDescriptionText;
    public TextMeshProUGUI TimesText;

    void Start()
    {
        Options = AudioManager.Instance.OptionsCanvas;
        EndsTree = new MyOwnTree<Image>();
        EndsTree.AddNode(Root, Root);
        EndsTree.AddNode(Final1, Root);
        EndsTree.AddNode(Final2, Root);
        EndsTree.AddNode(Final3, Root);
        EndsTree.AddNode(Final4, Root);
        EndsTree.AddNode(Final5, Root);

        if (gaugestatus != null)
        {
            finalImage.sprite = GetFinalBasedOnGauge(gaugestatus.currentValue).sprite;
        }
        DisplayGameTimes();
    }
    public Image GetFinalBasedOnGauge(float gaugeValue)
    {
        Image final = Root;

        if (gaugeValue <= 20f)
        {
            final = EndsTree.FindNode(Final1).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia es inutil, probablemente no sobrevivas.";
        }
        else if (gaugeValue <= 40f && gaugeValue > 20)
        {
            final = EndsTree.FindNode(Final2).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene poca utilidad, probablemente sobrevivas a rastras.";
        }
        else if (gaugeValue <= 60f && gaugeValue > 40)
        {
            final = EndsTree.FindNode(Final3).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene media utilidad, probablemente sobrevivas con varias heridas.";
        }
        else if (gaugeValue <= 80f && gaugeValue > 60)
        {
            final = EndsTree.FindNode(Final4).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene mucha utilidad, sobreviviras.";
        }
        else if (gaugeValue <= 100f && gaugeValue > 80)
        {
            final = EndsTree.FindNode(Final5).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia es de total utilidad, sobreviviras e incluso ayudaras a otros.";
        }
        return final;
    }

    void DisplayGameTimes()
    {
        timeData.Times = BubbleSort(timeData.Times);
        string timesString = "\n";
        for (int i = 0; i < timeData.Times.Length; i++)
        {
            timesString += "Puesto " + (i + 1) + ": " + timeData.Times.ObtainNodeAtPosition(i).ToString("F2") + " segundos\n";
        }
        TimesText.text = timesString;
        timeData.Times.PrintAllNodes();
    }

    public void ShowMenú()
    {
        Options.GetComponent<CanvasManager>().MenúCanvas.SetActive(true);
    }
    static ListaInventadaPropia<float> BubbleSort(ListaInventadaPropia<float> times)
    {
        float tmp;
        for (int i = 0; i < times.Length - 1; ++i)
        {
            for (int j = 0; j < times.Length - i - 1; ++j)
            {
                if (times.ObtainNodeAtPosition(j) > times.ObtainNodeAtPosition(j + 1))
                {
                    tmp = times.ObtainNodeAtPosition(j);
                    times.ModifyAtPosition(times.ObtainNodeAtPosition(j + 1), j);
                    times.ModifyAtPosition(tmp, j + 1);
                }
            }
        }
        return times;
    }
}



