using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAsteroid
{
    bool IsActive();
    void RotateRandom();
    void SetPositionAndRotation(Transform transform);
    void SetActive(bool active);
}
public class Asteroid<T> : MonoBehaviour, IAsteroid where T : AsteroidConfiguration
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
        _asteroidManager.VFXManager.DoExplosionVFX(this.transform);
        _asteroidManager.SoundManager.DoExplosionSound();
        _asteroidManager.AddToScore(_asteroidConfiguration.Points);
        SetActive(false);
    }

    public void SetPositionAndRotation(Transform t)
    {
        this.transform.SetPositionAndRotation(t.position, t.rotation);
    }

    public virtual void SetActive(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
