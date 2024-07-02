using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public ListaInventadaPropia<Transform> Ubicaciones;
    public Transform SP;
    public Transform SP2;
    public Transform SP3;
    public Transform SP4;
    public Transform SP5;
    public Transform SP6;
    public Transform SP7;
    public Transform SP8;
    public Transform SP9;
    public Transform SP10;
    public ListaInventadaPropia<GameObject> Objects;
    public GameObject O1;
    public GameObject O2;
    public GameObject O3;
    public GameObject O4;
    public GameObject O5;
    public GameObject O6;
    public GameObject O7;
    public GameObject O8;
    public GameObject O9;
    private ListaInventadaPropia<int> indicesDisponibles;


    private void OnEnable()
    {
        Ubicaciones = new ListaInventadaPropia<Transform>();
        Objects = new ListaInventadaPropia<GameObject>();
        Ubicaciones.InsertNodeAtStart(SP);
        Ubicaciones.InsertNodeAtEnd(SP2);
        Ubicaciones.InsertNodeAtEnd(SP3);
        Ubicaciones.InsertNodeAtEnd(SP4);
        Ubicaciones.InsertNodeAtEnd(SP5);
        Ubicaciones.InsertNodeAtEnd(SP6);
        Ubicaciones.InsertNodeAtEnd(SP7);
        Ubicaciones.InsertNodeAtEnd(SP8);
        Ubicaciones.InsertNodeAtEnd(SP9);
        Ubicaciones.InsertNodeAtEnd(SP10);
        Objects.InsertNodeAtEnd(O1);
        Objects.InsertNodeAtEnd(O2);
        Objects.InsertNodeAtEnd(O3);
        Objects.InsertNodeAtEnd(O4);
        Objects.InsertNodeAtEnd(O5);
        Objects.InsertNodeAtEnd(O6);
        Objects.InsertNodeAtEnd(O7);
        Objects.InsertNodeAtEnd(O8);
        Objects.InsertNodeAtEnd(O9);
    }
    private void Start()
    {
        indicesDisponibles = new ListaInventadaPropia<int>();
        for (int i = 0; i < Ubicaciones.Length; i++)
        {
            indicesDisponibles.InsertNodeAtEnd(i);
        }
        MoverObjetos();
    }

    private void MoverObjetos()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            int indiceAleatorio = Random.Range(0, indicesDisponibles.Length);
            int indiceSeleccionado = indicesDisponibles.ObtainNodeAtPosition(indiceAleatorio);
            Objects.ObtainNodeAtPosition(i).transform.position = Ubicaciones.ObtainNodeAtPosition(indiceSeleccionado).position;
            indicesDisponibles.DeleteNodeAtPosition(indiceAleatorio);
        }
    }
}

