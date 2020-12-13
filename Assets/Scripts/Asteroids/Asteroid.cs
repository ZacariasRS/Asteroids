using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid<T> : MonoBehaviour where T : AsteroidConfiguration
{
    [SerializeField]
    protected T _asteroidConfiguration;

    protected Rigidbody2D _rigidBody;
    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        _rigidBody.AddForce(this.transform.right * _asteroidConfiguration.Speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
