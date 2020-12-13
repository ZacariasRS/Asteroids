using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private ShipConfiguration _shipConfiguration;
    [SerializeField]
    private BulletManager _bulletManager;

    private Vector2 _lastInput;
    private Rigidbody2D _rigidBody;
    private Transform _transform;
    private float _lastTimeFire;
    private void Awake()
    {
        _lastTimeFire = float.MinValue;
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = this.transform;
        ApplyShipConfiguration();
    }

    private void ApplyShipConfiguration()
    {
        _rigidBody.drag = _shipConfiguration.LinearDrag;
    }
    private void MoveInput(Vector2 input)
    {
        _lastInput = input;
    }

    public void MoveInput(CallbackContext context)
    {
        MoveInput(context.ReadValue<Vector2>());
    }

    public void FireInput(CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.time - _lastTimeFire > _shipConfiguration.FireCooldown)
            {
                FireBullet();
            }
        }
    }

    private void FireBullet()
    {
        Bullet bullet = _bulletManager.GetBullet();
        bullet.Fire(this);
        _lastTimeFire = Time.time;
    }

    public void FixedUpdate()
    {
        if (_rigidBody.velocity.magnitude < _shipConfiguration.MaxSpeed)
        {
            _rigidBody.AddForce(_transform.right * (_lastInput.y * _shipConfiguration.Speed), ForceMode2D.Impulse);
        }
        _transform.Rotate(new Vector3(0, 0, -1 * _lastInput.x * _shipConfiguration.RotationSpeed));
    }
}
