using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDifficulty
{
    [SerializeField]
    private int _minimumSmallAsteroids;
    [SerializeField]
    private int _minimumMediumAsteroids;
    [SerializeField]
    private int _minimumBigAsteroids;
    [SerializeField]
    private float _timeBetweenSpawns;

    public int MinimumSmallAsteroids => _minimumSmallAsteroids;
    public int MinimumMediumAsteroids => _minimumMediumAsteroids;
    public int MinimumBigAsteroids => _minimumBigAsteroids;
    public float TimeBetweenSpawns => _timeBetweenSpawns;
}
[CreateAssetMenu(fileName = "GameConfiguration", menuName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    [SerializeField]
    private GameDifficulty[] _gameDifficulties;
    [SerializeField]
    private float _timeToSwitchDifficulty;
    [SerializeField]
    private int _numberOfLives;
    [SerializeField]
    private int _timeBetweenDeath;

    public GameDifficulty[] GameDifficulties => _gameDifficulties;
    public float timeToSwitchDifficulty => _timeToSwitchDifficulty;
    public int NumberOfLives => _numberOfLives;
    public int TimeBetweenDeath => _timeBetweenDeath;
}
