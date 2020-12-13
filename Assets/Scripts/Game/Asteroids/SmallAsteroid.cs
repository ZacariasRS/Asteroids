using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : Asteroid<SmallAsteroidConfiguration>
{
    public override void SetActive(bool active)
    {
        base.SetActive(active);
        _asteroidManager.AddSmallAsteroid(active);
    }
}
