using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiente : MonoBehaviour
{
    int remaining_Lives;
    public bool isDead = false;
    public int cual_Ambiente_Soy;
    public Mesh[] meshes;
    public MeshFilter mesh_Filter;
    public MeshRenderer mesh_Renderer;
    public ParticleSystem air_particles;
    int revivingCount = 0;

    private void OnEnable()
    {
        remaining_Lives = 3;
        isDead = false;
        revivingCount = 0;
        ChangeVisual();
    }

    public void Hurt()
    {
        if (remaining_Lives >= 1)
        {
            remaining_Lives--;
            ChangeVisual();
        }
    }

    public void Kill()
    {
        if (remaining_Lives <= 0) { return; }
        remaining_Lives = 0;
        isDead = true;
        ChangeVisual();
    }

    public void Cure()
    {
        if (isDead)
        {
            AttemptRevive();
            return;
        }
        else
        {
            remaining_Lives++;
        }
        ChangeVisual();
    }

    void AttemptRevive()
    {
        if (revivingCount >= 1)
        {
            OnEnable();
        }
        else
        {
            revivingCount++;
        }
    }

    void ChangeVisual()
    {
        if (cual_Ambiente_Soy < 2)
        {
            //mesh_Filter.mesh = meshes[remaining_Lives];
        }
        else if(cual_Ambiente_Soy == 2)
        {
            mesh_Renderer.material = Globals.WaterMaterials[remaining_Lives];
        }
        else
        {
            ParticleSystem.MainModule air_particle_settings = air_particles.main;
            air_particle_settings.startColor = new ParticleSystem.MinMaxGradient(Globals.air_Particle_Colors[remaining_Lives]);
        }
    }
}
