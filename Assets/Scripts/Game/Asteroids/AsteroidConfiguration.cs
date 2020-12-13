using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidConfiguration : ScriptableObject
{
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected int _points;

    public float Speed => _speed;
    public int Points => _points;
}
