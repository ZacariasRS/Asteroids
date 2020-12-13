using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletConfiguration _bulletConfiguration;

    private Rigidbody2D _rigidBody;
    public bool IsActive()
    {
        return this.gameObject.activeSelf;
    }

    public void Fire(Ship ship)
    {
        if (_rigidBody == null)
            _rigidBody = GetComponent<Rigidbody2D>();

        transform.position = ship.transform.position;
        transform.eulerAngles = ship.transform.eulerAngles;
        this.gameObject.SetActive(true);
        _rigidBody.AddForce(transform.right * _bulletConfiguration.Speed, ForceMode2D.Impulse);

        StartCoroutine(DestroyAfterSeconds());
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSecondsRealtime(_bulletConfiguration.TimeToLive);
        this.gameObject.SetActive(false);
    }
}