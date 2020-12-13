using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private List<SmallAsteroid> _smallAsteroids;
    [SerializeField]
    private SmallAsteroid _smallAsteroidPrefab;
    [SerializeField]
    private List<MediumAsteroid> _mediumAsteroids;
    [SerializeField]
    private MediumAsteroid _mediumAsteroidPrefab;
    [SerializeField]
    private List<BigAsteroid> _bigAsteroids;
    [SerializeField]
    private BigAsteroid _bigAsteroidPrefab;

    private void Awake()
    {
        for (int i = 0; i < _smallAsteroids.Count; i++)
        {
            _smallAsteroids[i].SetAsteroidManager(this);
        }
        for (int i = 0; i < _mediumAsteroids.Count; i++)
        {
            _mediumAsteroids[i].SetAsteroidManager(this);
        }
        for (int i = 0; i < _bigAsteroids.Count; i++)
        {
            _bigAsteroids[i].SetAsteroidManager(this);
        }
    }

    public List<SmallAsteroid> GetSmallAsteroid(int count)
    {
        List<SmallAsteroid> smallAsteroids = new List<SmallAsteroid>();
        for (int i = 0; i < _smallAsteroids.Count && smallAsteroids.Count < count; i++)
        {
            if (!_smallAsteroids[i].IsActive())
            {
                smallAsteroids.Add(_smallAsteroids[i]);
            }
        }
        if (smallAsteroids.Count < count)
        {
            for (int i = smallAsteroids.Count; i < count; i++)
            {
                SmallAsteroid smallAsteroid = Instantiate(_smallAsteroidPrefab);
                _smallAsteroids.Add(smallAsteroid);
                smallAsteroids.Add(smallAsteroid);
            }
        }
        return smallAsteroids;
    }

    public List<MediumAsteroid> GetMediumAsteroid(int count)
    {
        List<MediumAsteroid> mediumAsteroids = new List<MediumAsteroid>();
        for (int i = 0; i < _mediumAsteroids.Count && mediumAsteroids.Count < count; i++)
        {
            if (!_mediumAsteroids[i].IsActive())
            {
                mediumAsteroids.Add(_mediumAsteroids[i]);
            }
        }
        if (mediumAsteroids.Count < count)
        {
            for (int i = mediumAsteroids.Count; i < count; i++)
            {
                MediumAsteroid mediumAsteroid = Instantiate(_mediumAsteroidPrefab);
                _mediumAsteroids.Add(mediumAsteroid);
                mediumAsteroids.Add(mediumAsteroid);
            }
        }
        return mediumAsteroids;
    }

    public List<BigAsteroid> GetBigAsteroid(int count)
    {
        List<BigAsteroid> bigAsteroids = new List<BigAsteroid>();
        for (int i = 0; i < _bigAsteroids.Count && bigAsteroids.Count < count; i++)
        {
            if (!_bigAsteroids[i].IsActive())
            {
                bigAsteroids.Add(_bigAsteroids[i]);
            }
        }
        if (bigAsteroids.Count < count)
        {
            for (int i = bigAsteroids.Count; i < count; i++)
            {
                BigAsteroid bigAsteroid = Instantiate(_bigAsteroidPrefab);
                _bigAsteroids.Add(bigAsteroid);
                bigAsteroids.Add(bigAsteroid);
            }
        }
        return bigAsteroids;
    }
}
