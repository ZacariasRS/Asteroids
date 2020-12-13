using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroidConfiguration : AsteroidConfiguration
{
    [SerializeField]
    protected int _asteroidsToSpawn;

    public int AsteroidsToSpawn => _asteroidsToSpawn;
}
