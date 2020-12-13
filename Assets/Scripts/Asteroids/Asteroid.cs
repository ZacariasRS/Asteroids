using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid<T> : MonoBehaviour where T : AsteroidConfiguration
{
    [SerializeField]
    protected T _asteroidConfiguration;

    protected AsteroidManager _asteroidManager;

    protected Rigidbody2D _rigidBody;
    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetAsteroidManager(AsteroidManager asteroidManager)
    {
        _asteroidManager = asteroidManager;
    }
    public bool IsActive()
    {
        return this.gameObject.activeSelf;
    }

    protected virtual void OnEnable()
    {
        _rigidBody.AddForce(this.transform.right * _asteroidConfiguration.Speed, ForceMode2D.Impulse);
    }

    public void RotateRandom()
    {
        this.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShipBullet"))
        {
            collision.gameObject.SetActive(false);
            DestroyAsteroid();
        }
    }

    protected virtual void DestroyAsteroid()
    {
        this.gameObject.SetActive(false);
    }
}
