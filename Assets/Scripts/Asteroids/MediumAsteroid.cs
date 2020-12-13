using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroid : Asteroid<MediumAsteroidConfiguration>
{
    protected override void DestroyAsteroid()
    {
        base.DestroyAsteroid();
        List<SmallAsteroid> asteroids = _asteroidManager.GetSmallAsteroid(_asteroidConfiguration.AsteroidsToSpawn);
        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[i].transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            asteroids[i].RotateRandom();
            asteroids[i].gameObject.SetActive(true);
        }
    }
}
