using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletConfiguration", menuName = "BulletConfiguration")]
public class BulletConfiguration : ScriptableObject
{
    [SerializeField]
    private float _speed, _timeToLive;

    public float Speed => _speed;
    public float TimeToLive => _timeToLive;
}
