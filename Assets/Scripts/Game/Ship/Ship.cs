using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _shipSpriteRenderer;
    [SerializeField]
    private ShipConfiguration _shipConfiguration;
    [SerializeField]
    private BulletManager _bulletManager;
    [SerializeField]
    private GameController _gameController;
    [SerializeField]
    private Transform _firePosition;
    [SerializeField]
    private SoundManager _soundManager;
    [SerializeField]
    private VFXManager _vfxManager;

    private Vector2 _lastInput;
    private Rigidbody2D _rigidBody;
    private Transform _transform;
    private float _lastTimeFire;

    private bool _acceptInput;
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
    public void MoveInput(Vector2 input)
    {
        _lastInput = input;
    }

    public void MoveInput(CallbackContext context)
    {
        if (!_acceptInput)
            return;
        MoveInput(context.ReadValue<Vector2>());
    }

    public void FireInput(CallbackContext context)
    {
        if (!_acceptInput)
            return;
        if (context.performed)
        {
            CheckFire();
        }
    }

    public void CheckFire()
    {
        if (Time.time - _lastTimeFire > _shipConfiguration.FireCooldown)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        _soundManager.DoBulletSound();
        Bullet bullet = _bulletManager.GetBullet();
        bullet.Fire(_firePosition);
        _lastTimeFire = Time.time;
    }

    public void FixedUpdate()
    {
        if (!_acceptInput)
            return;
        if (_rigidBody.velocity.magnitude < _shipConfiguration.MaxSpeed)
        {
            _rigidBody.AddForce(_transform.right * (_lastInput.y * _shipConfiguration.Speed), ForceMode2D.Impulse);
        }
        _transform.Rotate(new Vector3(0, 0, -1 * _lastInput.x * _shipConfiguration.RotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShipBullet"))
        {
            if (collision.GetComponent<Bullet>().ExitedShip)
            {
                collision.gameObject.SetActive(false);
                DestroyByShipBullet(collision);
            }
        }
        else if (collision.CompareTag("Asteroid"))
        {
            DestroyByAsteroid(collision);
        }
    }

    private void DestroyByShipBullet(Collider2D collision)
    {
        _vfxManager.DoExplosionVFX(this.transform);
        _soundManager.DoDeathSound();
        _lastInput = Vector2.zero;
        _acceptInput = false;
        ActivateShip(false);
        _gameController.ShipDestroyed();
    }

    private void DestroyByAsteroid(Collider2D collision)
    {
        _vfxManager.DoExplosionVFX(this.transform);
        _soundManager.DoDeathSound();
        _lastInput = Vector2.zero;
        _acceptInput = false;
        ActivateShip(false);
        _gameController.ShipDestroyed();
    }

    public void AcceptInput(bool b)
    {
        _acceptInput = b;
    }

    public void ActivateShip(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
