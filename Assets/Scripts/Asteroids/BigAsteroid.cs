using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : Asteroid<BigAsteroidConfiguration>
{
    protected override void DestroyAsteroid()
    {
        base.DestroyAsteroid();
        List<MediumAsteroid> asteroids = _asteroidManager.GetMediumAsteroid(_asteroidConfiguration.AsteroidsToSpawn);
        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[i].transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            asteroids[i].RotateRandom();
            asteroids[i].gameObject.SetActive(true);
        }
    }
}
