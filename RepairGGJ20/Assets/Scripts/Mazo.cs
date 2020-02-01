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
    void Start()
    {
        cartas.MezclarCartas();
        GameObject sep = new GameObject("----------");
        disponibles.Add(sep);
        foreach (var i in cartas)
        {
            GameObject c = new GameObject("__"+i.name);
            c.AddComponent<GestorCarta>(); //AÑADESAMIERDA!
            c.GetComponent<GestorCarta>().definirCarta(i);
            disponibles.Add(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Carta c = cartas[0];
        Debug.Log(c.Name);
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
