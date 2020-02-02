using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Color[] air_Particle_Colors = new Color[] { Color.black, Color.gray, Color.Lerp(Color.gray, Color.white, 0.5f), Color.white };
    public static Material[] WaterMaterials;
}
