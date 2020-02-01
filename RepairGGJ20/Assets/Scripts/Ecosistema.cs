using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecosistema : MonoBehaviour
{
    enum estados { Limpio, Peligro, Desastre };
    private estados EstadoActual;

    void Start()
    {
        EstadoActual = estados.Limpio;
    }

    void Update()
    {

    }

    private void ContaminarEco()
    {
        switch (EstadoActual)
        {
            case estados.Limpio:
                {
                    EstadoActual = estados.Peligro;
                    break;
                }
            case estados.Peligro:
                {
                    EstadoActual = estados.Desastre;
                    break;
                }
        }
    }
private void DesastreEco()
{
        EstadoActual = estados.Desastre;
}

}
