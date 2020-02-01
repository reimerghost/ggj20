using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] manoJugador1;
    public GameObject[] manoJugador2;

    private GameObject badGuys;
    private GameObject ecoAccion;
    void Start()
    {
        badGuys = GameObject.Find("BadGuys");
        ecoAccion = GameObject.Find("EcoAccion");

        //badGuys.GetComponent

        manoJugador1 = new GameObject[3];
        manoJugador2 = new GameObject[3];
        robarCartas(manoJugador1, 3);
        robarCartas(manoJugador2, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void robarCartas(GameObject[] mano, int n)
    {
        //TOMAR DEL MAZO
        for (int i=0; mano.Length > i; i++)
        {
            if (mano[i] == null) { 
            mano[i] = ecoAccion.GetComponent<Mazo>().robarCarta();
            }

        }
        //LLENAR LA MANO
    }

    private string usarCarta()
    {
        GameObject rt = manoJugador1[0];
        manoJugador1[0] = null;
        ecoAccion.GetComponent<Mazo>().descartarCarta(rt);
        return rt.GetComponent<GestorCarta>().Accion;
    }
}
