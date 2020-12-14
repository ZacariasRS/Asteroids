using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] explosionVFX;

    public void DoExplosionVFX(Transform t)
    {
        ParticleSystem particleSystem = null;
        for (int i = 0; i < explosionVFX.Length && particleSystem == null; i++)
        {
            if (!explosionVFX[i].isPlaying)
            {
                particleSystem = explosionVFX[i];
            }
        }
        PutParticleSystemInPositionAndPlay(particleSystem, t);
    }

    private void PutParticleSystemInPositionAndPlay(ParticleSystem particleSystem, Transform t)
    {
        particleSystem.transform.position = t.position;
        particleSystem.Play();
    }
}
