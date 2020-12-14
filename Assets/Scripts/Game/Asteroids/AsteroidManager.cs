using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;
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
    [SerializeField]
    private SoundManager _soundManager;
    [SerializeField]
    private VFXManager _vfxManager;

    public SoundManager SoundManager => _soundManager;
    public VFXManager VFXManager => _vfxManager;

    [Space]
    [SerializeField]
    private Transform[] _spawnLocations;

    private int _numberOfSmallAsteroids, _numberOfMediumAsteroids, _numberOfBigAsteroids;

    public int NumberOfSmallAsteroids => _numberOfSmallAsteroids;
    public int NumberOfMediumAsteroids => _numberOfMediumAsteroids;
    public int NumberOfBigAsteroids => _numberOfBigAsteroids;

    private void Awake()
    {
        _numberOfBigAsteroids = _numberOfMediumAsteroids = _numberOfSmallAsteroids = 0;
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

    public void AddSmallAsteroid(bool b)
    {
        if (b)
            _numberOfSmallAsteroids++;
        else
            _numberOfSmallAsteroids--;
    }

    public void AddMediumAsteroid(bool b)
    {
        if (b)
            _numberOfMediumAsteroids++;
        else
            _numberOfMediumAsteroids--;
    }

    public void AddBigAsteroid(bool b)
    {
        if (b)
            _numberOfBigAsteroids++;
        else
            _numberOfBigAsteroids--;
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

    internal void DeactivateAllAsteroids()
    {
        for (int i = 0; i < _smallAsteroids.Count; i++)
        {
            _smallAsteroids[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _mediumAsteroids.Count; i++)
        {
            _mediumAsteroids[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _bigAsteroids.Count; i++)
        {
            _bigAsteroids[i].gameObject.SetActive(false);
        }
        _numberOfBigAsteroids = _numberOfMediumAsteroids = _numberOfSmallAsteroids = 0;
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

    public void SpawnSmallAsteroids(int count)
    {
        List<SmallAsteroid> asteroids = GetSmallAsteroid(count);
        for (int i = 0; i < asteroids.Count; i++)
        {
            SpawnAsteroid(asteroids[i]);
        }
    }

    public void SpawnMediumAsteroids(int count)
    {
        List<MediumAsteroid> asteroids = GetMediumAsteroid(count);
        for (int i = 0; i < asteroids.Count; i++)
        {
            SpawnAsteroid(asteroids[i]);
        }
    }

    public void SpawnBigAsteroids(int count)
    {
        List<BigAsteroid> asteroids = GetBigAsteroid(count);
        for (int i = 0; i < asteroids.Count; i++)
        {
            SpawnAsteroid(asteroids[i]);
        }
    }

    private Transform GetRandomSpawn()
    {
        return _spawnLocations[UnityEngine.Random.Range(0, _spawnLocations.Length)];
    }

    private void SpawnAsteroid(IAsteroid asteroid)
    {
        asteroid.SetPositionAndRotation(GetRandomSpawn());
        asteroid.SetActive(true);
    }

    public void AddToScore(int points)
    {
        _gameController.AddToCurrentScore(points);
    }
}
