using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShipConfiguration", menuName = "ShipConfiguration")]
public class ShipConfiguration : ScriptableObject
{
    [SerializeField]
    private float _maxSpeed, _speed, _rotationSpeed, _linearDrag, _fireCooldown;

    public float MaxSpeed => _maxSpeed;
    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;
    public float LinearDrag => _linearDrag;
    public float FireCooldown => _fireCooldown;
}
