using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimesData", menuName = "Game/BestTimetoComplete", order = 1)]
public class TimeData : ScriptableObject
{
    public ListaInventadaPropia<float> Times = new ListaInventadaPropia<float>();
}
