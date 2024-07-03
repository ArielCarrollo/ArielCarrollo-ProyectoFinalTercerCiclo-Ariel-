using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    public MiCola<GameObject> instruccionesQueue;
    public GameObject Instrucciones1;
    public GameObject Instrucciones2;
    public GameObject Instrucciones3;
    public GameObject Instrucciones4;
    public GameObject Instrucciones4dos;
    public GameObject Instrucciones5;

    void Awake()
    {
        instruccionesQueue = new MiCola<GameObject>();
        instruccionesQueue.Enqueue(Instrucciones1);
        instruccionesQueue.Enqueue(Instrucciones2);
        instruccionesQueue.Enqueue(Instrucciones3);
        instruccionesQueue.Enqueue(Instrucciones4);
        instruccionesQueue.Enqueue(Instrucciones4dos);
        instruccionesQueue.Enqueue(Instrucciones5);
    }
    public void OcultarInstruccionActual()
    {
        if (instruccionesQueue.Head.Next == null)
        {
            this.gameObject.GetComponent<TransitionEffectUI>().ReverseMove();
        }
        else
        {
            instruccionesQueue.Head.Value.SetActive(false);
            instruccionesQueue.Dequeue();
        }
    }
}

