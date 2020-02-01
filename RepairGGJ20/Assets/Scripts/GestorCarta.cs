using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorCarta : MonoBehaviour
{
    Carta c;
    //private enum estado { mazo,descarte,p1,p2};
    public string estadoActual;
    public string nombre;
    public string Accion;
    void Start()
    {
        
    }

    public void definirCarta(Carta card)
    {
        c = card;
        nombre = c.name;
        Accion = c.accion;
        estadoActual = "MAZO";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
