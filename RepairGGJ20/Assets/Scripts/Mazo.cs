using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mazo : MonoBehaviour
{

    public List<Carta> cartas;
    public List<GameObject> disponibles;
    public List<GameObject> descarte;
    public GameObject ins;

    // Start is called before the first frame update
    void Awake()
    {
        Mezclar();
    }

    public void Mezclar()
    {
        cartas.MezclarCartas();
        //GameObject sep = new GameObject("----------");
        //Instantiate(sep);
        foreach (var i in cartas)
        {
            GameObject c = new GameObject("__" + i.name);
            c.AddComponent<GestorCarta>(); //AÑADESAMIERDA!
            c.GetComponent<GestorCarta>().definirCarta(i);
            disponibles.Add(c);
        }
        descarte.Clear();
    }

    public void Remezclar()
    {
        descarte.MezclarCartas();
        foreach (var el in descarte)
        {
            disponibles.Add(el);
        }
        descarte.Clear();
    }

    public void descartarCarta(GameObject desca)
    {
        descarte.Add(desca);
        disponibles.Remove(desca);
        desca.GetComponent<GestorCarta>().estadoActual = "DESCARTE";
    }

    public GameObject robarCarta()
    {
        GameObject rt = disponibles[0];
        disponibles.Remove(rt);
        rt.GetComponent<GestorCarta>().estadoActual = "MANO";
        return rt;

    }

}

public static class ListExtensions
{
    public static void MezclarCartas<T>(this IList<T> list)
    {
        System.Random rnd = new System.Random();

        for (var i = 0; i < list.Count; i++)
            list.Swap(i, rnd.Next(i, list.Count));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
