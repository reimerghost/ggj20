using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance = null;

    public GameObject[] manoJugador1;
    public GameObject[] manoJugador2;

    private GameObject badGuys;
    private GameObject ecoAccion;

    private GameObject DesastreActual;

    public GameObject lc;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        lc = GameObject.Find("Level");
        badGuys = GameObject.Find("BadGuys");
        ecoAccion = GameObject.Find("EcoAccion");
    }


    void Start()
    {

        //badGuys.GetComponent

        manoJugador1 = new GameObject[3];
        manoJugador2 = new GameObject[3];

        robarCartas(manoJugador1,1);
        robarCartas(manoJugador2,1);

        //tiempo = random.Next(10, 20);
        //InvokeRepeating("usarCartaDesastre", 5.0f, 0.3f);
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

    public void usarCartaPlayer(int pos, int player)
    {
        GameObject enUso;
        if (player == 1)
        {
            enUso = manoJugador1[pos];
            manoJugador1[pos] = ecoAccion.GetComponent<Mazo>().robarCarta();
        }
        else
        {
            enUso = manoJugador2[pos];
            manoJugador2[pos] = ecoAccion.GetComponent<Mazo>().robarCarta();
        }
        if (enUso != null) { 
        ecoAccion.GetComponent<Mazo>().descartarCarta(enUso);
        }
        string act = enUso.GetComponent<GestorCarta>().Accion;
        if (ecoAccion.GetComponent<Mazo>().disponibles.Count <= 0)
        {
            ecoAccion.GetComponent<Mazo>().Remezclar();
        }
    }

    public string showDesastreActual()
    {
        return DesastreActual.GetComponent<GestorCarta>().nombre;
    }

    public void usarCartaDesastre()
    {
        DesastreActual = badGuys.GetComponent<Mazo>().disponibles[0];
        if (DesastreActual != null) {
            badGuys.GetComponent<Mazo>().descartarCarta(DesastreActual);
        }
        string act = DesastreActual.GetComponent<GestorCarta>().Accion;
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
        Debug.Log(showDesastreActual());
        if (badGuys.GetComponent<Mazo>().disponibles.Count <= 0)
        {
            badGuys.GetComponent<Mazo>().Remezclar();
        }
    }
}
