using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameConfiguration _gameConfiguration;
    [SerializeField]
    private Transform _shipSpawn;

    [SerializeField]
    private AsteroidManager _asteroidManager;
    [SerializeField]
    private BulletManager _bulletManager;
    [SerializeField]
    private Ship _ship;
    [SerializeField]
    private GameUI _gameUI;

    private int _currentHealth;
    private int _currentScore;
    private float _startTime;
    private float _lastSpawnTime;
    private bool _spawnAsteroids;

    private int _currentDifficulty;

    private Coroutine _spawnAsteroidsCR;
    private Coroutine _switchDifficultyCR;

    private GameDifficulty CurrentDifficulty => _gameConfiguration.GameDifficulties[_currentDifficulty];
    private void Awake()
    {
        _currentDifficulty = 0;
        _currentHealth = _gameConfiguration.NumberOfLives;
        _currentScore = 0;
        _gameUI.UpdateHealth(_currentHealth);
        _gameUI.UpdateScore(_currentScore);
        _gameUI.UpdateHighScore();
    }

    private void Start()
    {
        SetUpGame();
    }

    public void AddToCurrentScore(int points)
    {
        Debug.Log("Adding To CurrentScore: " + points + ", total score: " + _currentScore);
        _currentScore += points;
        _gameUI.UpdateScore(_currentScore);
    }

    public void RemoveHealth()
    {
        _currentHealth--;
        _gameUI.UpdateHealth(_currentHealth);
    }

    internal void ShipDestroyed()
    {
        StopCoroutine(_spawnAsteroidsCR);
        StopCoroutine(_switchDifficultyCR);
        _spawnAsteroids = false;
        _bulletManager.DeactiveAllBullets();
        _asteroidManager.DeactivateAllAsteroids();
        _ship.AcceptInput(false);
        RemoveHealth();
        if (_currentHealth > 0)
        {
            SetUpGameAfterDeath();
        }
        else
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        if (_currentScore > PlayerPrefs.GetInt("HighScore", -1))
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            _gameUI.UpdateHighScore();
        }
        _gameUI.ShowGameOverPanel();
    }

    private void SetUpGameAfterDeath()
    {
        StartCoroutine(SetUpGameAfterDeathCR());
    }

    private IEnumerator SetUpGameAfterDeathCR()
    {
        yield return new WaitForSeconds(_gameConfiguration.TimeBetweenDeath);
        SetUpGame();
    }

    private void SetUpGame()
    {
        _ship.transform.position = _shipSpawn.transform.position;
        _ship.transform.rotation = _shipSpawn.transform.rotation;
        _ship.AcceptInput(true);
        _ship.ActivateShip(true);
        _startTime = Time.time;
        _lastSpawnTime = float.MinValue;
        _switchDifficultyCR = StartCoroutine(SwitchDifficultyCR());
        _spawnAsteroidsCR = StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SwitchDifficultyCR()
    {
        while (_currentDifficulty < _gameConfiguration.GameDifficulties.Length)
        {
            yield return new WaitForSeconds(_gameConfiguration.timeToSwitchDifficulty);
            _currentDifficulty++;
        }
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            if (_asteroidManager.NumberOfSmallAsteroids < CurrentDifficulty.MinimumSmallAsteroids)
            {
                _asteroidManager.SpawnSmallAsteroids(1);
            }
            else if (_asteroidManager.NumberOfMediumAsteroids < CurrentDifficulty.MinimumMediumAsteroids)
            {
                _asteroidManager.SpawnMediumAsteroids(1);
            }
            else if (_asteroidManager.NumberOfBigAsteroids < CurrentDifficulty.MinimumBigAsteroids)
            {
                _asteroidManager.SpawnBigAsteroids(1);
            }
            yield return new WaitForSeconds(CurrentDifficulty.TimeBetweenSpawns);
        }
    }
}
