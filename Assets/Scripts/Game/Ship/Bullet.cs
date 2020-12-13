using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletConfiguration _bulletConfiguration;

    private Rigidbody2D _rigidBody;
    private bool _exitedShip;

    public bool ExitedShip => _exitedShip;
    public bool IsActive()
    {
        return this.gameObject.activeSelf;
    }

    public void Fire(Transform ship)
    {
        _exitedShip = false;
        if (_rigidBody == null)
            _rigidBody = GetComponent<Rigidbody2D>();

        transform.position = ship.position;
        transform.eulerAngles = ship.eulerAngles;
        this.gameObject.SetActive(true);
        _rigidBody.AddForce(transform.right * _bulletConfiguration.Speed, ForceMode2D.Impulse);

        StartCoroutine(DestroyAfterSeconds());
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSecondsRealtime(_bulletConfiguration.TimeToLive);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            _exitedShip = true;
        }
    }
}