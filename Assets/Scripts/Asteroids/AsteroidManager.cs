using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private List<SmallAsteroid> _smallAsteroids;
    [SerializeField]
    private List<MediumAsteroid> _mediumAsteroids;
    [SerializeField]
    private List<BigAsteroid> _bigAsteroids;
}
