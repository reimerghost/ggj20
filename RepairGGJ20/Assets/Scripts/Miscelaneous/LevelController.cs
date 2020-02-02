using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public List<Ambiente> water_Tile = new List<Ambiente>();
    public List<Ambiente> air_Tile = new List<Ambiente>();
    public List<Ambiente> forest_Tile = new List<Ambiente>();
    public List<Ambiente> mountain_Tile = new List<Ambiente>();
    public Material[] WaterMaterials;
    private void OnEnable()
    {
        Instance = this;
        water_Tile.Clear();
        air_Tile.Clear();
        forest_Tile.Clear();
        mountain_Tile.Clear();
        Globals.WaterMaterials = WaterMaterials;
        TileRandomizer[] tiles = GetComponentsInChildren<TileRandomizer>(true);
        for(int i =0; i < tiles.Length; i++)
        {
            tiles[i].gameObject.SetActive(true);
        }
    }

    public void Hurt(string tipo_ambiente)
    {
        ChooseAmbiente(tipo_ambiente)?.Hurt();
    }

    public void Kill(string tipo_ambiente)
    {
        ChooseAmbiente(tipo_ambiente)?.Kill();
    }

    Ambiente ChooseAmbiente(string tipo_ambiente)
    {
        List<Ambiente> cual_lista = GetLista(tipo_ambiente);
        if (!CheckLimit(cual_lista))
        {
            //TODO Die
            Debug.Log("DIE");
            return null;
        }
        List<Ambiente> can_be_damaged = GetDamageable(cual_lista);
        return ChooseWhichToDamage(can_be_damaged);
    }

    List<Ambiente> GetLista(string tipo_ambiente)
    {
        List<Ambiente> chosen = mountain_Tile;
        switch (tipo_ambiente.ToUpper())
        {
            case "WATER":
                chosen = water_Tile;
                break;
            case "FOREST":
                chosen = forest_Tile;
                break;
            case "AIR":
                chosen = air_Tile;
                break;
        }
        return chosen;
    }

    bool CheckLimit(List<Ambiente> lista)
    {
        int count_dead = 0;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].isDead)
            {
                count_dead++;
            }
        }
        return count_dead<3;
    }

    List<Ambiente> GetDamageable(List<Ambiente> cual_lista)
    {
        List<Ambiente> can_be_damaged = new List<Ambiente>();
        for(int i = 0; i < cual_lista.Count; i++)
        {
            if (!cual_lista[i].isDead)
            {
                can_be_damaged.Add(cual_lista[i]);
            }
        }
        return can_be_damaged;
    }

    Ambiente ChooseWhichToDamage(List<Ambiente> ambientes)
    {
        int option = Random.Range(0, ambientes.Count);
        return ambientes[option];
    }
}
