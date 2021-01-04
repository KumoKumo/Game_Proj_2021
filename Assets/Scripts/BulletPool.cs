using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private float firingRate;
    private Queue<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Queue<Bullet>();
        _shootDirection = Vector3.up;
    }

    private void Update()
    {
        GetShootingDirection();
        if (IsTimeToShoot())
            Shoot();
    }

    private void GetShootingDirection()
    {
        var direction = input.GetMovementInput();
        if (direction != Vector3.zero)
            _shootDirection = direction;
    }

    private float _timer = 0;
    private bool IsTimeToShoot()
    {
        if (_timer < firingRate)
        {
            _timer += Time.deltaTime;
            return false;
        }
        else
        {
            _timer = 0;
            return true;
        }
    }

    private Vector3 _shootDirection;
    private void Shoot()
    {
        if (_bulletPool.Count == 0)
        {
            SpawnBullet();
        }
        else
        {
            ShootABullet();
        }
    }

    private void ShootABullet()
    {
        var bullet = _bulletPool.Dequeue();
        bullet.transform.position = transform.position;
        bullet.Direction = _shootDirection;
        bullet.Show();
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletObj);
        LoadBullet(bullet.GetComponent<Bullet>());
        ShootABullet();
    }

    private void LoadBullet(Bullet bullet)
    {
        bullet.OnTimeOut += OnBulletTimeOut;
        _bulletPool.Enqueue(bullet);
    }

    private void OnBulletTimeOut(Bullet bullet)
    {
        bullet.Hide();
        _bulletPool.Enqueue(bullet);
    }
}
