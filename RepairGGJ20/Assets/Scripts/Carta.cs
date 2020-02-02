using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Carta", menuName = "Cartas")]
public class Carta : ScriptableObject
{
    public new string nombre;
    public string descripcion;

    public Sprite arte;
    public efecto effecto;
    //public string accion;

    public enum efecto
    {
        //EFECTOS POSITIVOS x 3
        MOVER, PLANTAR, LIMPIAR_AIRE, LIMPIAR_AGUA, LIMPIAR_TIERRA, 
        //ESPECIALES x 1
        RECICLAR, COMODIN, RANDOM,
        //EFECTOS NEGATIVOS x 4
        AGUA, AIRE, TIERRA, BOSQUE,
        //DESASTRE x 1
        PETROLEO, POLUCION, SEQUIA, INCENDIO
    };

    // EFECTOS DE LA CARTA
    public efecto getEfectoCarta()
    {
        return effecto;
    }


}
