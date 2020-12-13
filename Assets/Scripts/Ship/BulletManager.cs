using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> _bullets;

    [SerializeField]
    private Bullet bulletPrefab;

    public Bullet GetBullet()
    {
        Bullet bullet = _bullets.Find((b) => !b.IsActive());
        if (bullet == null)
        {
            bullet = Instantiate(bulletPrefab);
            _bullets.Add(bullet);
        }
        return bullet;
    }
}
