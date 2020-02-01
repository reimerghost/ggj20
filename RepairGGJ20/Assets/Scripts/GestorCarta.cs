using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorCarta : MonoBehaviour
{
    Carta c;
    private enum estado { mazo,descarte,p1,p2};
    public string estadoActual;
    public string nombre;
    void Start()
    {
        
    }

    public void definirCarta(Carta card)
    {
        c = card;
        nombre = c.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
