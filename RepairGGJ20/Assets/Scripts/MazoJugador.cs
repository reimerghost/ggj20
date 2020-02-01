using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazoJugador : MonoBehaviour
{

    public List<Carta> disponible;
    public List<Carta> descarte;


    // Start is called before the first frame update
    void Start()
    {
        disponible.MezclarCartas();
    }

    // Update is called once per frame
    void Update()
    {
        Carta c = disponible[0];
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
