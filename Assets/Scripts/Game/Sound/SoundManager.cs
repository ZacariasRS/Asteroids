using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource background;
    [SerializeField]
    private AudioSource[] bullets;
    [SerializeField]
    private AudioSource bulletAuxiliar;
    [SerializeField]
    private AudioSource[] explosions;
    [SerializeField]
    private AudioSource explosionAuxiliar;
    [SerializeField]
    private AudioSource death;
    [SerializeField]
    private AudioSource respawn;

    public void DoBulletSound()
    {
        AudioSource source = null;
        for (int i = 0; i < bullets.Length && source == null; i++)
        {
            if (!bullets[i].isPlaying)
            {
                source = bullets[i];
            }
        }
        if (source != null)
        {
            source.Play();
        }
        else
        {
            bulletAuxiliar.Play();
        }
    }

    public void DoExplosionSound()
    {
        AudioSource source = null;
        for (int i = 0; i < explosions.Length && source == null; i++)
        {
            if (!explosions[i].isPlaying)
            {
                source = explosions[i];
            }
        }
        if (source != null)
        {
            source.Play();
        }
        else
        {
            explosionAuxiliar.Play();
        }
    }

    public void DoDeathSound()
    {
        death.Play();
    }

    public void DoRespawnSound()
    {
        respawn.Play();
    }

    public void ActivateBackgroundMusic(bool activate)
    {
        if (activate)
        {
            if (!background.isPlaying)
            {
                background.Play();
            }
        }
        else
        {
            if (background.isPlaying)
            {
                background.Stop();
            }
        }
    }
}
