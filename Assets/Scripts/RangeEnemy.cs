using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] private Bullet _bullet;

    [SerializeField] private float _damage;

    [SerializeField] private Transform _firePoint;

    [SerializeField] private float _bulletSpeed;

    [SerializeField] private float _shotDelay;

    [SerializeField] private SpriteRenderer _weaponSprite;
    [SerializeField] private Transform _weapon;

    private float _time;

    private void Update()
    {
        RotateTo(_player.Position);

        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }

        if (_time <= 0)
        {
            if (Vector3.Distance(transform.position, _player.Position) <= _agent.stoppingDistance)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        _time = _shotDelay;

        Bullet bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);

        bullet.Inject(_damage);

        Vector3 target = _player.Position - transform.position;

        bullet.MoveTo(target, _bulletSpeed);
    }

    private void RotateTo(Vector3 to)
    {
        Vector3 direction = to - _weapon.position;
        direction.Normalize();


        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _weapon.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (rotateZ > -90 && rotateZ < 90)
        {
            _weaponSprite.flipY = false;

        }
        else
        {
            _weaponSprite.flipY = true;
        }
    }
}
