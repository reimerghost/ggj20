using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomizer : MonoBehaviour
{
    public List<GameObject> environments;
    public Ambiente actualEnvironment;
    void OnEnable()
    {
        for(int i=0; i < environments.Count; i++)
        {
            environments[i].SetActive(false);
        }
        ChooseEnvironment();
    }
    void ChooseEnvironment()
    {
        List<int> available_options = GetAvailableOptions();
        int option = available_options[Random.Range(0, available_options.Count)];
        environments[option].SetActive(true);
        actualEnvironment = environments[option].GetComponent<Ambiente>();
        switch (option)
        {
            case 0:
                LevelController.Instance.mountain_Tile.Add(actualEnvironment);
                break;
            case 1:
                LevelController.Instance.forest_Tile.Add(actualEnvironment);
                break;
            case 2:
                LevelController.Instance.water_Tile.Add(actualEnvironment);
                break;
            case 3:
                LevelController.Instance.air_Tile.Add(actualEnvironment);
                break;
        }
    }

    List <int> GetAvailableOptions()
    {
        List<int> which_available = new List<int>();
        if (LevelController.Instance.mountain_Tile.Count < 4)
        {
            which_available.Add(0);
        }
        if (LevelController.Instance.forest_Tile.Count < 4)
        {
            which_available.Add(1);
        }
        if (LevelController.Instance.water_Tile.Count < 4)
        {
            which_available.Add(2);
        }
        if (LevelController.Instance.air_Tile.Count < 4)
        {
            which_available.Add(3);
        }
        return which_available;
    }
}