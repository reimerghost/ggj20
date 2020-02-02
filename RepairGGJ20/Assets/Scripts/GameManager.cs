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

    public GameObject lc;

    void Start()
    {
        lc = GameObject.Find("Level");
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
        for (int i = 0; mano.Length > i; i++)
        {
            if (mano[i] == null)
            {
                mano[i] = ecoAccion.GetComponent<Mazo>().robarCarta();
            }

        }
        //LLENAR LA MANO
    }

    private void usarCartaPlayer(int pos)
    {
        GameObject enUso = manoJugador1[pos];
        manoJugador1[pos] = null;
        ecoAccion.GetComponent<Mazo>().descartarCarta(enUso);
        string act = enUso.GetComponent<GestorCarta>().Accion;

    }

    private void usarCartaDesastre()
    {
        GameObject enUso = badGuys.GetComponent<Mazo>().disponibles[0];
        badGuys.GetComponent<Mazo>().descartarCarta(enUso);
        string act = enUso.GetComponent<GestorCarta>().Accion;
        switch (act)
        {
            case "AGUA":
                {
                    lc.GetComponent<LevelController>().Hurt("Water");
                    break;
                }
            case "AIRE":
                {
                    lc.GetComponent<LevelController>().Hurt("Air");
                    break;
                }
            case "TIERRA":
                {
                    lc.GetComponent<LevelController>().Hurt("Ground");
                    break;
                }
            case "BOSQUE":
                {
                    lc.GetComponent<LevelController>().Hurt("Forest");
                    break;
                }
            case "PETROLEO":
                {
                    lc.GetComponent<LevelController>().Kill("Water");
                    break;
                }
            case "POLUCION":
                {
                    lc.GetComponent<LevelController>().Kill("Air");
                    break;
                }
            case "SEQUIA":
                {
                    lc.GetComponent<LevelController>().Kill("Ground");
                    break;
                }
            case "INCENDIO":
                {
                    lc.GetComponent<LevelController>().Kill("Forest");
                    break;
                }
        }
    }
}
